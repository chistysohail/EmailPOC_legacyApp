using System;
using System.Net;
using System.Net.Mail;

namespace EmailPOC_legacyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // SMTP server details
            string smtpServer = "your.smtp.server";
            int smtpPort = 587; // Usually 25, 465, or 587
            string smtpUsername = "your-username";
            string smtpPassword = "your-password";

            // Email details
            string fromEmail = "your-email@domain.com";
            string toEmail = "recipient@domain.com";
            string subject = "Subject of the email";
            string body = "Body of the email";

            SendEmail(smtpServer, smtpPort, smtpUsername, smtpPassword, fromEmail, toEmail, subject, body);
        }

        public static void SendEmail(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword, string fromEmail, string toEmail, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient(smtpServer);

                mail.From = new MailAddress(fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;

                smtpClient.Port = smtpPort;
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true; // Use SSL if the server supports it

                smtpClient.Send(mail);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}
