using Microsoft.EntityFrameworkCore;
using Task_Application.Models;
using Task_Application.UnitofWork;

namespace Task_Application.Repository
{
    public class TaskRepository : RepositoryBase<Models.Task>
    {

        public TaskRepository(IUnitOfwork unitOfwork, string ProcedureName) : base(unitOfwork, ProcedureName)
        {
        }
    }
}
