using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities.Identity;
using VotingAPI.Persistence.Contexts;
using VotingAPI.Persistence.Extensions;
using VotingAPI.Persistence.Repos;
using VotingAPI.Persistence.Services;

namespace VotingAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceDI(this IServiceCollection services) 
        {
            services.AddDbContext<ElectionSystemDbContext>(o => o.UseNpgsql(ConfigurationExtensions.GetConnectionString()));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ElectionSystemDbContext>();
            services.AddScoped<IDepartmentReadRepo, DepartmentReadRepo>();
            services.AddScoped<ICandidateReadRepo, CandidateReadRepo>();
            services.AddScoped<IElectionTypeReadRepo, ElectionTypeReadRepo>();
            services.AddScoped<IStudentReadRepo, StudentReadRepo>();
            services.AddScoped<IVoteReadRepo, VoteReadRepo>();
            services.AddScoped<IVotingPeriodReadRepo, VotingPeriodReadRepo>();
            services.AddScoped<IVotingReadRepo, VotingReadRepo>();
            services.AddScoped<IDepartmentWriteRepo, DepartmentWriteRepo>();
            services.AddScoped<ICandidateWriteRepo, CandidateWriteRepo>();
            services.AddScoped<IElectionTypeWriteRepo, ElectionTypeWriteRepo>();
            services.AddScoped<IStudentWriteRepo, StudentWriteRepo>();
            services.AddScoped<IVoteWriteRepo, VoteWriteRepo>();
            services.AddScoped<IVotingPeriodWriteRepo, VotingPeriodWriteRepo>();
            services.AddScoped<IVotingWriteRepo, VotingWriteRepo>();
            //services.AddScoped<IFileWriteRepo, FileWriteRepo>();
            //services.AddScoped<IFileReadRepo, FileReadRepo>();
            services.AddScoped<ITranscriptFileReadRepo, TranscriptFileReadRepo>();
            services.AddScoped<ITranscriptFileWriteRepo, TranscriptFileWriteRepo>();
            services.AddScoped<ICriminalRecordFileReadRepo, CriminalRecordFileReadRepo>();
            services.AddScoped<ICriminalRecordFileWriteRepo, CriminalRecordFileWriteRepo>();
            services.AddScoped<IProfilePhotoFileReadRepo, ProfilePhotoFileReadRepo>();
            services.AddScoped<IProfilePhotoFileWriteRepo, ProfilePhotoFileWriteRepo>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IStudentService, StudentService>();

        }
    }
}
