using BLL.services;
using DAL.Data;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =====SQL======
builder.Services.AddDbContext<AppDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//=====DAL Repositories=====
builder.Services.AddScoped<IListRepository, ListRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//=====BLL Services=====
builder.Services.AddScoped<IListService, ListService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
