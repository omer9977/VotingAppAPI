using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Election;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Persistence.Services
{
    public class ElectionService : IElectionService
    {
        private readonly IElectionWriteRepo _electionWriteRepo;
        private readonly IElectionReadRepo _electionReadRepo;
        private readonly IMapper _mapper;
        public ElectionService(
            IElectionWriteRepo electionWriteRepo,
            IElectionReadRepo electionReadRepo,
            IMapper mapper
            )
        {
            _electionReadRepo = electionReadRepo;
            _electionWriteRepo = electionWriteRepo;
            _mapper = mapper;
        }
        public async Task<bool> CreateDepartmentElection(CreateDepartmentElectionRequest createDepartmentElectionRequest)
        {
            var election = _mapper.Map<Election>(createDepartmentElectionRequest);
            await _electionWriteRepo.AddAsync(election);
            return await _electionWriteRepo.SaveChangesAsync() > 0;
        }
    }
}
