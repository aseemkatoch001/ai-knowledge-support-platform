using System;
using System.Collections.Generic;
using System.Text;

namespace AiKnowledge.Application.Documents.Upload
{
    public sealed record UploadDocumentResult(
     Guid Id,
     string Name,
     string Status,
     DateTime CreatedAt);
}
