using Microsoft.EntityFrameworkCore;
using Task_Application.Models;
using Task_Application.UnitofWork;

namespace Task_Application.Repository
{
    public class ReviewRepository : RepositoryBase<Review>
    {
        public ReviewRepository(IUnitOfwork unitOfwork, string ProcedureName) : base(unitOfwork, ProcedureName)
        {
        }
    }
}
