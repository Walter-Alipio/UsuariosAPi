using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.UsuarioDTO;
using UsuariosAPI.Models;

namespace UsuariosAPI.Profiles
{
  public class UsuarioProfile : Profile
  {
    public UsuarioProfile()
    {
      CreateMap<CreateUsuarioDTO, Usuario>();
      CreateMap<Usuario, IdentityUser<int>>();
      CreateMap<Usuario, CustomIdentityUser>();
    }
  }
}