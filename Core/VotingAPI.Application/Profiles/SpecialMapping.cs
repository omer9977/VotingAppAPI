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
            try
            {
            var voterUser = userService.GetUserByUserNameAsync(addVoteRequest.VoterUserName).Result;
            var candidateUser = userService.GetUserByUserNameAsync(addVoteRequest.CandidateUserName).Result;
            return new VoteDto() { CandidateId = candidateUser.Id, VoterId = voterUser.Id, ElectionId = addVoteRequest.ElectionId };

            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
