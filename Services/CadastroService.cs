using System.Web;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Request;
using UsuariosAPI.Data.UsuarioDTO;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
  public class CadastroService
  {
    private IMapper _mapper;
    private UserManager<IdentityUser<int>> _userManager;
    private EmailService _emailService;
    private RoleManager<IdentityRole<int>> _roleManager;

    public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
    {
      _mapper = mapper;
      _userManager = userManager;
      _emailService = emailService;
      _roleManager = roleManager;
    }

    public Result AddUsuario(CreateUsuarioDTO usuarioDTO)
    {
      Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);
      IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
      //cadastrando um usuario através do UserManager do Identity
      var resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, usuarioDTO.Password).Result;

      //Criando a role do usuário
      _userManager.AddToRoleAsync(usuarioIdentity, "regular");

      if (resultadoIdentity.Succeeded)
      {
        //cria um código de confirmação
        var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity);
        var encodedCode = HttpUtility.UrlEncode(code.Result);

        _emailService.EnviarEmail(new[] { usuarioIdentity.Email }, "Link de Ativação", usuarioIdentity.Id, encodedCode);

        return Result.Ok().WithSuccess(code.Result);//envia o código junto com a resposta.
      }

      return Result.Fail("Falha ao cadastrar");
    }

    public Result AtivaContaUsuario(AtivaContaRequest request)
    {
      //identifica o usuário pelo id
      var identityUser = _userManager.Users.FirstOrDefault(
        user => user.Id == request.UsuarioId
      );

      var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoAtivacao).Result;

      if (identityResult.Succeeded) return Result.Ok();

      return Result.Fail("Falha ao ativar conta de usuário.");
    }
  }
}