using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities;
using VotingAPI.Domain.Entities.FileTypes;
using VotingAPI.Domain.Entities.Identity;
using F = VotingAPI.Domain.Entities.FileTypes;

namespace VotingAPI.Persistence.Contexts
{
    public class ElectionSystemDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ElectionSystemDbContext(DbContextOptions options) : base(options) 
        { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Voting> Votings { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<VotingPeriod> VotingPeriods { get; set; }
        public DbSet<ElectionType> ElectionTypes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ProfilePhotoFile> ProfilePhotoFiles { get; set; }

        //public DbSet<Domain.Entities.Common.File> Files { get; set; }

        public DbSet<F.TranscriptFile> TranscriptFiles { get; set; }
        public DbSet<F.CriminalRecordFile> CriminalRecordFiles { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TranscriptFile>()
                .HasIndex(p => new { p.Path})
                .IsUnique(true);
            modelBuilder.Entity<TranscriptFile>()
                .HasIndex(p => new { p.CandidateId })
                .IsUnique(true);

            modelBuilder.Entity<CriminalRecordFile>()
                .HasIndex(p => new { p.Path })
                .IsUnique(true);
            modelBuilder.Entity<CriminalRecordFile>()
                .HasIndex(p => new { p.CandidateId })
                .IsUnique(true);

            modelBuilder.Entity<Student>()
                .HasIndex(p => new { p.StudentNumber })
                .IsUnique(true);

            modelBuilder.Entity<Candidate>()
                .HasIndex(p => new { p.StudentId })
                .IsUnique(true);

            modelBuilder.Entity<Vote>()
                .HasIndex(p => new { p.VoterId })
                .IsUnique(true);
            modelBuilder.Entity<Vote>()
                .HasIndex(p => new { p.CandidateId })
                .IsUnique(true);
            modelBuilder.Entity<Vote>()
                .HasIndex(p => new { p.VotingPeriodId })
                .IsUnique(true);

            modelBuilder.Entity<VotingPeriod>()
                .HasIndex(p => new { p.ElectionTypeId })
                .IsUnique(true);

            modelBuilder.Entity<Department>()
                .HasIndex(p => new { p.Name })
                .IsUnique(true);

            base.OnModelCreating(modelBuilder);



            //modelBuilder.Entity<TranscriptFile>()
            //    .HasIndex(x => new { x.Candidate.Id }).IsUnique(true);
            //modelBuilder.Entity<CriminalRecordFile>()
            //    .HasIndex(p =>  new { p.Candidate.Id }, "CandidateId")
            //    .IsUnique(true);
        }

    }
}
