using System.Collections;
using System.Collections.Generic;
using Jainism.Core;
using Jainism.Core.CustomLibrary;
using Jainism.Shared.Helper;

namespace Jainism.Data.Interfaces
{
    public interface IBusinessInterface : IEntityRepository<Business>
    {

        IEnumerable GetBusinessesByCategoryId(int businessId);
        object GetBusinessesDetail(int businessId);
        IEnumerable GetBusinessAllDetail(int businessId);
        void RemoveExistingActionButtons(int businessId);
        void RemoveExistingCategories(int businessId);
        ICollection<Business> GetMyBussiness(BussinessOption bussinessOption);
        IEnumerable SearchBussiness(SearchModel search);
        IEnumerable SearchName(SearchModel search);
        IEnumerable GetCategoryTabs(int businessId);
        IEnumerable GetCategoryFilters(int businessId);
        List<string> GetTabColors(int businessId);
        List<ComboModel> GetBusinessByUser();
        bool IsBusinessExist(int id, string name, Location location);
        //    List<ComboModel> GetBusinessListData(int Id);
    }
}
