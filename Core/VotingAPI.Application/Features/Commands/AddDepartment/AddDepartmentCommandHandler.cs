using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Repositories.ModelRepos;

namespace VotingAPI.Application.Features.Commands.AddDepartment
{
    public class AddDepartmentCommandHandler : IRequestHandler<AddDepartmentCommandRequest, AddDepartmentCommandResponse>
    {
        readonly IDepartmentWriteRepo _departmentWriteRepo;
        public AddDepartmentCommandHandler(IDepartmentWriteRepo departmentWriteRepo)
        {
            _departmentWriteRepo = departmentWriteRepo;
        }
        public async Task<AddDepartmentCommandResponse> Handle(AddDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            await _departmentWriteRepo.AddAsync(new() { Name= request.Name});
            await _departmentWriteRepo.SaveChangesAsync();
            return new(); //nope
        }
    }
}
