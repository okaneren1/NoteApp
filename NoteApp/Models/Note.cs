using System.ComponentModel.DataAnnotations;

namespace NoteApp.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        public User? User { get; set; }
    }
}
