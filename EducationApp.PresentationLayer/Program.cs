﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EducationApp.BusinessLogicLayer.Models.Autors;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.PresentationLayer.Controllers.Base;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EducationApp.PresentationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
              CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
