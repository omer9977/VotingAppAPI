using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D = VotingAPI.Domain.Entities;

namespace VotingAPI.Application.Dto.Response.Department
{
    public class GetAllDepartmentsResponse
    {
        public List<D.Department> Departments { get; set; }
    }
}
