using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Request.Candidate;
using VotingAPI.Application.Dto.Request.VotingPeriod;
using VotingAPI.Application.Dto.Response.Candidate;
using VotingAPI.Application.Dto.Response.VotingPeriod;

namespace VotingAPI.Application.Abstractions
{
    public interface IVotingPeriodService
    {
        ICollection<GetVotingPeriodResponse> GetVotingPeriodList();
        Task<bool> AddVotingPeriodAsync(AddVotingPeriodRequest addVotingPeriodRequest);
        Task<bool> UpdateVotingPeriodAsync(UpdateVotingPeriodRequest updateVotingPeriodRequest);


    }
}
