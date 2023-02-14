using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities.Common;

namespace VotingAPI.Domain.Entities
{
    [Table("Votes", Schema = "dbo")]
    public class Vote : BaseEntity
    {
        public DateTime VotingDate { get; set; }
        [ForeignKey("Students")]
        public int VoterId { get; set; }
        [Column("VoterId")]
        public Student Voter { get; set; }
        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
        public VotingPeriod VotingPeriod { get; set; }
        public int VotingPeriodId { get; set; }
    }
}
