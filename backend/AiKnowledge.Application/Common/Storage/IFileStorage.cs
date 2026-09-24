using System;
using System.Collections.Generic;
using System.Text;

namespace AiKnowledge.Application.Common.Storage
{
    public interface IFileStorage
    {
        Task<string> SaveAsync(
            Stream stream,
            string fileName,
            CancellationToken cancellationToken);

        Task DeleteAsync(
            string path,
            CancellationToken cancellationToken);
    }
}
