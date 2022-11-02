
using MailKit.Net.Smtp;
using MimeKit;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
  public class EmailService
  {
    private IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    internal void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string code)
    {
      //mensagem que será enviada no por email
      Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, code);
      MimeMessage mensagemDeEmail = CriaCorpoDoEmail(mensagem);
      Enviar(mensagemDeEmail);
    }

    private void Enviar(MimeMessage mensagemDeEmail)
    {
      using (var client = new SmtpClient())
      {
        try
        {
          client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),
          _configuration.GetValue<int>("EmailSettings:Port"),
          MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
          client.AuthenticationMechanisms.Remove("XOAUTH2");
          client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"), _configuration.GetValue<string>("EmailSettings:Password"));

          client.Send(mensagemDeEmail);
        }
        catch (System.Exception)
        {

          throw;
        }
        finally
        {
          client.Disconnect(true);
          client.Dispose();
        }
      }
    }

    private MimeMessage CriaCorpoDoEmail(Mensagem mensagem)
    {
      MimeMessage mensagemDeEmail = new MimeMessage();
      mensagemDeEmail.From.Add(new MailboxAddress("AluraFilmes", _configuration.GetValue<string>("EmailSettings:From")));
      mensagemDeEmail.To.AddRange(mensagem.Destinatarios);
      mensagemDeEmail.Subject = mensagem.Assunto;
      mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
      {
        Text = mensagem.Conteudo
      };

      return mensagemDeEmail;
    }
  }
}