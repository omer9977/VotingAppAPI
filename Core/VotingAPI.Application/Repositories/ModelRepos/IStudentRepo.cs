using VotingAPI.Domain.Entities;

namespace VotingAPI.Application.Repositories.ModelRepos
{
    public interface IStudentReadRepo : IReadRepo<Student> 
    {
        public new Task<Student> GetByIdAsync(int id, bool isTracking = true); //todo onemli bu kullanım nasıl include için
    }
    public interface IStudentWriteRepo : IWriteRepo<Student>
    {
    }
}
