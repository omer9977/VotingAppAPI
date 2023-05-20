//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using VotingAPI.Application.Repositories.ModelRepos;
//using VotingAPI.Domain.Entities;
//using VotingAPI.Domain.Entities.FileTypes;
//using VotingAPI.Persistence.Contexts;

//namespace VotingAPI.Persistence.Repos
//{
//    public class ProfilePhotoFileReadRepo : ReadRepo<ProfilePhotoFile>, IProfilePhotoFileReadRepo
//    {
//        public ProfilePhotoFileReadRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
//        {
//        }
//    }
//    public class ProfilePhotoFileWriteRepo : WriteRepo<ProfilePhotoFile>, IProfilePhotoFileWriteRepo
//    {
//        public ProfilePhotoFileWriteRepo(ElectionSystemDbContext _dbContext) : base(_dbContext)
//        {
//        }
//    }
//}
