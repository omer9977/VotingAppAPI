using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Election;
using VotingAPI.Application.Dto.Response.Candidate;
using VotingAPI.Application.Dto.Response.Election;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;
using VotingAPI.Persistence.Repos;

namespace VotingAPI.Persistence.Services
{
    public class ElectionService : IElectionService
    {
        private readonly IElectionWriteRepo _electionWriteRepo;
        private readonly IElectionReadRepo _electionReadRepo;
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;
        private readonly ICandidateReadRepo _candidateReadRepo;
        private readonly IUserReadRepo _userReadRepo;
        private readonly IVoteReadRepo _voteReadRepo;
        public ElectionService(
            IElectionWriteRepo electionWriteRepo,
            IElectionReadRepo electionReadRepo,
            IMapper mapper,
            IDepartmentService departmentService,
            ICandidateReadRepo candidateReadRepo,
            IUserReadRepo userReadRepo,
            IVoteReadRepo voteReadRepo
            )
        {
            _electionReadRepo = electionReadRepo;
            _electionWriteRepo = electionWriteRepo;
            _mapper = mapper;
            _departmentService = departmentService;
            _candidateReadRepo = candidateReadRepo;
            _userReadRepo = userReadRepo;
            _voteReadRepo = voteReadRepo;
        }
        public async Task<bool> CreateDepartmentElectionAsync(CreateDepartmentElectionRequest createDepartmentElectionRequest)
        {
            var election = _mapper.Map<Election>(createDepartmentElectionRequest);
            await _electionWriteRepo.AddAsync(election);
            return await _electionWriteRepo.SaveChangesAsync() > 0;
        }

        public async Task<List<GetDepartmentElectionResponse>> GetAllDepartmentElectionsAsync(string? departmantName)//todo düzelecek
        {

            var departments = departmantName == null ? _departmentService.GetDepartmentList() : await _departmentService.GetDepartmentsWhere(x => x.Name == departmantName);
            //var department = departments.FirstOrDefault();

            List<int> departmentIds = departments.Select(y => y.Id).ToList();
            var response = await _electionReadRepo.GetWhere(x => departmentIds.Contains((int)x.DepartmentId), false).ToListAsync();
            if (response == null)
                return null;
            List<GetDepartmentElectionResponse> getDepartmentElectionResponse = new();
            response.ForEach(election =>
            {
                var department = departments.FirstOrDefault(x => x.Id == election.DepartmentId)?.Name;
                
                getDepartmentElectionResponse.Add(new GetDepartmentElectionResponse()
                {
                    Id = election.Id,
                    DepartmentName = department ?? "",
                    EndDate = election.EndDate,
                    Name = election.Name,
                    StartDate = election.StartDate,
                });
            });
            //var election = _mapper.Map<GetDepartmentElectionResponse>(response);
            return getDepartmentElectionResponse;
        }

        public async Task<List<GetDepartmentElectionResponse>> GetAllDepartmentElectionsAsync()//todo düzelecek
        {

            //var departments = departmantName == null ? _departmentService.GetDepartmentList();
            //var department = departments.FirstOrDefault();

            //List<int> departmentIds = departments.Select(y => y.Id).ToList();
            var response = await _electionReadRepo.GetAll().ToListAsync();
            if (response == null)
                return null;
            List<GetDepartmentElectionResponse> getDepartmentElectionResponse = new();
            response.ForEach(election =>
            {
                //var department = departments.FirstOrDefault(x => x.Id == election.DepartmentId)?.Name;

                getDepartmentElectionResponse.Add(new GetDepartmentElectionResponse()
                {
                    Id = election.Id,
                    //DepartmentName = department ?? "",
                    EndDate = election.EndDate,
                    Name = election.Name,
                    StartDate = election.StartDate,
                });
            });
            //var election = _mapper.Map<GetDepartmentElectionResponse>(response);
            return getDepartmentElectionResponse;
        }

        public async Task<List<GetCandidateResponse>> GetCandidatesByElectionIdAsync(int electionId)
        {
            var candidates = await _candidateReadRepo.GetWhere(c => c.ElectionId == electionId).ToListAsync();
            var candidatesResponse = new List<GetCandidateResponse>();

            HashSet<int> userIds = new HashSet<int>(candidates.Select(s => s.UserId));

            var usersQuery = _userReadRepo.Table.Where(x => userIds.Contains(x.Id)).AsNoTracking();
            var users = usersQuery.ToList(); //todo buraya bakılacak
            foreach (var candidate in candidates)
            {
                var user = users.FirstOrDefault(x => x.Id == candidate.UserId);
                var candidateResponse = new GetCandidateResponse()
                {
                    FirstName = user.Name,
                    LastName = user.LastName,
                    Description = candidate.Description,
                    UserName = user.UserName,
                };
                candidatesResponse.Add(candidateResponse);

            }
            return candidatesResponse;
        }

        public async Task<GetElectionResultResponse> GetResultByElectionIdAsync(int electionId)
        {
            var candidates = await _candidateReadRepo.GetWhere(c => c.ElectionId == electionId).ToListAsync();
            var candidatesResponse = new GetElectionResultResponse();
            var candidatesList = new List<GetCandidateElectionResponse>();

            HashSet<int> userIds = new HashSet<int>(candidates.Select(s => s.UserId));
            //HashSet<int> candidateIds = new HashSet<int>(candidates.Select(s => s.Id));

            var usersQuery = _userReadRepo.Table.Where(x => userIds.Contains(x.Id)).AsNoTracking();
            var users = usersQuery.ToList(); //todo buraya bakılacak

            int totalCount = 0;
            foreach (var candidate in candidates)
            {
                var voteNumber = _voteReadRepo.GetWhere(n => n.CandidateId == candidate.UserId).Count();
                var user = users.FirstOrDefault(x => x.Id == candidate.UserId);
                var candidateResponse = new GetCandidateElectionResponse()
                {
                    FirstName = user.Name,
                    LastName = user.LastName,
                    VoteNumber = voteNumber
                };
                candidatesList.Add(candidateResponse);
                totalCount += voteNumber;
            }
            candidatesResponse.CandidateElectionResultList = candidatesList.OrderByDescending(x => x.VoteNumber).ToList();
            var maxCountCandidate = candidatesResponse.CandidateElectionResultList.FirstOrDefault();
            if (maxCountCandidate?.VoteNumber > totalCount / 2)
            {
                candidatesResponse.Message = $"{maxCountCandidate.FirstName} {maxCountCandidate.LastName} won the election.";
            }
            else
            {
                candidatesResponse.Message = $"Nobody could not won election because of the absolute majority. It will be second election";
            }
            return candidatesResponse;
        }

        public async Task<bool> UpdateElectionAsync(int electionId, UpdateDepartmentElectionRequest updateDepartmentElectionRequest)
        {
            var election = await _electionReadRepo.GetSingleAsync(x => x.Id == electionId);
            election.EndDate = updateDepartmentElectionRequest.EndDate;
            election.StartDate = updateDepartmentElectionRequest.StartDate;
            election.Name = updateDepartmentElectionRequest.Name;
            _electionWriteRepo.Update(election);
            return await _electionWriteRepo.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteElectionAsync(int electionId)
        {
            await _electionWriteRepo.RemoveByIdAsync(electionId);
            return await _electionWriteRepo.SaveChangesAsync() > 0;
        }

        public async Task<bool> FinishElectionAsync(int electionId)
        {
            var election = await _electionReadRepo.GetByIdAsync(electionId);
            election.EndDate = DateTime.UtcNow;
            return await _electionWriteRepo.SaveChangesAsync() > 0;
        }
    }
}
