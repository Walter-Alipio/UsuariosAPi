using System.ComponentModel.DataAnnotations;

public class CreateUsuarioDTO
{
  [Required]
  public string Username { get; set; }

  [Required]
  public string Email { get; set; }

  [Required]
  [DataType(DataType.Password)]
  public string Password { get; set; }


  [Required, Compare("Password")]
  public string RePassword { get; set; }
}