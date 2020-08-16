using System;

namespace ObjectStateInterfaces
{
    public interface IAudit
    {
        DateTime? CreatedDate { get; set; }
        int? CreatedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        int? ModifiedBy { get; set; }
        DateTime? DeletedDate { get; set; }
        int? DeletedBy { get; set; }
        ObjState ObjState { get; set; }
        Boolean IsDeleteProcess { get; set; }
    }
}
