using VotingAPI.Application.Dto.Request.Election;
using VotingAPI.Application.Dto.Response.Candidate;
using VotingAPI.Application.Dto.Response.Election;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Application.Abstractions
{
    public interface IElectionService
    {
        Task<bool> CreateDepartmentElection(CreateDepartmentElectionRequest createDepartmentElectionRequest);
        Task<List<GetDepartmentElectionResponse>> GetAllDepartmentElections(string departmanName = null);
        Task<List<GetCandidateResponse>> GetCandidatesByElectionId(int electionId);
    }
}
