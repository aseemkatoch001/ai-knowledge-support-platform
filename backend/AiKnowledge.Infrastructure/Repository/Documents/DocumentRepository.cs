using AiKnowledge.Application.Documents.Upload;
using AiKnowledge.Infrastructure.Persistence.Configurations;
using AiKnowledge.Domain.Entities;

namespace AiKnowledge.Infrastructure.Repository.Documents
{
    public sealed class DocumentRepository : IDocumentRepository
    {
        private readonly AppDbContext _dbContext;

        public DocumentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task AddAsync(
            Document document,
            CancellationToken cancellationToken)
        {
            _dbContext.Documents.Add(document);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
