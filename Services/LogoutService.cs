using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UsuariosAPI.Services
{
  public class LogoutService
  {
    private SignInManager<IdentityUser<int>> _signInManager;

    public LogoutService(SignInManager<IdentityUser<int>> signInManager)
    {
      _signInManager = signInManager;
    }

    public Result DeslogaUsuario()
    { //metodo do Identity para realizar logout
      var resultadoIdentity = _signInManager.SignOutAsync();

      if (resultadoIdentity.IsCompletedSuccessfully) return Result.Ok();

      return Result.Fail("Logout falhou!");
    }
  }
}