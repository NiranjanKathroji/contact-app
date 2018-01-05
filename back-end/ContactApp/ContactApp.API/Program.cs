using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ContactApp.Data.Initializer;

namespace ContactApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            //.MigrateDb();

            // Migrate and seed the database first before running Startup. 
            ContactAppDbInitializer.Initialize(host.Services);

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        //public static IWebHost MigrateDb(this IWebHost webhost)
        //{
        //    using (var scope = webhost.Services.GetService<IServiceScopeFactory>().CreateScope())
        //    {
        //        using (var dbContext = scope.ServiceProvider.GetRequiredService<ContactAppContext>())
        //        {
        //            dbContext.Database.Migrate();
        //        }
        //    }
        //    return webhost;
        //}
    }
}
