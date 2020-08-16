using System.Collections.Generic;
using Jainism.Core;

namespace Jainism.Data.Interfaces
{
    public interface IDocumentDataInterface : IEntityRepository<DocumentData>
    {
        string SaveTempDoc(byte[] fileByte, string fileName);    
        DocumentData SaveDocument(DocumentData documentData);
        DocumentData GetDocument(int subjectKeyId, int subjectRecordId);
        List<DocumentData> GetDocuments(int subjectKeyId, int subjectRecordId);
    }
}
