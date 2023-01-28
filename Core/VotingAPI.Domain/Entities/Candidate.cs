using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities.Common;

namespace VotingAPI.Domain.Entities
{
    [Table("Candidates", Schema = "dbo")]
    public class Candidate : BaseEntity
    {
        public DateOnly ApplicationDate { get; set; }
        public short ApproveStatus { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
