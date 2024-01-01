using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Task_Application.Repository;

namespace Task_Application.Models
{
    public partial class Task : IEntity
    {
        [StoredProcedureParameter]
        public int Id { get; set; }
        [Required]
        [StoredProcedureParameter]
        public string? Title { get; set; }
        [Required]
        [StoredProcedureParameter]
        public string? Description { get; set; }
        [Required]
        [StoredProcedureParameter]
        public DateTime? DueDate { get; set; }
        [Required]
        [StoredProcedureParameter]
        public int? StatusNo { get; set; }
        [Required]
        [StoredProcedureParameter]
        public int? AssigneeNo { get; set; }

        public virtual Assignee? AssigneeNoNavigation { get; set; }
        public virtual Status? StatusNoNavigation { get; set; }
    }
}
