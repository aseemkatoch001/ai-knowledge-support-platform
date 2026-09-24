using AiKnowledge.Domain.Common;
using AiKnowledge.Domain.Enums;

namespace AiKnowledge.Domain.Entities
{
    public class Document : BaseEntity
    {
        public Guid UserId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string BlobPath { get; set; } = string.Empty;

        public DocumentStatus Status { get; set; } = DocumentStatus.Processing;

        public User User { get; set; } = null!;

        public ICollection<DocumentChunk> Chunks { get; set; } = new List<DocumentChunk>();
    }
}
