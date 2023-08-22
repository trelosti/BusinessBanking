using BusinessBanking.Converters;
using BusinessBanking.DAL.DataContexts;
using BusinessBanking.Domain.Entity;
using BusinessBanking.Interface.Converters;
using BusinessBanking.Interface.Repositories;
using BusinessBanking.Interface.Services.Auth;
using BusinessBanking.Interface.Services.CustomerAccounts;
using BusinessBanking.Interface.Services.Notifications;
using BusinessBanking.Interface.Services.Users;
using BusinessBanking.Repository.CustomerAccounts;
using BusinessBanking.Repository.Notifications;
using BusinessBanking.Repository.Users;
using BusinessBanking.Services.Auth;
using BusinessBanking.Services.CustomerAccounts;
using BusinessBanking.Services.Notifications;
using BusinessBanking.Services.Users;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "banking-f40fb-firebase-adminsdk-q4r8a-6f2556ea6f.json")),
});

builder.Services.AddScoped<IBaseRepository<User>, UserRepository>();
builder.Services.AddScoped<IBaseRepository<CustomerAccount>, CustomerAccountRepository>();
builder.Services.AddScoped<IBaseRepository<Currency>, CurrencyRepository>();
builder.Services.AddScoped<IBaseRepository<CustomerAccountName>, CustomerAccountNameRepository>();
builder.Services.AddScoped<IBaseRepository<Notification>, NotificationRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<IAccountConverter, AccountConverter>();
builder.Services.AddScoped<ICustomerAccountService, CustomerAccountService>();
builder.Services.AddScoped<ICustomerAccountNameService, CustomerAccountNameService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetSection("AppSettings:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("AppSettings:Issuer").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    builder.Configuration.GetSection("AppSettings:SecretKey").Value!))
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "dotnetClaimAuthorization", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insert Access Token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },

            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DataContext>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
