using Attendance_system.Model;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;


namespace Attendance_system.Service
{
    public class EmailService
    {
        private readonly EmailSendSetting _emailSendSetting;

        public EmailService(EmailSendSetting emailSendSetting)
        {
            _emailSendSetting = emailSendSetting;
        }

        // vorbereitung der E-Mail und asynchrone Versendung
        public async Task<bool> SendActivationCodeAsync(string recipientEmail, string activationCode)
        {
            MailMessage mailMessage = new MailMessage
            {
                Subject = "Confirmed code",
                From = new MailAddress(_emailSendSetting.email),
                Body = $"Hier is your confirmed code: {activationCode}"
            };
            mailMessage.To.Add(recipientEmail);

            // Asyncrone Sendung
            return await SendEmailAsync(mailMessage);
        }

        // Asyncrone E-Mail Sendung
        private async Task<bool> SendEmailAsync(MailMessage mailMessage)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient(_emailSendSetting.smtpServer, _emailSendSetting.port))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential(_emailSendSetting.email, _emailSendSetting.password);

                    // Asynchrone Sendung mit await
                    await smtpClient.SendMailAsync(mailMessage);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Senden der E-Mail: {ex.Message}");
                return false;
            }
        }


    }
}
