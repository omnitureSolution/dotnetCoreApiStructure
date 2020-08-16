using Jainism.Core.PoojaDetail;

namespace Jainism.Data.Interfaces
{
    public interface IPoojaInterface : IEntityRepository<Pooja>
    {
        bool isCheckExist(string name, int id);
        void UpdatePooja(Pooja pooja);
        void DeletePooja(Pooja pooja);
    }
}
