using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keycloak.Lab.Controllers
{
  [ApiController]
  [Route("[controller]/[action]")]
  public class AuthRolesTestController : ControllerBase
  {

    private readonly ILogger<AuthRolesTestController> _logger;

    public AuthRolesTestController(ILogger<AuthRolesTestController> logger)
    {
      _logger = logger;
    }

    [Authorize(Policy ="Reader")]
    [HttpGet]
    public IActionResult ReadersOnly()
    {
      return Ok($"{nameof(ReadersOnly)} worked!");
    }

    [Authorize(Policy ="Writer")]
    [HttpPost]
    public IActionResult WritersOnly()
    {
      return Ok($"{nameof(WritersOnly)} worked!");
    }

    [Authorize(Policy ="Admin")]
    [HttpDelete]
    public IActionResult AdminsOnly()
    {
      return Ok($"{nameof(AdminsOnly)} worked!");
    }
  }
}
