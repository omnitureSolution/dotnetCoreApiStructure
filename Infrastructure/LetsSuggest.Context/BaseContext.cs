using System;
using System.Threading;
using System.Threading.Tasks;
using LetsSuggest.Shared.Helper;
using Microsoft.EntityFrameworkCore;
using ObjectStateInterfaces;

namespace LetsSuggest.Context
{
    public class BaseContext<TContext>
      : DbContext where TContext : DbContext
    {

        public IUserInfo UserInfo { get; }
        protected BaseContext(DbContextOptions<TContext> options, IUserInfo userInfo)
         : base(options)
        {
            this.UserInfo = userInfo;
            // Database.Migrate();
            //Configuration.LazyLoadingEnabled = false;
        }
        public override int SaveChanges()
        {
            SetModifiedInformation();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            SetModifiedInformation();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetModifiedInformation()
        {
            foreach (var entry in ChangeTracker.Entries<IAudit>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = UserInfo.UserId;
                    entry.Entity.CreatedDate = DateTime.Now.ToUniversalTime();
                }
                else if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity.IsDeleteProcess && entry.Entity.DeletedDate == null)
                    {
                        entry.Entity.DeletedBy = UserInfo.UserId;
                        entry.Entity.DeletedDate = DateTime.Now.ToUniversalTime();
                    }
                    else
                    {
                        if (entry.Entity.CreatedBy == null)
                        {
                            entry.Entity.CreatedBy = UserInfo.UserId;
                            entry.Entity.CreatedDate = DateTime.Now.ToUniversalTime();
                        }
                        entry.Entity.ModifiedBy = UserInfo.UserId;
                        entry.Entity.ModifiedDate = DateTime.Now.ToUniversalTime();
                    }
                }
            }
        }
        private EntityState ConvertState(ObjState state)
        {
            switch (state)
            {
                case ObjState.Added:
                    return EntityState.Added;

                case ObjState.Modified:
                    return EntityState.Modified;

                case ObjState.Deleted:
                    return EntityState.Deleted;

                default:
                    return EntityState.Unchanged;
            }
        }

    }
}
