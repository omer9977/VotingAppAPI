using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities.Common;

namespace VotingAPI.Domain.Entities
{
    [Table("Votings", Schema = "dbo")]

    public class Voting : BaseEntity
    {
        public int WinnerId { get; set; }
        public int VotingPeriodId { get; set; }
        public Candidate Winner { get; set; }
        public VotingPeriod VotingPeriod { get; set; }
    }
}
