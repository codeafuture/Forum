using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }

        //Relations
        [Required]
        public string? IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]      
        public IdentityUser? User { get; set; }

        public int? QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public Question? Question { get; set; }
    }
}
