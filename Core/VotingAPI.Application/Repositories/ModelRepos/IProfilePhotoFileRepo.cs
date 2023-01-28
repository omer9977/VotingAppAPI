using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities;
using VotingAPI.Domain.Entities.FileTypes;

namespace VotingAPI.Application.Repositories.ModelRepos
{

        public interface IProfilePhotoFileReadRepo : IReadRepo<ProfilePhotoFile>
        {
        }
        public interface IProfilePhotoFileWriteRepo : IWriteRepo<ProfilePhotoFile>
        {
        }
}
