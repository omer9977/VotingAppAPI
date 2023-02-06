using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Department;
using VotingAPI.Application.Dto.Response.Department;

namespace VotingAPI.Persistence.Services
{
    public class DepartmentService : IDepartmentService
    {
        public Task<bool> AddDepartmentAsync(AddDepartmentRequest addDepartmentRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDepartmentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetDepartmentResponse> GetDepartmentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<GetDepartmentResponse> GetDepartmentList()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDepartmentAsync(UpdateDepartmentRequest addDepartmentRequest)
        {
            throw new NotImplementedException();
        }
    }
}
