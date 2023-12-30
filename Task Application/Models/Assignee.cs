using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Application.Models
{
    public partial class Assignee
    {
        public Assignee()
        {
            Tasks = new HashSet<Task>();
        }
        [ForeignKey("Task")]
        public int Id { get; set; }
        public string? Assignee1 { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
