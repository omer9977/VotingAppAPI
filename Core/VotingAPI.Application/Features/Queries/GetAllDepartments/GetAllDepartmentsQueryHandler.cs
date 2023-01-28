using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Repositories.ModelRepos;

namespace VotingAPI.Application.Features.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQueryRequest, GetAllDepartmentsQueryResponse>
    {
        readonly IDepartmentReadRepo departmentReadRepo;
        public GetAllDepartmentsQueryHandler(IDepartmentReadRepo _departmentReadRepo)
        {
            departmentReadRepo = _departmentReadRepo;
        }
        public async Task<GetAllDepartmentsQueryResponse> Handle(GetAllDepartmentsQueryRequest request, CancellationToken cancellationToken)
        {
            var departments =  departmentReadRepo.GetAll().ToList();
            return new()
            {
                Departments = departments
            };
        }
    }
}
