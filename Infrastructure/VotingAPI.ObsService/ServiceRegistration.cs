using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.ObsService.Interfaces;
using VotingAPI.ObsService.Services;

namespace VotingAPI.ObsService
{
    public static class ServiceRegistration
    {
        public static void AddObsServices(this IServiceCollection services)
        {
            services.AddScoped<IObsStudentService, ObsStudentService>();
        }
    }
}
