using System.Collections;
using System.Collections.Generic;
using Jainism.Core;
using Jainism.Shared.Helper;

namespace Jainism.Data.Interfaces
{
    public interface IBusinessCategoryInterface : IEntityRepository<Lstbusinesscategory>
    {
        IEnumerable GetBusinessCategoryTree();
        IEnumerable GetBusinessCategories();
        IEnumerable GetBusinessIcons();
        List<ComboModel> GetPrimaryCategories(int? id);
        //List<ComboModel> GetSecondaryCategories(int primaryCategoryId);
        bool IsCategoryNameExist(string name, int id);
    }
}
