using System;
using System.Net;
using System.Net.Mail;

namespace Liftoff.Logging
{
    internal interface ISendEmail
    {
        void Send(MailMessage message);
    }

    internal class EmailSender : ISendEmail
    {
        private readonly SmtpClient _client;

        public EmailSender(SmtpOptions options)
        {
            if (options.UseDefaultCredentials)
                _client = new SmtpClient(options.Host) { UseDefaultCredentials = true };
            else if (!String.IsNullOrEmpty(options.UserName) && !String.IsNullOrEmpty(options.Password))
                _client = new SmtpClient(options.Host) { Credentials = new NetworkCredential(options.UserName, options.Password) };
            else
                _client = new SmtpClient(options.Host);
        }

        public void Send(MailMessage message)
        {
            _client.Send(message);
        }
    }
}