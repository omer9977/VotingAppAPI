using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Votes;
using VotingAPI.Application.Dto.Response.Votes;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Persistence.Services
{
    public class VoteService : IVoteService
    {
        private readonly IVoteReadRepo _voteReadRepo;
        private readonly IVoteWriteRepo _voteWriteRepo;
        private readonly ICandidateReadRepo _candidateReadRepo;
        private readonly IStudentReadRepo _studentReadRepo;
        private readonly IMapper _mapper;

        public VoteService(IVoteReadRepo voteReadRepo,
            IVoteWriteRepo voteWriteRepo,
            IMapper mapper,
ICandidateReadRepo candidateReadRepo
,
IStudentReadRepo studentReadRepo)
        {
            _voteReadRepo = voteReadRepo;
            _voteWriteRepo = voteWriteRepo;
            _mapper = mapper;
            _candidateReadRepo = candidateReadRepo;
            _studentReadRepo = studentReadRepo;
        }
        public async Task<bool> AddVote(AddVoteRequest addVoteRequest)
        {//todo null exception kontrolü geçtim artık :)
            var candidate = await _candidateReadRepo.GetByIdAsync(addVoteRequest.CandidateId);
            var student = await _studentReadRepo.GetByIdAsync(addVoteRequest.StudentId);
            if (candidate.Student.DepartmentId == student.DepartmentId && candidate.ApproveStatus == 1)
            {
                var voteMapped = _mapper.Map<Vote>(addVoteRequest);
                bool isAdded = await _voteWriteRepo.AddAsync(voteMapped);
                if (isAdded)
                {
                    try
                    {
                    await _voteWriteRepo.SaveChangesAsync();

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                    return true;
                }
                return false;
            }
            else
                return false;//todo daha sonra burayı düzenle
        }

        public ICollection<GetVoteResponse> GetVoteList()
        {
            var votesDb = _voteReadRepo.GetAll(false).ToList();
            var studentListResponse = _mapper.Map<List<GetVoteResponse>>(votesDb);
            return studentListResponse;
        }
    }
}
