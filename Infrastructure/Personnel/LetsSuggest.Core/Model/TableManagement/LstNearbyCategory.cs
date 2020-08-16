using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.Personnel;

namespace LetsSuggest.Personnel.Core.Model.TableManagement
{
    public class LstNearbyCategory : BaseEntity
    {
        [Key]
        public int NearbyCategoryId { get; set; }
        public int BusinessCategoryId { get; set; }
        public int ChildBusinessCategoryId { get; set; }

        [ForeignKey("CreatedBy")]
        public LstPersonnel CreatedByEmp { get; set; }
        [ForeignKey("ModifiedBy")]
        public LstPersonnel ModifiedByEmp { get; set; }
    }

    public class NearbyCategoryModel: LstNearbyCategory
    {
        public int[] childBusinessCategories { get; set; }
        public string CreatedName { get; set; }
        public string ModifiedName { get; set; }
        public string MainCategoryText { get; set; }
        public string NearByCategory1 { get; set; }
        public string NearByCategory2 { get; set; }
        public string NearByCategory3 { get; set; }

    }
}

