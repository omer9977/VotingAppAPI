using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities.Common;

namespace VotingAPI.Domain.Entities
{
    [Table("Students", Schema = "dbo")]

    public class Student : BaseEntity
    {
        public long StudentNumber { get; set; }
        public string Name { get; set; }
    }
}
