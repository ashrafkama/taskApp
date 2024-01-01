using System;
using System.Collections.Generic;
using Task_Application.Repository;

namespace Task_Application.Models
{
    public partial class Assignee : IEntity
    {
        public Assignee()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string? Assignee1 { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
