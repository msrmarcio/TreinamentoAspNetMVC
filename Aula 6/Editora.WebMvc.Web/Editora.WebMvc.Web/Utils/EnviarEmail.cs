using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// importamos a classe responsavel por envio de email
using System.Net.Mail;


namespace Editora.WebMvc.Web.Utils
{
    public class EnviarEmail
    {
        SmtpClient smtpClient;
        MailAddress from;
        MailAddress to;
        MailMessage mailMessage;

        /// <summary>
        /// construtor da classe responsavel por enviar email
        /// </summary>
        /// <param name="emailFrom">e-mail de origem remetente</param>
        /// <param name="nameFrom">nome do remetente</param>
        /// <param name="emailTo">Destinatario</param>
        /// <param name="message">Mensagem do email</param>
        /// <param name="subject">Assunto email</param>
        public EnviarEmail(string emailFrom, string nameFrom, string emailTo, 
                       string message, string subject)
        {
            // vamos instanciar os objetos no momento da execução do construtor
            // objeto responsavel por enviar o email
            smtpClient = new SmtpClient();
            
            // objeto que contem o email de origem
            from = new MailAddress(emailFrom, nameFrom, System.Text.Encoding.UTF8);
            
            // objeto para conter email destino
            to = new MailAddress(emailTo);
            
            // a mensagem completa com From, To e message
            mailMessage = new MailMessage(from, to);
            
            // mensagem
            mailMessage.Body = message;
            
            // assunto
            mailMessage.Subject = subject;
        }

        public void Send()
        {
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
            smtpClient.UseDefaultCredentials = false; // vamos utilizar credencias especificas
            smtpClient.EnableSsl = true; // GMail requer SSL
            // YAHOO: SMTP.MAIL.YAHOO.COM // porta: 465
            // GMAIL: smtp.gmail.com  // porta: 587 ou 465
            smtpClient.Host = "smtp.live.com";
            smtpClient.Port = 587;       // porta para SSL

            // credenciais de login no email
            var credenciais =  new System.Net.NetworkCredential("msrmarcio@hotmail.com", "Whois@2013");
            smtpClient.Credentials = credenciais;

            // envia o email
            smtpClient.Send(mailMessage);
        }
          

    }
}