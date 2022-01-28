using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP1.Domain.Context;
using XmlAndJsonApp.Repositories;
using XmlAndJsonApp.Services;

namespace XmlAndJsonApp
{
    internal static class Program
    {

        public static IServiceProvider ServiceProvider { get; set; }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IJsonService, JsonService>();
            services.AddTransient<IXmlService, XmlService>();
            services.AddTransient<IFileRepository, FileRepository>();
            services.AddDbContext<DataContext>();
            ServiceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();
            Application.Run(new Form1());
        }

      
    }
}
