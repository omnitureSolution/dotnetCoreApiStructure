using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core;
using LetsSuggest.Personnel.Core.Interfaces;
using LetsSuggest.Personnel.Core.Model.Common;
using LetsSuggest.Personnel.Core.Model.CustomLibrary;
using LetsSuggest.Shared.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LetsSuggest.Personnel.Data.Repository.Common
{
    public class LocationRepository : GenericRepository<ILetsSuggestContext, Location>,
        ILocationInterface
    {
        private readonly ILetsSuggestContext _context;
        private readonly IUserInfo _userInfo;
        private readonly ILogger<LocationRepository> _logger;

        public LocationRepository(IUnitOfWork<ILetsSuggestContext> uow,
            IUserInfo userInfo, ILogger<LocationRepository> logger) : base(uow)
        {
            _context = uow.Context as ILetsSuggestContext;
            _userInfo = userInfo;
            _logger = logger;
        }
        Location ILocationInterface.GetLocation(long locationId)
        {
            return _context.Location.FirstOrDefault(t => t.DeletedDate == null && t.LocationId == locationId);
        }
        int ILocationInterface.SaveLocation(Location objLocation)
        {
            int locationId = 0;
            var location = All.AsNoTracking().Where(x => x.StateId == objLocation.StateId && x.PincodeId == objLocation.PincodeId && x.CityId == objLocation.CityId);
            if (location.Any())
                location = location.AsNoTracking().Where(x => x.Address.Equals(objLocation.Address, StringComparison.InvariantCultureIgnoreCase));
            if (location.Any())
            {
                locationId = location.First().LocationId;
            }
            else
            {
                Add(objLocation);
                _context.SaveChanges();
                _context.Entry(objLocation).State = EntityState.Detached;
                locationId = objLocation.LocationId;
            }

            GetLatLon(objLocation);

            return locationId;
        }
        public IEnumerable SearchLocation(string locationName)
        {
            if (string.IsNullOrEmpty(locationName) || locationName.Length < 3)
                return new List<LocationResult>();

            string query = @"SELECT TOP (10) TempLocation.*
                        FROM
                        (
                            SELECT LstCity.Name LocationName,
                                   NULL Latitude,
                                   NULL Longitude
                            FROM LstCity
                            WHERE LstCity.Name LIKE CONCAT(@Location, '%')
                            UNION ALL
                            SELECT LstPincode.PinCode LocationName,
                                   LstPincode.Latitude,
                                   LstPincode.Longitude
                            FROM LstPincode
                            WHERE LstPincode.PinCode LIKE CONCAT(@Location, '%')
                            UNION ALL
                            SELECT LstState.Name LocationName,
                                   NULL Latitude,
                                   NULL Longitude
                            FROM LstState
                            WHERE LstState.Name LIKE CONCAT(@Location, '%')
                        ) TempLocation";

            return _context.SqlQuery<LocationResult>(query, new SqlParameter("Location", locationName)).ToList();
        }

        private void GetLatLon(Location location)
        {
            if (Convert.ToDouble(location.Latitude) == 0 && Convert.ToDouble(location.Longitude) == 0)
            {
                try
                {
                    var stateCode = _context.Lststate.Find(location.StateId).Name;
                    var cityName = _context.Lstcity.Find(location.CityId).Name;
                    var zipCode = _context.Lstpincode.Find(location.PincodeId).PinCode;


                    double latitude;
                    double longitude;
                    GoogleLocationService.GetLanLon(GoogleLocationService.GoogleAddress(location.Address, cityName, stateCode, zipCode), out latitude, out longitude);
                    location.Latitude = latitude;
                    location.Longitude = longitude;
                    _context.SaveChanges();
                    _context.Entry(location).State = EntityState.Detached;
                }
                catch (Exception ex) { _logger.LogError(ex, "GetLatLon"); }
            }
        }
        public List<Location> GetMatchedLocation(int stateId, int? cityId, int? zipId, string address)
        {
            var location = this.All.Where(x => x.StateId == stateId
            && x.CityId == cityId && x.PincodeId == zipId);

            if (location.Any())
                location = location.Where(x => x.Address.Equals(address, StringComparison.InvariantCultureIgnoreCase));

            return location.ToList();
        }

        public UserAddress SaveUserAddress(UserAddress userAddress)
        {
            Location location = null;
            var locations = GetMatchedLocation(userAddress.Location.StateId, userAddress.Location.CityId, userAddress.Location.PincodeId, userAddress.Location.Address);
            if (locations.Any())
            {
                location = locations.First();
                userAddress.LocationId = location.LocationId;
            }
            if (location == null)
            {
                location = userAddress.Location;
                this.Add(location);
                _context.SaveChanges();
            }
            userAddress.UserId = _userInfo.UserId;
            userAddress.LocationId = location.LocationId;
            if (userAddress.UserAddressId > 0)
                _context.UserAddress.Add(userAddress);
            else
                _context.UserAddress.Update(userAddress);
            _context.SaveChanges();

            userAddress.Location = location;
            return userAddress;
        }

        public List<UserAddress> GetUserAddresses()
        {
            var result = _context.UserAddress
                .Where(x => x.UserId == _userInfo.UserId)
                .Include(x => x.Location)
                .ToList();

            result.ForEach(x =>
                {
                    if (x.Location != null)
                    {
                        x.Location.StateName = _context.Lststate.Find(x.Location.StateId).Name;
                        if (x.Location.CityId > 0)
                            x.Location.CityName = _context.Lstcity.Find(x.Location.CityId).Name;
                        if (x.Location.PincodeId > 0)
                            x.Location.PinCode = _context.Lstpincode.Find(x.Location.PincodeId).PinCode;

                    }
                });
            return result;
        }

    }
}
