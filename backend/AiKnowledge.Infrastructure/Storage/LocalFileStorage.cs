using AiKnowledge.Application.Common.Storage;
using Microsoft.Extensions.Configuration;

namespace AiKnowledge.Infrastructure.Storage
{
    namespace AiKnowledge.Application.Common.Storage
    {
        public sealed class LocalFileStorage : IFileStorage
        {
            private readonly string _storagePath;

            public LocalFileStorage(IConfiguration configuration)
            {
                _storagePath = configuration["Storage:LocalPath"]
                    ?? "storage/documents";

                Directory.CreateDirectory(_storagePath);
            }

            public async Task<string> SaveAsync(
                Stream stream,
                string fileName,
                CancellationToken cancellationToken)
            {
                var fileId = Guid.NewGuid().ToString("N");
                var extension = Path.GetExtension(fileName);

                var storedFileName = $"{fileId}{extension}";
                var fullPath = Path.Combine(_storagePath, storedFileName);

                await using var fileStream = new FileStream(
                    fullPath,
                    FileMode.CreateNew,
                    FileAccess.Write,
                    FileShare.None,
                    81920,
                    useAsync: true);

                await stream.CopyToAsync(fileStream, cancellationToken);

                return fullPath;
            }

            public Task DeleteAsync(
                string path,
                CancellationToken cancellationToken)
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                return Task.CompletedTask;
            }
        }
    }

}
