using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace CommonLayer.Model
{
    public class MSMQModel
    {
        MessageQueue messageQueue= new MessageQueue();
        private string recieverEmailAddr;
        private string recieverName;

        public void SendMessage(string token, string emailId, string name)
        {
            recieverEmailAddr = emailId;
            recieverName = name;
            messageQueue.Path = @".\Private$\Token";
            try
            {
                if (!MessageQueue.Exists(messageQueue.Path))
                {
                    MessageQueue.Create(messageQueue.Path);
                }
                messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                messageQueue.ReceiveCompleted += MessageQueue_ReceiveCompleted;
                messageQueue.Send(token);
                messageQueue.BeginReceive();
                messageQueue.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void MessageQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)

        {
            try
            {
                var msg = messageQueue.EndReceive(e.AsyncResult);
                string token = msg.Body.ToString();
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential("sakshijjadhav28@gmail.com", "wain iffc gquh ckxj"),
                };
                mailMessage.From = new MailAddress("sakshijjadhav28@gmail.com");
                mailMessage.To.Add(new MailAddress(recieverEmailAddr));
                string mailbody = $"<html>" +
                  $"<style>" +
                  $".blink {{ /* Define your CSS class */ }}" +
                  $"</style>" +
                  $"<body style=\"background-color:#DBFF73;text-align:center;padding:5px;'>" +
                  $"<h1 style=\"color:#6A8D02;border-bottom:3px solid #84AF08; margin-top:5px;'> Dear <b>{recieverName}</b></h1>\n" +
                  $"<h3 style=\"color:#8AB411;'> FOR Resetting Password, the Below Link is Issued </h3>" +
                  $"<h3 style=\"color:#8AB411;'> Please Click the link To Reset  Your Password </h3>" +
                  $"<a style =\"color:#00802b; text-decoration: none;font-size:20px;\" href= 'https://localhost:4200/resetpassword/{token}'>click me </a>\n" +
                  $"<h3 style =\"color:#8AB411;margin-botton:5px;\"><blink>this token will be valid for next 6 hours<blink></h3>" +
                  $"</body>" +
                  $"</html>";


                mailMessage.Body = mailbody;
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = "Fundo Notes Password Reset Link";
                smtpClient.Send(mailMessage);
            }
            catch(Exception ex)
            {
                throw ex;
            }







        }
    }
}


