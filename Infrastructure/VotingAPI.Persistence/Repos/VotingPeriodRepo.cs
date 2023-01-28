using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;
using VotingAPI.Persistence.Contexts;

namespace VotingAPI.Persistence.Repos
{
    public class VotingPeriodReadRepo : ReadRepo<VotingPeriod>, IVotingPeriodReadRepo
    {
        public VotingPeriodReadRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
        {
        }
    }
    public class VotingPeriodWriteRepo : WriteRepo<VotingPeriod>, IVotingPeriodWriteRepo
    {
        public VotingPeriodWriteRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
