using System.Text;
using Chelle.Application.Services;
using Chelle.Core.Services;
using Chelle.Infrastructure.Auth;
using Chelle.Infrastructure.Data;
using Chelle.Infrastructure.Identity;
using Chelle.Infrastructure.Repositories;
using Chelle.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Resend;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ChelleDb")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//Jwt Authentication
builder.Services.AddOptions<JwtSettings>()
     .Bind(builder.Configuration.GetSection("JwtSettings"))
     .Validate(s =>
                    !string.IsNullOrWhiteSpace(s.SecretKey) &&
                    !string.IsNullOrWhiteSpace(s.Issuer) &&
                    !string.IsNullOrWhiteSpace(s.Audience) &&
                    s.ExpirationMinutes > 0,
                    "Invalid JWT settings")
        .ValidateOnStart();// throws on app start if validation fails
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"]
    ?? throw new InvalidOperationException("JWT Secret Key is not configured.");

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };
    });

// Resend email 
builder.Services.AddHttpClient<ResendClient>();
builder.Services.Configure<ResendClientOptions>(opt =>
{
    opt.ApiToken = builder.Configuration["ResendEmailSettings:ApiKey"]
        ?? throw new InvalidOperationException("Resend API Token is not configured.");
});

//Identity Framework Core
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.SignIn.RequireConfirmedPhoneNumber = true;
}).AddRoles<AppRole>()
  .AddRoleManager<RoleManager<AppRole>>()
  .AddSignInManager<SignInManager<AppUser>>()
  .AddEntityFrameworkStores<AppDbContext>()
  .AddDefaultTokenProviders();


// DI
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddTransient<IResendEmailSender, ResendEmailSender>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();



app.Run();


