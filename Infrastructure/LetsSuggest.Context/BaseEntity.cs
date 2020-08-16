using System;
using System.ComponentModel.DataAnnotations.Schema;
using LetsSuggest.Shared.Common;
using Newtonsoft.Json;
using ObjectStateInterfaces;

namespace LetsSuggest.Context
{
    public abstract class BaseEntity : IAudit
    {
        private DateTime? _createdDate;
        public DateTime? CreatedDate
        {
            get => _createdDate?.UtcDate();
            set => _createdDate = value?.UtcDate();
        }
        public int? CreatedBy { get; set; }

        private DateTime? _modifiedDate;
        public DateTime? ModifiedDate
        {

            get => _modifiedDate?.UtcDate();
            set => _modifiedDate = value?.UtcDate();
        }
        public int? ModifiedBy { get; set; }
        private DateTime? _deletedDate;
        public DateTime? DeletedDate
        {
            get => _deletedDate?.UtcDate();
            set => _deletedDate = value?.UtcDate();
        }
        public int? DeletedBy { get; set; }
        [NotMapped]
        public ObjState ObjState { get; set; }
        [NotMapped]
        [JsonIgnore]
        public bool IsDeleteProcess { get; set; } = false;
    }
}
