using Jainism.Core;

namespace Jainism.Data.Interfaces
{
    public interface IAboutUsInterface : IEntityRepository<AboutUs>
    {
        AboutUs GetAboutUs();
    }
}
