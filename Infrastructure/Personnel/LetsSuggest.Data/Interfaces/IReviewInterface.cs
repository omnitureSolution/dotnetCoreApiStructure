using System.Collections.Generic;
using System.Linq;
using Jainism.Core;

namespace Jainism.Data.Interfaces
{
    public interface IReviewInterface : IEntityRepository<Review>
    {
        IQueryable ReviewList(int bussnessId);
        List<Review> UserReview(int userId);
    }
}
