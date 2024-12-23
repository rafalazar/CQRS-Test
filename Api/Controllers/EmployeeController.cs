using Api.Helpers;
using Application.Employees.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("employees")]
[ApiController]
public class EmployeeController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult> Find([FromQuery] FindQuery query)
    {
        try
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            var errorResponse = ResponseHelper.Error("500", ex.Message, null);
            return BadRequest(errorResponse);
        }
    }
}