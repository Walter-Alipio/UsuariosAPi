using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Request
{
  public class SolicitaReseteRequest
  {
    [Required]
    public string Email { get; set; }
  }
}