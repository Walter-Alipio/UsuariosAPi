using AutoMapper;
using Microsoft.AspNetCore.Identity;

public class UsuarioProfile : Profile
{
  public UsuarioProfile()
  {
    CreateMap<CreateUsuarioDTO, Usuario>();
    CreateMap<Usuario, IdentityUser<int>>();
  }
}