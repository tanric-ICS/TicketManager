using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace TicketManager.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}

