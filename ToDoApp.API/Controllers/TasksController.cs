using Ardalis.Result.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.DTOs;
using ToDo.Application.Features.Tasks.Commands.CreateTask;
using ToDo.Application.Features.Tasks.Commands.DeleteTask;
using ToDo.Application.Features.Tasks.Commands.UpdateTask;
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

        [HttpGet("user-tasks")]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetUserTasks()
        {
            //by implementing TokenBasedAuthentication, RequestSenderUserId will get it's value from auth token, to make sure every user can only manage his own tasks
            var request = new GetTasksByUserIdRequest() { RequestSenderUserId = Guid.Parse("1C48F7A0-2DBC-42D8-B31C-E53B6B2244B5") };
            var response = await _mediator.Send(request);

            return response.ToActionResult(this);
        }

        [HttpPost("add")]
        public async Task<ActionResult<bool>> AddTask([FromBody] CreateTaskDTO model)
        {
            //by implementing TokenBasedAuthentication, RequestSenderUserId will get it's value from auth token, to make sure every user can only manage his own tasks
            var request = new CreateTaskRequest() { RequestSenderUserId = Guid.Parse("1C48F7A0-2DBC-42D8-B31C-E53B6B2244B5"), CreateTaskDTO = model };
            var response = await _mediator.Send(request);

            return response.ToActionResult(this);
        }

        [HttpPut("update")]
        public async Task<ActionResult<bool>> UpdateTask([FromBody] UpdateTaskDTO model)
        {
            //by implementing TokenBasedAuthentication, RequestSenderUserId will get it's value from auth token, to make sure every user can only manage his own tasks
            var request = new UpdateTaskRequest() { RequestSenderUserId = Guid.Parse("1C48F7A0-2DBC-42D8-B31C-E53B6B2244B5"), UpdateTaskDTO = model };
            var response = await _mediator.Send(request);

            return response.ToActionResult(this);
        }

        [HttpDelete("delete/{taskID}")]
        public async Task<ActionResult<bool>> DeleteTask([FromRoute] Guid taskID)
        {
            //by implementing TokenBasedAuthentication, RequestSenderUserId will get it's value from auth token, to make sure every user can only manage his own tasks
            var request = new DeleteTaskRequest() { RequestSenderUserId = Guid.Parse("1C48F7A0-2DBC-42D8-B31C-E53B6B2244B5"), TaskId = taskID };
            var response = await _mediator.Send(request);

            return response.ToActionResult(this);
        }
    }
}
