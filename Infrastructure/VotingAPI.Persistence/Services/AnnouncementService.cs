using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Announcement;
using VotingAPI.Application.Dto.Response.Announcement;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Persistence.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementReadRepo _announcementReadRepo;
        private readonly IAnnouncementWriteRepo _announcementWriteRepo;
        private readonly IMapper _mapper;
        public AnnouncementService(
            IAnnouncementWriteRepo announcementWriteRepo, 
            IAnnouncementReadRepo announcementReadRepo,
            IMapper mapper
            )
        {
            _announcementReadRepo = announcementReadRepo;
            _announcementWriteRepo = announcementWriteRepo;
            _mapper = mapper;
        }
        public async Task<bool> CreateAnnouncementAsync(AddAnnouncementRequest addAnnouncementRequest)
        {
            var announcementMapped = _mapper.Map<Announcement>(addAnnouncementRequest);
            await _announcementWriteRepo.AddAsync(announcementMapped);
            return await _announcementWriteRepo.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAnnouncementAsync(int announcementId)
        {
            await _announcementWriteRepo.RemoveByIdAsync(announcementId);
            return await _announcementWriteRepo.SaveChangesAsync() > 0;
        }

        public async Task<GetAnnouncementListResponse> GetAnnouncementListAsync()
        {
            var announcements = await _announcementReadRepo.GetAll().ToListAsync();
            var announcementsMapped = _mapper.Map<List<GetAnnouncementResponse>>(announcements);
            return new GetAnnouncementListResponse() { AnnouncementList = announcementsMapped };
        }
    }
}
