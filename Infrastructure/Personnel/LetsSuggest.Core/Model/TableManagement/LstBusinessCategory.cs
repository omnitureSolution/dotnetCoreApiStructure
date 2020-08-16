using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.Personnel;

namespace LetsSuggest.Personnel.Core.Model.TableManagement
{
    public class Lstbusinesscategory : BaseEntity
    {
        private List<Lstbusinesscategory> _children;
        [Key]
        public int BusinessCategoryId { get; set; }

        public int? ParentCategoryId { get; set; }
        [NotMapped]
        public List<Lstbusinesscategory> Children
        {
            get { return (_children ?? (_children = new List<Lstbusinesscategory>())); }
            set { _children = value; }
        }
        //[NotMapped]
        //public int? PrimaryCategoryId { get; set; }

        //[NotMapped]
        //public int? SecondaryCategoryId { get; set; }

        public string Name { get; set; }
        public int? IconId { get; set; }
        [ForeignKey("IconId")]
        public Lsticon Lsticons { get; set; }
        [ForeignKey("CreatedBy")]
        public LstPersonnel CreatedByName { get; set; }
        [ForeignKey("ModifiedBy")]
        public LstPersonnel ModifiedByName { get; set; }
        [ForeignKey("ParentCategoryId")]
        public Lstbusinesscategory ParentCategory { get; set; }

    }
}
