using System;
using System.ComponentModel.DataAnnotations.Schema;
using ObjectStateInterfaces;

namespace LetsSuggest.Product.Core.Model
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.CreatedOn = DateTime.Now;
            this.LastUpdatedOn = DateTime.Now;
            this.ObjState = (int)ObjState.Added;
        }
        public System.DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime LastUpdatedOn { get; set; }
        public int LastUpdatedBy { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }

    }
}
