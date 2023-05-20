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
    public class FacultyReadRepo : ReadRepo<Faculty>, IFacultyReadRepo
    {
        public FacultyReadRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
        {
        }
    }
    public class FacultyWriteRepo : WriteRepo<Faculty>, IFacultyWriteRepo
    {
        public FacultyWriteRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
