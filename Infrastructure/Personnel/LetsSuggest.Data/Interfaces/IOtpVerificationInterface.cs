using Jainism.Core;
using Jainism.Core.Personnel;

namespace Jainism.Data.Interfaces
{
    public interface IOtpVerificationInterface : IEntityRepository<OtpVerification>
    {
        void SendOtp(lstPersonnel lstpersonnel);
    }
}
