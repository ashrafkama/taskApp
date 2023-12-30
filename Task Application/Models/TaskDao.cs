using System.ComponentModel.DataAnnotations;

namespace Task_Application.Models
{
    public class TaskDao
    {
        
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public int StatusNo { get; set; }
        [Required]
        public int AssigneeNo { get; set; }
    }
}
