using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task_Application.Models
{
    public partial class Status
    {
        public Status()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string? Status1 { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
