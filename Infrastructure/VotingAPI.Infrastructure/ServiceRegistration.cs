using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Abstractions.Storage;
using VotingAPI.Application.Abstractions.Token;
using VotingAPI.Infrastructure.Services;
using VotingAPI.Infrastructure.Services.Storage;

namespace VotingAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            //services.AddScoped<IFileService, FileService>();
            services.AddScoped<IStorageService, StorageService>();
            //services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddTransient<IMailService, MailService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
        public static void AddStorage<T>(this IServiceCollection services) where T : class, IStorage
        {
            services.AddScoped<IStorage, T>();
        }
    }
}
