using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Votes;
using VotingAPI.Application.Dto.Response.Votes;

namespace VotingAPI.Persistence.Services
{
    public class VotingService 
    {
        public Task<bool> AddVote(AddVoteRequest addVoteRequest)
        {
            throw new NotImplementedException();
        }

        public ICollection<GetVotesResponse> GetVoteList()
        {
            throw new NotImplementedException();
        }
    }
}
