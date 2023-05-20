using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;
using VotingAPI.Persistence.Contexts;

namespace VotingAPI.Persistence.Repos
{

    namespace VotingAPI.Persistence.Repos
    {
        public class WinnerReadRepo : ReadRepo<Winner>, IWinnerReadRepo
        {
            public WinnerReadRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
            {
            }
        }
        public class WinnerWriteRepo : WriteRepo<Winner>, IWinnerWriteRepo
        {
            public WinnerWriteRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
            {
            }
        }
    }

}
