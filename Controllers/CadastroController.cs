using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CadastroController : ControllerBase
{

  [HttpPost]
  public IActionResult CadastroUsuario(CreateUsuarioDTO usuarioDTO)
  {
    return Ok();
  }
}