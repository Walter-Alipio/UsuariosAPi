using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using UsuariosAPI.Models;
using System.IdentityModel.Tokens.Jwt;

namespace UsuariosAPI.Services
{
  public class TokenService
  {
    public Token CreateToken(IdentityUser<int> usuario)
    {
      Claim[] direitorUsuario = new Claim[]
      {
        new Claim("username", usuario.UserName),
        new Claim("id",usuario.Id.ToString())
      };

      var chave = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes("")
      );

      var credentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        claims: direitorUsuario,
        signingCredentials: credentials,
        expires: DateTime.UtcNow.AddHours(1)
      );

      string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

      return new Token(tokenString);
    }
  }

}