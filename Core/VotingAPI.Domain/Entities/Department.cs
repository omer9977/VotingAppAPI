using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities.Common;

namespace VotingAPI.Domain.Entities
{
    [Table("Departments", Schema = "dbo")]
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public int FacultyId { get; set; }
    }
}
