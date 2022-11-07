using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
  public class LogoutService
  {
    private SignInManager<CustomIdentityUser> _signInManager;

    public LogoutService(SignInManager<CustomIdentityUser> signInManager)
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