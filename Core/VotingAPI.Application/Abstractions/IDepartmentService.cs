using VotingAPI.Application.Dto.Request.Department;
using VotingAPI.Application.Dto.Response.Candidate;
using VotingAPI.Application.Dto.Response.Department;

namespace VotingAPI.Application.Abstractions
{
    public interface IDepartmentService
    {
        List<GetDepartmentResponse> GetDepartmentList();
        Task<GetDepartmentResponse> GetDepartmentByIdAsync(int id);
        Task<bool> AddDepartmentAsync(AddDepartmentRequest addDepartmentRequest);
        Task<bool> DeleteDepartmentAsync(int id);
    }
}
