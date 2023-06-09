using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Votes;
using VotingAPI.Application.Dto.Response.Votes;
using VotingAPI.Application.Exceptions;
using VotingAPI.Application.Profiles;
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
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public VoteService(IVoteReadRepo voteReadRepo,
            IVoteWriteRepo voteWriteRepo,
            IMapper mapper,
            ICandidateReadRepo candidateReadRepo,
            IStudentReadRepo studentReadRepo,
            IUserService userService)
        {
            _voteReadRepo = voteReadRepo;
            _voteWriteRepo = voteWriteRepo;
            _mapper = mapper;
            _candidateReadRepo = candidateReadRepo;
            _studentReadRepo = studentReadRepo;
            _userService = userService;
        }
        public async Task<bool> AddVote(AddVoteRequest addVoteRequest)
        {//todo null exception kontrolü geçtim artık :)
            //var voteDb = _mapper.Map<Vote>(addVoteRequest);
            var voteDto = await addVoteRequest.ToVoteDto(_userService);
            var voteDb = _mapper.Map<Vote>(voteDto);
            var vote = await _voteReadRepo.GetSingleAsync(x => x.CandidateId == voteDb.CandidateId && x.VoterId == voteDb.VoterId);
            if (vote != null)
                throw new DataNotAddedException("You can not vote again!!!");
            await _voteWriteRepo.AddAsync(voteDb);
            await _voteWriteRepo.SaveChangesAsync();
            //var candidate = await _candidateReadRepo.GetByIdAsync(addVoteRequest.CandidateId);
            //var student = await _studentReadRepo.GetByIdAsync(addVoteRequest.StudentId);
            //if (candidate.Student.DepartmentId == student.DepartmentId && candidate.ApproveStatus == ApproveStatus.Approved)
            //{
            //    var voteMapped = _mapper.Map<Vote>(addVoteRequest);
            //    bool isAdded = await _voteWriteRepo.AddAsync(voteMapped);
            //    if (isAdded)
            //    {
            //        try
            //        {
            //        await _voteWriteRepo.SaveChangesAsync();

            //        }
            //        catch (Exception ex)
            //        {

            //            throw ex;
            //        }
            //        return true;
            //    }
            //    return false;
            //}
            //else
            //    return false;//todo daha sonra burayı düzenle
            return true;
        }

        public ICollection<GetVoteResponse> GetVoteList()
        {
            var votesDb = _voteReadRepo.GetAll(false).ToList();
            var studentListResponse = _mapper.Map<List<GetVoteResponse>>(votesDb);
            return studentListResponse;
        }
    }
}
