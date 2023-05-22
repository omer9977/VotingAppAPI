using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities.Common;
//using VotingAPI.Domain.Entities.Identity;

namespace VotingAPI.Domain.Entities
{
    [Table("Students", Schema = "dbo")]

    public class Student : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int DepartmentId { get; set; }
        public int Year { get; set; }
    }

}
