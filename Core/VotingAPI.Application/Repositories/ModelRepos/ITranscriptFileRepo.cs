using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities;
using VotingAPI.Domain.Entities.FileTypes;

namespace VotingAPI.Application.Repositories.ModelRepos
{
    public interface ITranscriptFileReadRepo : IReadRepo<TranscriptFile>
    {
    }
    public interface ITranscriptFileWriteRepo : IWriteRepo<TranscriptFile>
    {
    }
}
