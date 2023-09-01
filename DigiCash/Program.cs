using DigiCash.Models;
using DigiCash.Services;
using DigiCash.Services.WalletServices;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDb"));
//builder.Services.Configure<PostgreDbSettings>(builder.Configuration.GetSection("Postgre"));
//builder.Services.Configure<ConfigSettings>(builder.Configuration.GetSection("AppConfig"));

/*
builder.Services.AddSingleton<MongoDbServices>();
builder.Services.AddSingleton<ConfigServices>();
builder.Services.AddSingleton<DepositServices>();
builder.Services.AddSingleton<AmountServices>();
builder.Services.AddSingleton<BalanceServices>();
builder.Services.AddSingleton<WithdrawServices>();
builder.Services.AddSingleton<TransferMoneyServices>();
builder.Services.AddSingleton<PostgreSqlServices>();
*/



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
     {
         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateLifetime = true,
             ValidateIssuerSigningKey = true,
             ValidIssuer = builder.Configuration["Jwt:Issuer"],
             ValidAudience = builder.Configuration["Jwt:Audience"],
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? string.Empty))
         };
     });


builder.Services.AddSingleton<UserServices>();
builder.Services.Configure<JwtModel>(builder.Configuration.GetSection("Jwt"));


builder.Services.AddControllers();
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

