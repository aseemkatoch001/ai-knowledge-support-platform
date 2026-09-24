using AiKnowledge.Domain.Common;

namespace AiKnowledge.Domain.Entities
{
    public class DocumentChunk : BaseEntity
    {
        public Guid DocumentId { get; set; }

        public int ChunkIndex { get; set; }

        public string Text { get; set; } = string.Empty;

        public float[]? Embedding { get; set; }

        public Document Document { get; set; } = null!;
    }
}
