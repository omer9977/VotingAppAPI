using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities.Common;
using VotingAPI.Domain.Entities.Identity;

namespace VotingAPI.Domain.Entities
{
    [Table("Students", Schema = "dbo")]

    public class Student : BaseEntity
    {
        //public long StudentNumber { get; set; }
        //public string Name { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        [ForeignKey("AspNetUsers")]
        public int UserId { get; set; }
        public AppUser User { get; set; }
    }
}
