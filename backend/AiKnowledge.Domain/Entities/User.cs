using AiKnowledge.Domain.Common;
using AiKnowledge.Domain.Enums;

namespace AiKnowledge.Domain.Entities
{

    public class User : BaseEntity
    {
        public string Email { get; set; }  = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserStatus Status { get; set; } = UserStatus.Active;

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        public ICollection<Document> Documents { get; set; } = new List<Document>();

        public ICollection<Conversation> Conversations { get; set; } = new List<Conversation>();

    }
}
