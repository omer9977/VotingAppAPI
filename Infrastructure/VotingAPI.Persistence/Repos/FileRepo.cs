using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Repositories.ModelRepos;
using F = VotingAPI.Domain.Entities.FileTypes;
using VotingAPI.Persistence.Contexts;

namespace VotingAPI.Persistence.Repos
{
    public class FileReadRepo : ReadRepo<Domain.Entities.Common.File>, IFileReadRepo
    {
        public FileReadRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
        {
        }
    }
    public class FileWriteRepo : WriteRepo<Domain.Entities.Common.File>, IFileWriteRepo
    {
        public FileWriteRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
