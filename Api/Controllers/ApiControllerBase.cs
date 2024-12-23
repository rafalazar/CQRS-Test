using Api.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Api.Controllers;

public abstract class ApiControllerBase : ControllerBase
{
    private ISender _mediator = null!;
    
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();

    public override OkObjectResult Ok([ActionResultObjectValue] object? value)
    {
        return base.Ok(ResponseHelper.Success(value));
    }

    public override CreatedAtActionResult CreatedAtAction(string? actionName, object? routeValues, [ActionResultObjectValue] object? value)
    {
        return base.CreatedAtAction(actionName, routeValues, ResponseHelper.Success(value, "201", "Recurso creado exitosamente"));
    }
}