using System.Collections;
using Jainism.Core;

namespace Jainism.Data.Interfaces
{
    public interface IBookMarkInterface :IEntityRepository<Bookmark>
    {
        IEnumerable GetBookmarkList(int moduleId, int userId);
    }
}
