using System.Linq;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Request;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
  public class LoginService
  {
    private SignInManager<CustomIdentityUser> _signInManager;
    private TokenService? _tokeService;

    public LoginService(TokenService tokeService, SignInManager<CustomIdentityUser> signInManager)
    {
      _tokeService = tokeService;
      _signInManager = signInManager;
    }

    public LoginService(SignInManager<CustomIdentityUser> signInManager)
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

        Token token = _tokeService
          .CreateToken(IdentityUser, _signInManager
            .UserManager.GetRolesAsync(IdentityUser).Result.FirstOrDefault());
        return Result.Ok().WithSuccess(token.Value);

      }

      return Result.Fail("Login falhou!");
    }

    public Result ResetaSenhaUsuario(EfetuaResetRequest request)
    {
      CustomIdentityUser? identytiUser = RecuperaUsuarioPorEmail(request.Email);
      IdentityResult resultadoIdentity = _signInManager.UserManager
        .ResetPasswordAsync(identytiUser, request.Token, request.Password)
        .Result;
      if (resultadoIdentity.Succeeded)
      {
        return Result.Ok().WithSuccess("Senha redefinida com sucesso!");
      }

      return Result.Fail("Houve um erro na operação");
    }

    public Result SolicitaReseteSenhaUsuario(SolicitaReseteRequest request)
    {
      CustomIdentityUser? identytiUser = RecuperaUsuarioPorEmail(request.Email);
      if (identytiUser != null)
      {
        string codigoRecuperacao = _signInManager.UserManager
          .GeneratePasswordResetTokenAsync(identytiUser).Result;
        return Result.Ok().WithSuccess(codigoRecuperacao);
      }

      return Result.Fail("Falha ao solicitar redefinição");
    }

    private CustomIdentityUser? RecuperaUsuarioPorEmail(string email)
    {
      return _signInManager.UserManager.Users.FirstOrDefault(
              user => user.NormalizedEmail == email.ToUpper()
            );
    }
  }
}