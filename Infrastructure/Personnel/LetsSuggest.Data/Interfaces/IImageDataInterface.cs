using System.Collections.Generic;
using Jainism.Core;

namespace Jainism.Data.Interfaces
{
    public interface IImageDataInterface : IEntityRepository<ImageData>
    {
        string SaveTempImage(byte[] fileByte, string fileName);
        ImageData SaveImage(ImageData imageResult);
        ImageData GetImage(int subjectKeyId, int subjectRecordId);
        List<ImageData> GetImages(int subjectKeyId, int subjectRecordId);
    }
}