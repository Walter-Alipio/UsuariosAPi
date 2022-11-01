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
  }
}