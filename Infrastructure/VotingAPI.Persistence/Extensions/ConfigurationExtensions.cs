using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Persistence.Contexts;

namespace VotingAPI.Persistence.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetConnectionString()
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/VotingAPI.WebAPI"));
            configurationManager.AddJsonFile("appsettings.json");

            return configurationManager.GetConnectionString("PostgreConnectionString");
        }
    }
}
