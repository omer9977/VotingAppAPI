using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities.Common;

namespace VotingAPI.Domain.Entities
{
    public class Manager : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserRole UserRole { get; set; }
    }
}
