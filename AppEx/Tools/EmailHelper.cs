using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppEx.Tools
{
    public class EmailHelper
    {
        SmtpClient client;

        private readonly string email = "asanateam.az@gmail.com";
        private readonly string password = "asana12345";



        public EmailHelper()
        {
            client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(email, password);
        }
        public void SendRegisterActivationCode(string receiver, string sender = "asanateam.az@gmail.com")
        {
            try
            {
                MailMessage mailMessage = new MailMessage(sender, receiver, "Register Activation Code!", HtmlParser.InsertInto('^', FileHelper.FindFile("//Resources//confirmationCode.html")));

                mailMessage.IsBodyHtml = true;
                client.Send(mailMessage);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
