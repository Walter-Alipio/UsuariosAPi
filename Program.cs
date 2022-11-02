using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsuariosAPI.Data;
using UsuariosAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//configurando bd
builder.Services.AddDbContext<UserDbContext>(opt
  => opt.UseMySql(builder.Configuration.GetConnectionString("UsuarioConnection"), new MySqlServerVersion(new Version(8, 0))));

//configurando identity
builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(
    opt => opt.SignIn.RequireConfirmedEmail = true
  )
  .AddEntityFrameworkStores<UserDbContext>()
  .AddDefaultTokenProviders();

//Exemplo de configuração do password no Identity
// builder.Services.Configure<IdentityOptions>(options => options.Password.RequiredLength = 8 );

builder.Services.AddControllers();
builder.Services.AddScoped<CadastroService, CadastroService>();//CadastroServide injeta a si mesmo no controlador.
builder.Services.AddScoped<LoginService, LoginService>();
builder.Services.AddScoped<TokenService, TokenService>();
builder.Services.AddScoped<LogoutService, LogoutService>();
builder.Services.AddScoped<EmailService, EmailService>();

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
