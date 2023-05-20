using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Request.Votes;
using VotingAPI.Application.Dto.Response.Votes;

namespace VotingAPI.Application.Abstractions
{
    public interface IVoteService
    {
        ICollection<GetVoteResponse> GetVoteList();
        Task<bool> AddVote(AddVoteRequest addVoteRequest);
        //ICollection<GetVotesResponse> GetVotesWhere(Func<>);
    }
}
