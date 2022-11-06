using System.Linq;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Request;
using UsuariosAPI.Data.UsuarioDTO;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{

  [ApiController]
  [Route("[controller]")]
  public class CadastroController : ControllerBase
  {
    private CadastroService _cadastroService;

    public CadastroController(CadastroService cadastroService)
    {
      _cadastroService = cadastroService;
    }

    [HttpPost]
    public IActionResult AddUsuario(CreateUsuarioDTO usuarioDTO)
    {
      Result resultado = _cadastroService.AddUsuario(usuarioDTO);

      if (resultado.IsFailed)
      {
        return StatusCode(500, resultado.Errors.FirstOrDefault());
      }
      return Ok(resultado.Successes.FirstOrDefault());
    }

    [HttpGet("/ativa")]
    public IActionResult AtivaContaUsuario([FromQuery] AtivaContaRequest request)
    {
      Result resultado = _cadastroService.AtivaContaUsuario(request);
      if (resultado.IsFailed) return StatusCode(500, resultado.Errors.SingleOrDefault());

      return Ok(resultado.Successes.FirstOrDefault());
    }
  }
}