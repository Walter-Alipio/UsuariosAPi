using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//configurando bd
builder.Services.AddDbContext<UserDbContext>(opt
  => opt.UseMySql(builder.Configuration.GetConnectionString("UsuarioConnection"), new MySqlServerVersion(new Version(8, 0))));
//configurando identity
builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>()
  .AddEntityFrameworkStores<UserDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
