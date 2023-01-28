using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities.FileTypes;
using VotingAPI.Persistence.Contexts;

namespace VotingAPI.Persistence.Repos
{
    public class TranscriptFileReadRepo : ReadRepo<TranscriptFile>, ITranscriptFileReadRepo
    {
        public TranscriptFileReadRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
        {
        }
    }
    public class TranscriptFileWriteRepo : WriteRepo<TranscriptFile>, ITranscriptFileWriteRepo
    {
        public TranscriptFileWriteRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
