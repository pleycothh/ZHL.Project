using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Routing.Template;
using System.Net.Mail;
using System.Text;
using ZHL.Library.Models;

namespace ZHL.GUI.Provider
{
    public class EmailerProvider
    {
        

        public static async Task Sender(EmailClientModel emailClient)
        {
            var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
                /// should be true for production -> should in app.seeting .json
                EnableSsl = false,
                /// put file in directory
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 25
            });

            StringBuilder template = new();
            template.AppendLine("Dear @Model.FirsName,");
            template.AppendLine("<p> Thanks for purchasing @Model.productName. we home you like it </P>");
            template.AppendLine("- The TimCo Team");


            /// Apply the sender settings when call Email
            Email.DefaultSender = sender;
            Email.DefaultRenderer = new RazorRenderer();

            /// here is client now
            var email = await Email
                .From("ben.li19930119@gmail.com")
                .To("test@test.com", "Nicer Name")
                .Subject("Thanks!")
                .UsingTemplate(template.ToString(), new {FirstName = "Ben", productName = "Ball"})
                //.Body("Body")
                .SendAsync();

            if (email.ErrorMessages is not null)
                Console.WriteLine(email.ErrorMessages);
        }



    }
}
