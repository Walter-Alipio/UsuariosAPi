using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Request;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
  public class LoginService
  {
    private SignInManager<IdentityUser<int>> _signInManager;
    private TokenService _tokeService;

    public LoginService(TokenService tokeService, SignInManager<IdentityUser<int>> signInManager)
    {
      _tokeService = tokeService;
      _signInManager = signInManager;
    }

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

      if (resultadoIdentity.Result.Succeeded)
      {
        var IdentityUser = _signInManager.UserManager.Users
        .FirstOrDefault(
          usuario =>
          usuario.NormalizedUserName == loginRequest.UserName.ToUpper()
        );
        Token token = _tokeService.CreateToken(IdentityUser);
        return Result.Ok().WithSuccess(token.Value);
      }

      return Result.Fail("Login falhou!");
    }
  }
}