using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using MailKit.Net.Smtp;
using ZHL.Library.Models;
using ZHL.GUI.Provider.Contracts;

namespace ZHL.GUI.Provider
{
    public class EmailerProvider : IEmailerProvider
    {

        private readonly IConfiguration _config;

        public EmailerProvider(IConfiguration config)
        {
            _config = config;
        }

        public async Task Sender(EmailClientModel emailClient)
        {  
               var email = new MimeMessage();
               email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
               email.To.Add(MailboxAddress.Parse(emailClient.To));
               email.Subject = emailClient.Subject;
               email.Body = new TextPart(TextFormat.Html) { Text = emailClient.Body };
           
               using var smtp = new SmtpClient();
               smtp.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
               smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
               smtp.Send(email);
               smtp.Disconnect(true);



        }

    //    [GoogleScopedAuthorize(DriveService.ScopeConstants.DriveReadonly)]
    //    public async Task AuthenticateAsync([FromServices] IGoogleAuthProvider auth)
    //    {
    //        GoogleCredential? googleCred = await _auth.GetCredentialAsync();
    //        string token = await googleCred.UnderlyingCredential.GetAccessTokenForRequestAsync();
    //
    //        var oauth2 = new SaslMechanismOAuth2("UserEmail", token);
    //
    //        using var emailClient = new ImapClient();
    //        await emailClient.ConnectAsync("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
    //        await emailClient.AuthenticateAsync(oauth2);
    //        await emailClient.DisconnectAsync(true);
    //    }
    }
}
