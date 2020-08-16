using System;
using System.Net.Mail;
using LetsSuggest.Shared.Helper;
using Microsoft.Extensions.Options;

namespace LetsSuggest.Shared.Email
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<MessageTemplate> _messageTemplate;

        public EmailService(IOptions<MessageTemplate> messageTemplate)
        {
            _messageTemplate = messageTemplate;
        }
        public void SendMail(EmailMessage emailMessage)
        {
            if (string.IsNullOrEmpty(emailMessage.SendFrom))
                emailMessage.SendFrom = _messageTemplate.Value.MailFrom;
            if (string.IsNullOrEmpty(emailMessage.SenderName))
                emailMessage.SenderName = _messageTemplate.Value.MailSenderName;

            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("SMTP.office365.com");

            mail.From = new MailAddress(_messageTemplate.Value.MailFrom);

            foreach (string address in emailMessage.SendTo)
            {
                if (!string.IsNullOrEmpty(address) && !string.IsNullOrWhiteSpace(address))
                {
                    mail.To.Add(new MailAddress(address));
                }
            }
            mail.Subject = emailMessage.Subject;
            mail.Body = emailMessage.MessageBody;
            mail.IsBodyHtml = emailMessage.IsBodyHtml;
            if (!mail.IsBodyHtml)
            {
                mail.Body = mail.Body.Replace("\r\n", "\r");
                mail.Body = mail.Body.Replace("\r", "\r\n");
            }
            smtpServer.Port = Convert.ToInt32(_messageTemplate.Value.MailPort);
            smtpServer.Credentials = new System.Net.NetworkCredential(_messageTemplate.Value.MailFrom, _messageTemplate.Value.MailPassword);
            smtpServer.EnableSsl = true;

            smtpServer.Send(mail);


        }
    }

    public interface IEmailService
    {
        void SendMail(EmailMessage emailMessage);
    }
}
