using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities.Common;

namespace VotingAPI.Domain.Entities
{
    [Table("Tokens", Schema = "dbo")]
    public class Token : BaseEntity
    {
        public string? AccessToken { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? RefreshToken { get; set; }
    }
}
