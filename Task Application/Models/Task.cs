using System;
using System.Collections.Generic;

namespace Task_Application.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int? StatusNo { get; set; }
        public int? AssigneeNo { get; set; }

        public virtual Assignee? AssigneeNoNavigation { get; set; }
        public virtual Status? StatusNoNavigation { get; set; }
    }
}
