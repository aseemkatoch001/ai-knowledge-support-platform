using AiKnowledge.Domain.Common;

namespace AiKnowledge.Domain.Entities
{
    public class Conversation : BaseEntity
    {
        public Guid UserId { get; set; }

        public string Title { get; set; } = string.Empty;

        public User User { get; set; } = null!;

        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
