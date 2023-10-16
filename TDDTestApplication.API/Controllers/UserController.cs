using Microsoft.AspNetCore.Mvc;
using TDDTestApplication.BusinessLayer.Services.Interfaces;

namespace TDDTestApplication.API.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("getusers")]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _userService.GetUsersAsync(cancellationToken));
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }
}