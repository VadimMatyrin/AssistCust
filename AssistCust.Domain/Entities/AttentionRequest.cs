using System.ComponentModel.DataAnnotations.Schema;

namespace AssistCust.Domain.Entities
{
    public class AttentionRequest
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool IsResolved { get; set; }
        public string SenderId { get; set; }
        public string ManagerId { get; set; }
        [ForeignKey("SenderId")]
        public User Sender { get; set; }
        [ForeignKey("ManagerId")]
        public User Manager { get; set; }
    }
}
