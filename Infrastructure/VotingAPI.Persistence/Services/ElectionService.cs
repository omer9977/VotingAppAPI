using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Election;
using VotingAPI.Application.Dto.Response.Election;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Persistence.Services
{
    public class ElectionService : IElectionService
    {
        private readonly IElectionWriteRepo _electionWriteRepo;
        private readonly IElectionReadRepo _electionReadRepo;
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;
        public ElectionService(
            IElectionWriteRepo electionWriteRepo,
            IElectionReadRepo electionReadRepo,
            IMapper mapper,
            IDepartmentService departmentService
            )
        {
            _electionReadRepo = electionReadRepo;
            _electionWriteRepo = electionWriteRepo;
            _mapper = mapper;
            _departmentService = departmentService;
        }
        public async Task<bool> CreateDepartmentElection(CreateDepartmentElectionRequest createDepartmentElectionRequest)
        {
            var election = _mapper.Map<Election>(createDepartmentElectionRequest);
            await _electionWriteRepo.AddAsync(election);
            return await _electionWriteRepo.SaveChangesAsync() > 0;
        }

        public async Task<List<GetDepartmentElectionResponse>> GetAllDepartmentElections()//todo düzelecek
        {
            var response = await _electionReadRepo.GetAll().ToListAsync();
            if (response == null)
                return null;
            var departments = _departmentService.GetDepartmentList();
            List<GetDepartmentElectionResponse> getDepartmentElectionResponse = new();
            response.ForEach(election =>
            {
                var department = departments.FirstOrDefault(x => x.Id == election.DepartmentId).Name;
                getDepartmentElectionResponse.Add(new GetDepartmentElectionResponse()
                {
                    
                    DepartmentName = department ?? "",
                    EndDate = election.EndDate,
                    Name = election.Name,
                    StartDate = election.StartDate,
                });
            });
            //var election = _mapper.Map<GetDepartmentElectionResponse>(response);
            return getDepartmentElectionResponse;
        }
    }
}
