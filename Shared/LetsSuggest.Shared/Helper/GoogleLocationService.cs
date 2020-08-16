using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;

namespace LetsSuggest.Shared.Helper
{
    public class GoogleLocationService
    {
        private const string GoogleMapUrl = "http://maps.google.com/maps/api/geocode/xml?address={0}";

        public static void GetLanLon(string address, out double latitude, out double longitude)
        {
            latitude = 0;
            longitude = 0;
            WebRequest request = WebRequest.Create(string.Format(GoogleMapUrl, address));
            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    DataSet dsResult = new DataSet();
                    dsResult.ReadXml(reader);
                    DataTable dtCoordinates = new DataTable();
                    dtCoordinates.Columns.AddRange(new[] { new DataColumn("Id", typeof(int)),
                        new DataColumn("Address", typeof(string)),
                        new DataColumn("Latitude",typeof(string)),
                        new DataColumn("Longitude",typeof(string)) });
                    if (dsResult.Tables["result"] != null)
                    {
                        foreach (DataRow row in dsResult.Tables["result"].Rows)
                        {
                            if (latitude != 0)
                            { continue; }
                            string geometryId = dsResult.Tables["geometry"].Select("result_id = " + Convert.ToString(row["result_id"]))[0]["geometry_id"].ToString();
                            DataRow location = dsResult.Tables["location"].Select("geometry_id = " + geometryId)[0];
                            latitude = Convert.ToDouble(location["lat"]);
                            longitude = Convert.ToDouble(location["lng"]);                            
                        }
                    }

                }
            }
        }

        public static string GoogleAddress(string address, string city, string stateCode, string zipCode)
        {
            return string.Format("{0}, {1}, {2} {3}", address, city, stateCode, zipCode);
        }


    }
}
