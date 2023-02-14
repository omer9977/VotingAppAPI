using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Application.Repositories.ModelRepos
{
    public interface ICandidateReadRepo : IReadRepo<Candidate>
    {
        public new Task<Candidate> GetByIdAsync(int id, bool isTracking = true); //todo onemli bu kullanım nasıl include için
    }
    public interface ICandidateWriteRepo : IWriteRepo<Candidate>
    {
    }
}
