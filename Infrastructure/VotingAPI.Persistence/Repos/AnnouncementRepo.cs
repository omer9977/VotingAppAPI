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
    public class AnnouncementReadRepo : ReadRepo<Announcement>, IAnnouncementReadRepo
    {
        public AnnouncementReadRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
        {
        }
    }
    public class AnnouncementWriteRepo : WriteRepo<Announcement>, IAnnouncementWriteRepo
    {
        public AnnouncementWriteRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
