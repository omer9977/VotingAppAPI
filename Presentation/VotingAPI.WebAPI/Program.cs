using VotingAPI.Application;
using VotingAPI.Persistence;
using FluentValidation.AspNetCore;
using VotingAPI.Application.Validators.Departments;
using VotingAPI.Infrastructure.Filters;
using VotingAPI.Infrastructure;
using VotingAPI.Infrastructure.Services.Storage.Local;
using VotingAPI.Infrastructure.Services.Storage.Azure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceDI();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
//builder.Services.AddStorage<LocalStorage>();
builder.Services.AddStorage<AzureStorage>();
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<AddDepartmentValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
