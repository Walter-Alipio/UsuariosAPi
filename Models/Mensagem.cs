using MimeKit;

namespace UsuariosAPI.Models
{
  public class Mensagem
  {
    public List<MailboxAddress> Destinatarios { get; set; }
    public string Assunto { get; set; }
    public string Conteudo { get; set; }


    public Mensagem(IEnumerable<string> destinatario, string assunto, int usuarioId, string code)
    {
      Destinatarios = new List<MailboxAddress>();
      Destinatarios.AddRange(destinatario.Select(d =>
      {
        string[] userName = d.Split("@");
        return new MailboxAddress(userName[0], d);
      }));
      Assunto = assunto;
      //construindo link de ativação que será enviado no email
      Conteudo = $"https://localhost:7299/ativa?UsuarioId={usuarioId}&CodigoAtivacao={code}";
    }
  }
}