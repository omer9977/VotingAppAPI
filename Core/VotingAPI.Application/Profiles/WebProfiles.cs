using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VotingAPI.Application.Dto.Request.Student;
using VotingAPI.Application.Dto.Request.User;
using VotingAPI.Application.Dto.Response.Candidate;
using VotingAPI.Application.Dto.Response.ProfilePhoto;
using VotingAPI.Application.Dto.Response.Student;
using VotingAPI.Domain.Entities;
using VotingAPI.Domain.Entities.FileTypes;
using VotingAPI.Domain.Entities.Identity;

namespace VotingAPI.Application.Profiles
{
    public class WebProfiles : Profile
    {
        public WebProfiles() 
        {
            CreateMap<ProfilePhotoFile, AddProfilePhotoResponse>();
            CreateMap<Candidate, AddCandidateResponse>();
            CreateMap<AddStudentRequest, Student>();
            CreateMap<Student, AddStudentResponse>();
            CreateMap<List<Student>, GetStudentListResponse>();
            CreateMap<Student, GetStudentResponse>();
            CreateMap<Candidate, GetCandidateResponse>()
                .ForMember(c => c.StudentNumber, g => g.MapFrom(x => x.Student.StudentNumber))
                .ForMember(c => c.Name, g => g.MapFrom(x => x.Student.Name));
            CreateMap<CreateUserRequest, AppUser>();

            //todo burayı barışa sor her modelde mapper kullanmaya gerek var mı?
        }
    }
}
