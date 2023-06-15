using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities.Common;

namespace VotingAPI.Domain.Entities
{
    public class Announcement : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
    }
}
