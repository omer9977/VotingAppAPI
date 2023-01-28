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
    public class DepartmentReadRepo : ReadRepo<Department>, IDepartmentReadRepo
    {
        public DepartmentReadRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
        {
        }
    }
    public class DepartmentWriteRepo : WriteRepo<Department>, IDepartmentWriteRepo
    {
        public DepartmentWriteRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
