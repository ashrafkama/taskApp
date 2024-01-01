using System;
using System.Collections.Generic;
using Task_Application.Repository;

namespace Task_Application.Models
{
    public partial class Status : IEntity
    {
        public Status()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
