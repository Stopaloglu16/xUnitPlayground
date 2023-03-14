using CoreDomain.Entity;
using Infrasture.Repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddDbContext<ApplicationDbContext>(options =>
  //                 options.UseInMemoryDatabase("TestDb"));


// Add services to the container.

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));

//builder.Services.AddScoped<IPersonRepository, PersonRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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

