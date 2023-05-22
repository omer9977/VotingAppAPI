using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities.Common;

namespace VotingAPI.Domain.Entities
{
    [Table("Users", Schema = "dbo")]
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public UserRole UserRole { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? RefreshToken { get; set; }
        public string Password { get; set; }
    }
    public enum UserRole
    {
        Admin,
        Student,
        Candidate
    }
}
