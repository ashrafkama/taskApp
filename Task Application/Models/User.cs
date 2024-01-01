using Task_Application.Repository;

namespace Task_Application.Models
{
    public class User: IEntity
    {
        [StoredProcedureParameter]
        public int Id { get; set; }
        [StoredProcedureParameter]
        public string? Username { get; set; }
      
        [StoredProcedureParameter]

        public string? Password { get; set; }
    }
}
