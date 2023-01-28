using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Application.Features.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryResponse
    {
        public List<Department> Departments { get; set; }
    }
}
