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
        public int VoterId { get; set; }
        [ForeignKey("Students")]
        [Column("VoterId")]
        public Student Voter { get; set; }
        public Student Candidate { get; set; }
        public int CandidateId { get; set; }
        public VotingPeriod VotingPeriod { get; set; }
        public int VotingPeriodId { get; set; }
    }
}
