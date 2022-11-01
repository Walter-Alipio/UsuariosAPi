using FluentResults;
using Microsoft.AspNetCore.Mvc;

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
    if (resultado.IsFailed) return Unauthorized();

    return Ok();
  }
}