using AiKnowledge.Domain.Common;
using AiKnowledge.Domain.Enums;

namespace AiKnowledge.Domain.Entities
{
    public class Message : BaseEntity
    {
        public Guid ConversationId { get; set; }

        public MessageRole Role { get; set; }

        public string Content { get; set; } = string.Empty;

        public Conversation Conversation { get; set; } = null!;
    }
}
