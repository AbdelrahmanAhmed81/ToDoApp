using Ardalis.Result.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.DTOs;
using ToDo.Application.Features.Tasks.Commands.CreateTask;
using ToDo.Application.Features.Tasks.Commands.DeleteTask;
using ToDo.Application.Features.Tasks.Queries.GetTasksByUserId;

namespace ToDoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("user-tasks/{userId}")]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetUserTasks([FromRoute] Guid userId)
        {
            var request = new GetTasksByUserIdRequest() { UserId = userId };
            var response = await _mediator.Send(request);

            return response.ToActionResult(this);
        }

        [HttpPost("add")]
        public async Task<ActionResult<bool>> AddTask([FromBody] CreateTaskDTO model)
        {
            var request = new CreateTaskRequest() { CreateTaskDTO = model };
            var response = await _mediator.Send(request);

            return response.ToActionResult(this);
        }

        [HttpDelete("delete/{taskID}")]
        public async Task<ActionResult<bool>> DeleteTask([FromRoute] Guid taskID)
        {
            var request = new DeleteTaskRequest() { TaskId = taskID };
            var response = await _mediator.Send(request);

            return response.ToActionResult(this);
        }
    }
}
