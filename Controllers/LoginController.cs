using System.Linq;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Request;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class LoginController : Controller
  {
    private LoginService _loginService;

    public LoginController(LoginService loginService)
    {
      _loginService = loginService;
    }

    [HttpPost]
    public IActionResult LogaUsuario(LoginRequest loginRequest)
    {
      Result resultado = _loginService.LogaUsuario(loginRequest);
      if (resultado.IsFailed) return Unauthorized(resultado.Errors.FirstOrDefault());

      return Ok(resultado.Successes.FirstOrDefault());//FirsOrDefault trás a menssagem de sucesso.
    }

    [HttpPost("/solicita-reset")]
    public IActionResult SolicitaReseteSenhaUsuario(SolicitaReseteRequest request)
    {
      Result result = _loginService.SolicitaReseteSenhaUsuario(request);
      if (result.IsFailed) return Unauthorized(result.Errors.ToList());

      return Ok(result.Successes.FirstOrDefault());
    }

    [HttpPost("/efetua-reset")]
    public IActionResult ResetaSenhaUsuario(EfetuaResetRequest request)
    {
      Result result = _loginService.ResetaSenhaUsuario(request);
      if (result.IsFailed) return Unauthorized(result.Errors.ToList());

      return Ok(result.Successes.FirstOrDefault());
    }
  }
}