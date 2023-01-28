using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Application.Repositories.ModelRepos
{
    public interface IVoteReadRepo : IReadRepo<Vote>
    {
    }
    public interface IVoteWriteRepo : IWriteRepo<Vote>
    {
    }
}
