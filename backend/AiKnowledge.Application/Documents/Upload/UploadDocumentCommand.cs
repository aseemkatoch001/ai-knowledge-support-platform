using AiKnowledge.Application.Common.Storage;
using AiKnowledge.Domain.Enums;
using AiKnowledge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AiKnowledge.Application.Documents.Upload
{

    public sealed class UploadDocumentHandler : IUploadDocumentHandler
    {
        private readonly IDocumentRepository documentRepository;
        private readonly IFileStorage _fileStorage;

        public UploadDocumentHandler(
            IDocumentRepository documentRepository,
            IFileStorage fileStorage)
        {
            this.documentRepository = documentRepository;
            _fileStorage = fileStorage;
        }

        public async Task<UploadDocumentResult> HandleAsync(
            UploadDocumentCommand command,
            CancellationToken cancellationToken)
        {
            var storedPath = await _fileStorage.SaveAsync(
                command.FileStream,
                command.FileName,
                cancellationToken);

            var document = new Document
            {
                Id = Guid.NewGuid(),
                Name = command.FileName,
                BlobPath = storedPath,
                Status = DocumentStatus.Processing,
                CreatedAt = DateTime.UtcNow
            };

            await this.documentRepository.AddAsync(document, cancellationToken);

            return new UploadDocumentResult(
                document.Id,
                document.Name,
                document.Status.ToString(),
                document.CreatedAt);
        }
    }

    public sealed class UploadDocumentCommand
    {
        public Stream FileStream { get; }
        public string FileName { get; }

        public long FileSize { get; }   

        public UploadDocumentCommand(Stream fileStream, string fileName)
        {
            FileStream = fileStream;
            FileName = fileName;
            FileSize = fileStream.Length;
        }
    }
}
