using System;
using System.Collections.Generic;
using System.Text;

namespace AiKnowledge.Application.Documents.Upload
{
    public interface IUploadDocumentHandler
    {
        Task<UploadDocumentResult> HandleAsync(
            UploadDocumentCommand command,
            CancellationToken cancellationToken);
    }
}
