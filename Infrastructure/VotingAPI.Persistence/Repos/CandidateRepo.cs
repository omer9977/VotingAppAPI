using Microsoft.EntityFrameworkCore;
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
    public class CandidateReadRepo : ReadRepo<Candidate>, ICandidateReadRepo
    {
        public CandidateReadRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
        {
        }
        public new async Task<Candidate> GetByIdAsync(int id, bool isTracking = true) //todo onemli bu kullanım nasıl include için
        {
            var query = Table.AsQueryable();
            if (!isTracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
    public class CandidateWriteRepo : WriteRepo<Candidate>, ICandidateWriteRepo
    {
        public CandidateWriteRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
