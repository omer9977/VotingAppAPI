using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Request.Department
{
    public class UpdateDepartmentRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
