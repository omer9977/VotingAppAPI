using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Response.Election
{
    public class GetDepartmentElectionResponse
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DepartmentName { get; set; }
    }
}
