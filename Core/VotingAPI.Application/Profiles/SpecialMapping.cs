using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.General;
using VotingAPI.Application.Dto.Request.Votes;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Application.Profiles
{
    public static class SpecialMapping
    {
        public static async Task<VoteDto> ToVoteDto(this AddVoteRequest addVoteRequest, IUserService userService)
        {
            var voterUser = await userService.GetUserByUserNameAsync(addVoteRequest.VoterUserName);
            var candidateUser = await userService.GetUserByUserNameAsync(addVoteRequest.CandidateUserName);
            return new VoteDto() { CandidateId = candidateUser.Id, VoterId = voterUser.Id, ElectionId = addVoteRequest.ElectionId };
        }
    }
}
