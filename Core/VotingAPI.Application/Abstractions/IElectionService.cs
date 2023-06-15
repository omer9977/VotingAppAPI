using VotingAPI.Application.Dto.Request.Election;
using VotingAPI.Application.Dto.Response.Candidate;
using VotingAPI.Application.Dto.Response.Election;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Application.Abstractions
{
    public interface IElectionService
    {
        Task<bool> CreateDepartmentElectionAsync(CreateDepartmentElectionRequest createDepartmentElectionRequest);
        Task<List<GetDepartmentElectionResponse>> GetAllDepartmentElectionsAsync(string departmanName = null);
        Task<List<GetCandidateResponse>> GetCandidatesByElectionIdAsync(int electionId);
        Task<List<GetDepartmentElectionResponse>> GetAllDepartmentElectionsAsync();
        Task<GetElectionResultResponse> GetResultByElectionIdAsync(int electionId);
        Task<bool> UpdateElectionAsync(int electionId, UpdateDepartmentElectionRequest updateDepartmentElectionRequest);
        Task<bool> DeleteElectionAsync(int electionId);
        Task<bool> FinishElectionAsync(int electionId);

    }
}
