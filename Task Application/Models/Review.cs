using Task_Application.Repository;

namespace Task_Application.Models
{
    public class Review : IEntity
    {
        [StoredProcedureParameter]
        public int Id { get; set; }
        [StoredProcedureParameter]
        public string Content { get; set; }
        [StoredProcedureParameter]
        public int Rating { get; set; }
        [StoredProcedureParameter]
        public int ProductId { get; set; }
    }
}
