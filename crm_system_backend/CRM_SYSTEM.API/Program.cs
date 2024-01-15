using CRM_SYSTEM.BLL.Interfaces;
using CRM_SYSTEM.BLL.Services;
using CRM_SYSTEM.DAL.Data;
using CRM_SYSTEM.DAL.Helpers;
using CRM_SYSTEM.DAL.Interfaces;
using CRM_SYSTEM.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_allowall";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseMySQL(connectionString!));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRatingRepostitory, RatingRepository>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<IDebtsRepository, DebtsRepository>();
builder.Services.AddScoped<IDebtsService, DebtsService>();
builder.Services.AddScoped<ValidateHelper>();
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
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthorization();

app.MapControllers();

app.Run();
