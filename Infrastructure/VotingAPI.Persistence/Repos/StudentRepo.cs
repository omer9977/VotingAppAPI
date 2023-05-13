using Microsoft.EntityFrameworkCore;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;
using VotingAPI.Persistence.Contexts;

namespace VotingAPI.Persistence.Repos
{
    public class StudentReadRepo : ReadRepo<Student>, IStudentReadRepo
    {
        public StudentReadRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
        {
        }
        public new async Task<Student> GetByIdAsync(int id, bool isTracking = true) //todo onemli bu kullanım nasıl include için
        {
            var query = Table.AsQueryable();
            if (!isTracking)
                query = query.AsNoTracking();
            return await query./*Include(s => s.User).Include(s => s.Department).*/FirstOrDefaultAsync(x => x.Id == id);
        }
    }
    public class StudentWriteRepo : WriteRepo<Student>, IStudentWriteRepo
    {
        public StudentWriteRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
