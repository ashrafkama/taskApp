using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task_Application.Models
{
    public partial class Task
    {
        
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public int StatusNo { get; set; }
        [Required]
        public int AssigneeNo { get; set; }

        public virtual Assignee? AssigneeNoNavigation { get; set; }
        public virtual Status? StatusNoNavigation { get; set; }
    }
}
