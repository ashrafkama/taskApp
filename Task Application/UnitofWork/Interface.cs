using Microsoft.EntityFrameworkCore;

namespace Task_Application.UnitofWork
{
    public interface IUnitOfwork : IDisposable
    {
        DbContext Context { get; }
        public Task SaveChangesAsync();
    }
}