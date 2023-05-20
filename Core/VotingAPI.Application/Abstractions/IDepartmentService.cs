using System.Linq.Expressions;
using VotingAPI.Application.Dto.Request.Department;
using VotingAPI.Application.Dto.Response.Candidate;
using VotingAPI.Application.Dto.Response.Department;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Application.Abstractions
{
    public interface IDepartmentService
    {
        List<GetDepartmentResponse> GetDepartmentList();
        Task<GetDepartmentResponse> GetDepartmentByIdAsync(int id);
        Task<bool> AddDepartmentAsync(AddDepartmentRequest addDepartmentRequest);
        Task<bool> DeleteDepartmentAsync(int id);
        Task<bool> UpdateDepartmentAsync(UpdateDepartmentRequest updateDepartmentRequest);
        Task<List<GetDepartmentResponse>> GetDepartmentsWhere(Expression<Func<Department, bool>> expression);//todo daha sonra düzelt

    }
}