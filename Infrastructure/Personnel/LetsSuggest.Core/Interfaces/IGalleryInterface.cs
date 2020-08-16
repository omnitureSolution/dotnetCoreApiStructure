using System;
using System.Collections.Generic;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core.Model.Common;
using Microsoft.AspNetCore.Http;

namespace LetsSuggest.Personnel.Core.Interfaces
{
    public interface IGalleryInterface : IEntityRepository<Gallery>
    {

        List<Gallery> GallerySave(List<IFormFile> files);
        List<Gallery> GetGallery(List<Guid> galleryId);
        //List<Gallery> GetDocuments(int subjectKeyId, int subjectRecordId);
    }
}
