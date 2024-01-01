using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task_Application.Exception_Handler;
using Task_Application.Helper;
using Task_Application.Models;
using Task_Application.Repository;
using Task_Application.UnitofWork;

namespace Task_Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    [TaskExceptionHandler]
    public class TaskController : Controller
    {
        private readonly IUnitOfwork _unitOfWork;
        IRepository<Models.Task> TaskRepository;

        public TaskController(IUnitOfwork unitOfwork)
        {
            _unitOfWork = unitOfwork;
            TaskRepository = new TaskRepository(_unitOfWork, "crud");
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Task>>> GetTasks()
        {

            var taskRsult = await TaskRepository.Get();
            return taskRsult;

        }

        [HttpPost]
        public async Task<ActionResult<Models.Task>> CreateTask(TaskDao taskDao)
        {
            Models.Task task = new Models.Task();
            task.Title = taskDao.Title;
            task.Description = taskDao.Description;
            task.DueDate = taskDao.DueDate;
            task.StatusNo = taskDao.StatusNo;
            task.AssigneeNo = taskDao.AssigneeNo;
            var categories = await TaskRepository.Create(task);
                return categories;
                      
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var categories = await TaskRepository.Delete(id);
            return categories;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskDao taskDao)
        {
            Models.Task task = new Models.Task();
            task.Title = taskDao.Title;
            task.Description = taskDao.Description;
            task.DueDate = taskDao.DueDate;
            task.StatusNo = taskDao.StatusNo;
            task.AssigneeNo = taskDao.AssigneeNo;
            var categories = await TaskRepository.Update(id, task); ;
            return categories;
        }

        [HttpGet("download")]
        public  FileResult Download(CancellationToken ct)
        {
            var tasks =  TaskRepository.GetFile(ct);
            var file = ExcelHelper.CreateFile(tasks);
           return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "tasks.xlsx");
        }
    }
}
