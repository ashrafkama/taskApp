using Microsoft.AspNetCore.Mvc;
using Task_Application.Models;

namespace Task_Application.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        public Task<ActionResult<IEnumerable<T>>> Get();
        public Task<ActionResult<T>> Create(T entity);
        public Task<IActionResult> Update(int id, T entity);
        public Task<IActionResult> Delete(int id);
        IEnumerable<T> GetFile(CancellationToken ct);
    }
}
