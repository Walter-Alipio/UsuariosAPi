using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class LogoutController : ControllerBase
  {
    public LogoutService _logoutService;

    public LogoutController(LogoutService logoutService)
    {
      _logoutService = logoutService;
    }

    [HttpPost]
    public IActionResult DeslogaUsuario()
    {
      Result resultado = _logoutService.DeslogaUsuario();
      if (resultado.IsFailed) return Unauthorized(resultado.Errors.FirstOrDefault());

      return Ok(resultado.Successes);
    }
  }
}