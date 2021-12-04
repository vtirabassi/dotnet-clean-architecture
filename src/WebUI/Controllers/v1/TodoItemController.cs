using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebUI.Model;

namespace WebUI.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/products")]
public class TodoItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateItem(TodoItemViewModel request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var command = request.ToCommand();
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var command = new GetAllTodoItemCommand();

        return Ok(await _mediator.Send(command, cancellationToken));
    }

}
