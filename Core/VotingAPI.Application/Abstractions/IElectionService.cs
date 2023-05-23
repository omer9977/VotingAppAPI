using VotingAPI.Application.Dto.Request.Election;
using VotingAPI.Application.Dto.Response.Election;

namespace VotingAPI.Application.Abstractions
{
    public interface IElectionService
    {
        Task<bool> CreateDepartmentElection(CreateDepartmentElectionRequest createDepartmentElectionRequest);
        Task<List<GetDepartmentElectionResponse>> GetAllDepartmentElections();
    }
}
