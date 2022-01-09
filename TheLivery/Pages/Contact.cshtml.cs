/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;


string to = "toaddress@gmail.com"; //To address    
string from = "fromaddress@gmail.com"; //From address    
MailMessage message = new MailMessage(from, to);

string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
message.Subject = "Sending Email Using Asp.Net & C#";
message.Body = mailbody;
message.BodyEncoding = Encoding.UTF8;
message.IsBodyHtml = true;
SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
System.Net.NetworkCredential basicCredential1 = new
System.Net.NetworkCredential("plesclaudiuu@gmail.com", "ehwkqcbohmcthczc");
client.EnableSsl = true;
client.UseDefaultCredentials = false;
client.Credentials = basicCredential1;
try
{
    client.Send(message);
}

catch (Exception ex)
{
    throw ex;
}*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace TheLivery.Pages
{
    public class ContactModel : PageModel
    {
        public string nume { get; set; }
        public string email { get; set; }
        public string intrebare { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            nume = Request.Form["nume"];
            email = Request.Form["email"];
            intrebare = Request.Form["intrebare"];

            string to = "plesclaudiuu@gmail.com"; //To address    
            string from = email; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = intrebare + " <br> Numele si email-ul:" + nume + " " + email;
            message.Subject = "Sending Email Using Asp.Net & C#";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("plesclaudiuu@gmail.com", "ehwkqcbohmcthczc");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
