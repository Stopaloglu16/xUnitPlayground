using AutoMapper;
using CoreDomain.Entity;
using Infrasture.Repo;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data.Common;
using System.Reflection.PortableExecutable;
using WebApi.Controllers;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

//Add-Migration InitialWebCreate -Context Infrasture.Repo.ApplicationDbContext -project Src\Infrasture

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//            options.UseSqlite("DataSource=sqlitememory"));

//options.UseInMemoryDatabase("TestDb"));




//builder.Services.AddSingleton<DbConnection>(container =>
//{
//    var connection = new SqliteConnection("DataSource=:memory:");
//    connection.Open();

//    return connection;
//});

//builder.Services.AddDbContext<ApplicationDbContext>((container, options) =>
//{
//    var connection = container.GetRequiredService<DbConnection>();
//    options.UseSqlite(connection);
//});


//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
//    options.UseSqlite($"Data Source={Path.Join(path, "WebMinRouteGroup.db")}");
//});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// Add services to the container.

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();


builder.Services.AddAutoMapper(typeof(IPersonService ));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();


using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetService<ApplicationDbContext>();
await db?.Database.MigrateAsync();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-7.0
public partial class Program { }

