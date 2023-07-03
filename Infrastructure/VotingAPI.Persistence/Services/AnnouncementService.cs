using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Announcement;
using VotingAPI.Application.Dto.Request.Mail;
using VotingAPI.Application.Dto.Response.Announcement;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;
using VotingAPI.ObsService.Interfaces;

namespace VotingAPI.Persistence.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementReadRepo _announcementReadRepo;
        private readonly IAnnouncementWriteRepo _announcementWriteRepo;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        private readonly IObsStudentService _obsStudentService;

        public AnnouncementService(
            IAnnouncementWriteRepo announcementWriteRepo, 
            IAnnouncementReadRepo announcementReadRepo,
            IMapper mapper,
            IMailService mailService,
            IObsStudentService obsStudentService
            )
        {
            _announcementReadRepo = announcementReadRepo;
            _announcementWriteRepo = announcementWriteRepo;
            _mapper = mapper;
            _mailService = mailService;
            _obsStudentService = obsStudentService;
        }
        public async Task<bool> CreateAnnouncementAsync(AddAnnouncementRequest addAnnouncementRequest)
        {
            var announcementMapped = _mapper.Map<Announcement>(addAnnouncementRequest);
            await _announcementWriteRepo.AddAsync(announcementMapped);
            var obsUsers = _obsStudentService.GetStudents();
            var userMails = obsUsers.Select(x => x.Email).Distinct().ToList();
            foreach (var item in userMails)
            {
                await _mailService.SendEmailAsync(new MailRequest() 
                { 
                    ToEmail = item, 
                    Subject = addAnnouncementRequest.Name,
                    Body = addAnnouncementRequest.Description,
                });
            }
            return await _announcementWriteRepo.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAnnouncementAsync(int announcementId)
        {
            await _announcementWriteRepo.RemoveByIdAsync(announcementId);
            return await _announcementWriteRepo.SaveChangesAsync() > 0;
        }

        public async Task<GetAnnouncementListResponse> GetAnnouncementListAsync()
        {
            var announcements = await _announcementReadRepo.GetAll().OrderByDescending(x => x.Id).ToListAsync();
            var announcementsMapped = _mapper.Map<List<GetAnnouncementResponse>>(announcements);
            return new GetAnnouncementListResponse() { AnnouncementList = announcementsMapped };
        }
    }
}
