using VotingAPI.Application.Dto.Request.Election;

namespace VotingAPI.Application.Abstractions
{
    public interface IElectionService
    {
        Task<bool> CreateDepartmentElection(CreateDepartmentElectionRequest createDepartmentElectionRequest);
    }
}
