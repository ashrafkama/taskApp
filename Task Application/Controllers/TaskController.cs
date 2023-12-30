

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Application.Helper;
using Task_Application.Models;

namespace Task_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly taskappdbContext _context;
        private readonly IEmailSender _emailSender;



        public TaskController(taskappdbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IEnumerable<Models.Task>> Get()
        {
            return await _context.Tasks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return BadRequest();
            var selectTask = await _context.Tasks.FirstOrDefaultAsync(m => m.Id == id);
            if (selectTask == null)
                return NotFound();
            return Ok(selectTask);

        }

        [HttpPost]
        public async Task<IActionResult> Post(Models.TaskDao taskDao)
        {
            var task = new Models.Task();
            task.Title = taskDao.Title;
            task.Description = taskDao.Description;
            task.DueDate = taskDao.DueDate;
            task.StatusNo = taskDao.StatusNo;
            task.AssigneeNo = taskDao.AssigneeNo;
            _context.Add(task);
            await _context.SaveChangesAsync();
            var selectAssignee = await _context.Assignees.FirstOrDefaultAsync(m => m.Id == task.AssigneeNo);
            if (selectAssignee != null && selectAssignee.Email != null)
                _emailSender.SendEmail(selectAssignee.Email, "New Task");
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Models.TaskDao task,int id)
        {
            if (task == null || id == 0)
                return BadRequest();

            var selectTask = await _context.Tasks.FindAsync(id);
            if (selectTask == null)
                return NotFound();
            selectTask.Title = task.Title;
            selectTask.Description = task.Description;
            selectTask.AssigneeNo = task.AssigneeNo;
            selectTask.DueDate =   task.DueDate;
            selectTask.StatusNo = task.StatusNo;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            var selectTask = await _context.Tasks.FindAsync(id);
            if (selectTask == null)
                return NotFound();
            _context.Tasks.Remove(selectTask);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpGet("download")]
        public async Task<FileResult> Download(CancellationToken ct)
        {
            var tasks = await _context.Tasks.ToListAsync(ct);
            var file = ExcelHelper.CreateFile(tasks);
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "tasks.xlsx");
        }
        

    }


}
