using Infrasture.Repo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitApiTests
{

    // <snippet1>
    public class CustomWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
    {


        //protected override IHost CreateHost(IHostBuilder builder)
        //{
        //    builder.ConfigureServices(services =>
        //    {
        //        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

        //        if (descriptor != null)
        //        {
        //            services.Remove(descriptor);
        //        }

        //        services.AddDbContext<ApplicationDbContext>(options =>
        //        {
        //            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        //            options.UseSqlite($"Data Source={Path.Join(path, "WebMinRouteGroup_tests.db")}");
        //        });

               
        //    });

        //    return base.CreateHost(builder);
        //}


        //protected override void ConfigureWebHost(IWebHostBuilder builder)
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<ApplicationDbContext>));

                if (dbContextDescriptor != null)  services.Remove(dbContextDescriptor);

                // Create open SqliteConnection so EF won't automatically close it.
                services.AddSingleton<DbConnection>(container =>
                {
                    var connection = new SqliteConnection("DataSource=:memory:");
                    connection.Open();

                    return connection;
                });

                services.AddDbContext<ApplicationDbContext>((container, options) =>
                {
                    var connection = container.GetRequiredService<DbConnection>();
                    options.UseSqlite(connection);
                });
            });

            return base.CreateHost(builder);
        }
    }
}
