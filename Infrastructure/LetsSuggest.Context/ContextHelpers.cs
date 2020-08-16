using Microsoft.EntityFrameworkCore;
using ObjectStateInterfaces;

namespace LetsSuggest.Context
{
    public static class ContextHelpers
    {
        //Only use with short lived contexts 
        public static void ApplyStateChanges(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<IAudit>())
            {
                IAudit stateInfo = entry.Entity;
                entry.State = StateHelpers.ConvertState(stateInfo.ObjState);
            }
        }
    }
}
