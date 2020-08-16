using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LetsSuggest.Context;

namespace LetsSuggest.Personnel.Core.Model.Common
{
    public class Gallery : BaseEntity
    {
        [Key]
        public Guid GalleryId { get; set; }
        public string OriginalName { get; set; }
        public string FileExtension { get; set; }

        [NotMapped]
        public string ImageUrl
        {
            get {
               return this.GalleryId.ToString() + this.FileExtension;
            }
        
    }

}
}
