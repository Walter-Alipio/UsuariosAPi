using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;

public class CadastroService
{
  private IMapper _mapper;
  private UserManager<IdentityUser<int>> _userManager;

  public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
  {
    _mapper = mapper;
    _userManager = userManager;
  }

  public Result AddUsuario(CreateUsuarioDTO usuarioDTO)
  {
    Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);
    IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
    //cadastrando um usuario através do UserManager do Identity
    Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, usuarioDTO.Password);

    if (resultadoIdentity.Result.Succeeded) return Result.Ok();

    return Result.Fail("Falha ao cadastrar");
  }
}