using ApiProject;
using ApiProject.Models;
using ApiProject.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("CS");
builder.Services.AddControllers();
builder.Services.AddScoped<IDeptRepo, DeptRepo>();
builder.Services.AddIdentity<AppUser , IdentityRole>().AddEntityFrameworkStores<ITIContext>();
builder.Services.AddDbContext<ITIContext>(optionbuilder =>
{
    optionbuilder.UseSqlServer(connectionString);
});
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
