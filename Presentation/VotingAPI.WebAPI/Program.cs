using VotingAPI.Application;
using VotingAPI.Persistence;
using FluentValidation.AspNetCore;
using VotingAPI.Application.Validators.Departments;
using VotingAPI.Infrastructure.Filters;
using VotingAPI.Infrastructure;
using VotingAPI.Infrastructure.Services.Storage.Local;
using VotingAPI.Infrastructure.Services.Storage.Azure;
using VotingAPI.WebAPI.Filters;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceDI();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddStorage<AzureStorage>();
builder.Services.AddApiVersioning(_ =>
{
    _.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    _.AssumeDefaultVersionWhenUnspecified = true;
});
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
})
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<AddDepartmentValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false, //todo ben bu satırı anlamadım internette araştıracam
        };
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseMiddleware<ResponseWrapperAndGlobalExceptionHandlerMiddleware>();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
