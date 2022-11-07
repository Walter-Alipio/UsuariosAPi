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
    public Token CreateToken(CustomIdentityUser usuario, string? role)
    {
      Claim[] direitorUsuario = new Claim[]
      {
        new Claim("username", usuario.UserName),
        new Claim("id",usuario.Id.ToString()),
        new Claim(ClaimTypes.Role, role),
        new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString())
      };

      //cria uma chave a partir de um array de bytes
      var chave = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn")
      );
      //cria uma credencial encriptada a partir de uma chave
      var credentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
      //cria o toke com os direitos do usuario, credenciais e tempo de expiração da chave.
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