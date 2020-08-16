using System;
using System.Collections.Generic;
using System.Text;


namespace LetsSuggest.Product.Core.Model
{
    public class Business : LetsSuggest.Context.BaseEntity
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string Website { get; set; }
        public int? LocationId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid? GalleryId { get; set; }

    }
}
