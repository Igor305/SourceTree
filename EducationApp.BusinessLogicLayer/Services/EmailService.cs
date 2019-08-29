﻿using EducationApp.BusinessLogicLayer.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.BusinessLogicLayer.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmail(string email, string subject, string body)
        {
            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential();
                credential.UserName = "xlamarx66@gmail.com";
                credential.Password = "kloyn5655396";

                client.Credentials = credential;
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;

                using (var emailMessage = new MailMessage())
                {
                    var mailAddress = new MailAddress(email);
                    emailMessage.To.Add(mailAddress);
                    emailMessage.From = new MailAddress("xlamarx66@gmail.com");
                    emailMessage.Subject = subject;
                    emailMessage.IsBodyHtml = true;
                    emailMessage.Body = body;

                    client.Send(emailMessage);
                }
            }
            await Task.CompletedTask;
        }
    }
}