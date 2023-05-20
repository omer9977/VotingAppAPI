using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Data.DataModels
{
    public class ObsStudent
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public int Year { get; set; }
    }
}
