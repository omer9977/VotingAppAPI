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
        public ElectionService(
            IElectionWriteRepo electionWriteRepo,
            IElectionReadRepo electionReadRepo,
            IMapper mapper,
            IDepartmentService departmentService,
            ICandidateReadRepo candidateReadRepo,
            IUserReadRepo userReadRepo
            )
        {
            _electionReadRepo = electionReadRepo;
            _electionWriteRepo = electionWriteRepo;
            _mapper = mapper;
            _departmentService = departmentService;
            _candidateReadRepo = candidateReadRepo;
            _userReadRepo = userReadRepo;
        }
        public async Task<bool> CreateDepartmentElection(CreateDepartmentElectionRequest createDepartmentElectionRequest)
        {
            var election = _mapper.Map<Election>(createDepartmentElectionRequest);
            await _electionWriteRepo.AddAsync(election);
            return await _electionWriteRepo.SaveChangesAsync() > 0;
        }

        public async Task<List<GetDepartmentElectionResponse>> GetAllDepartmentElections(string? departmantName)//todo düzelecek
        {

            var departments = departmantName == null ? _departmentService.GetDepartmentList() : await _departmentService.GetDepartmentsWhere(x => x.Name == departmantName);
            //var department = departments.FirstOrDefault();

            List<int> departmentIds = departments.Select(y => y.Id).ToList();
            var response = await _electionReadRepo.GetWhere(x => departmentIds.Contains((int)x.DepartmentId)).ToListAsync();
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

        public async Task<List<GetDepartmentElectionResponse>> GetAllDepartmentElections()//todo düzelecek
        {

            //var departments = departmantName == null ? _departmentService.GetDepartmentList() : await _departmentService.GetDepartmentsWhere(x => x.Name == departmantName);
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

        public async Task<List<GetCandidateResponse>> GetCandidatesByElectionId(int electionId)
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
                };
                candidatesResponse.Add(candidateResponse);

            }
            return candidatesResponse;
        }
    }
}
