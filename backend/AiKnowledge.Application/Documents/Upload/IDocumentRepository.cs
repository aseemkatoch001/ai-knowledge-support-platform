using AiKnowledge.Domain.Entities;

namespace AiKnowledge.Application.Documents.Upload
{
    public interface IDocumentRepository
    {
        Task AddAsync(
            Document document,
            CancellationToken cancellationToken);

        Task SaveChangesAsync(
            CancellationToken cancellationToken);
    }
}
