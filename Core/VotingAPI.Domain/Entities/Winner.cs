using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities.Common;

namespace VotingAPI.Domain.Entities
{
    [Table("Winners", Schema = "dbo")]
    public class Winner : BaseEntity
    {
        [ForeignKey("Candidates")]
        public int CandidateId { get; set; }
        [ForeignKey("Elections")]
        public int ElectionId { get; set; }
    }
}
