using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VotingAPI.Domain.Entities.Common;

namespace VotingAPI.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long StudentNumber { get; set; }
    }
}
