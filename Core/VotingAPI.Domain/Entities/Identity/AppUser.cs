using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VotingAPI.Domain.Entities.Common;

namespace VotingAPI.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public long StudentNumber { get; set; }
    }
}
