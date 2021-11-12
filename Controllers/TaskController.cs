using System;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tasks.Data;
using tasks.Mapper;
using tasks.Model;
using tasks.Services;

namespace tasks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;
        private readonly IStorageService _storage;
        private readonly TaskDbContext _context;

        public TasksController(ILogger<TasksController> logger, IStorageService storage, TaskDbContext context)
        {
            _logger = logger;
            _storage = storage;
            _context = context;
        }


        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateTask([FromBody][FromRoute]NewTask newTask)
        {
            var taskEntity = newTask.ToTaskEntity();
            var insertResult = await _storage.InsertTaskAsync(taskEntity);

            if(insertResult.IsSuccess)
            {
                return CreatedAtAction("CreateTask", taskEntity);
            }

            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = insertResult.exception.Message });
        }

        [HttpGet]
        public async Task<IActionResult> QueryTasks([FromQuery][FromRoute]TaskQuery query)
        {
            var tasks = await _storage.GetTasksAsync(title: query.Title, id: query.Id);

            if(tasks.Any())
            {
                return Ok(tasks);
            }

            return NotFound("No tasks exist!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTaskAsync([FromBody]UpdatedTask updatedTask)
        {
            var entity = updatedTask.ToTaskEntity();
            var updateResult = await _storage.UpdateTaskAsync(entity);

            if(updateResult.isSuccess)
            {
                return Ok();
            }

            return BadRequest(updateResult.exception.Message);
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> RemoveTaskAsync([FromRoute]Guid Id)
        {
            var deletedResult = await _storage.RemoveTaskAsync(Id);

            if(deletedResult.isSuccess)
            {
                return Ok();
            } 

            return NotFound(deletedResult.exception.Message);
        }
    }
}