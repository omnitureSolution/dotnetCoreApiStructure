
using ObjectStateInterfaces;

namespace LetsSuggest.Context
{
    public class StateHelpers
    {
        public static Microsoft.EntityFrameworkCore.EntityState ConvertState(ObjState objstate)
        {
            switch (objstate)
            {
                case ObjState.Added:
                    return Microsoft.EntityFrameworkCore.EntityState.Added;
                case ObjState.Modified:
                    return Microsoft.EntityFrameworkCore.EntityState.Modified;
                case ObjState.Deleted:
                    return Microsoft.EntityFrameworkCore.EntityState.Deleted;
                default:
                    return Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            }
        }
    }
}
