using FluentResults;
using Microsoft.AspNetCore.Identity;

public class LoginService
{
  private SignInManager<IdentityUser<int>> _signInManager;

  public LoginService(SignInManager<IdentityUser<int>> signInManager)
  {
    _signInManager = signInManager;
  }

  public Result LogaUsuario(LoginRequest loginRequest)
  {
    //metodo do Identity para efetuar login
    var resultadoIdentity = _signInManager.PasswordSignInAsync(
      loginRequest.UserName, loginRequest.Password, false, false
    );

    if (resultadoIdentity.Result.Succeeded) return Result.Ok();

    return Result.Fail("Login falhou!");
  }
}