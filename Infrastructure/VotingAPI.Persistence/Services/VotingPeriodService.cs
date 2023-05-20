//using AutoMapper;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using VotingAPI.Application.Abstractions;
//using VotingAPI.Application.Dto.Request.VotingPeriod;
//using VotingAPI.Application.Dto.Response.VotingPeriod;
//using VotingAPI.Application.Exceptions;
//using VotingAPI.Application.Repositories.ModelRepos;
//using VotingAPI.Domain.Entities;

//namespace VotingAPI.Persistence.Services
//{
//    public class VotingPeriodService : IVotingPeriodService
//    {
//        //private readonly IVotingPeriodReadRepo _votingPeriodReadRepo;
//        //private readonly IVotingPeriodWriteRepo _votingPeriodWriteRepo;
//        private readonly IMapper _mapper;
//        public VotingPeriodService(IVotingPeriodReadRepo votingPeriodReadRepo, IVotingPeriodWriteRepo votingPeriodWriteRepo, IMapper mapper)
//        {
//            _votingPeriodReadRepo = votingPeriodReadRepo;
//            _votingPeriodWriteRepo = votingPeriodWriteRepo;
//            _mapper = mapper;
//        }
//        public ICollection<GetVotingPeriodResponse> GetVotingPeriodList()
//        {
//            var votingPeriods = _votingPeriodReadRepo.GetAll();
//            var votingMapped = _mapper.Map<List<GetVotingPeriodResponse>>(votingPeriods);
//            return votingMapped;
//        }

//        public async Task<bool> AddVotingPeriodAsync(AddVotingPeriodRequest addVotingPeriodRequest)
//        {
//            var votingPeriod = _mapper.Map<VotingPeriod>(addVotingPeriodRequest);
//            if (addVotingPeriodRequest.StartDate > addVotingPeriodRequest.EndDate)
//                throw new DataNotAddedException("StartDate can not smaller than EndDate");
//            bool isAdded = await _votingPeriodWriteRepo.AddAsync(votingPeriod);
//            if (isAdded)
//                await _votingPeriodWriteRepo.SaveChangesAsync();
//            return isAdded;
//        }


//        public async Task<bool> UpdateVotingPeriodAsync(UpdateVotingPeriodRequest updateVotingPeriodRequest)
//        {
//            var votingPeriod = _mapper.Map<VotingPeriod>(updateVotingPeriodRequest);
//            if (updateVotingPeriodRequest.StartDate > updateVotingPeriodRequest.EndDate)
//                throw new DataNotAddedException("StartDate can not smaller than EndDate");
//            bool isUpdated =  _votingPeriodWriteRepo.Update(votingPeriod);
//            await _votingPeriodWriteRepo.SaveChangesAsync();
//            return isUpdated;
//        }
//    }
//}
