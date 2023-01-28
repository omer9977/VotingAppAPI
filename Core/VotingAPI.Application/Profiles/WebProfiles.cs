using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VotingAPI.Application.Dto.Request.Student;
using VotingAPI.Application.Dto.Response.Candidate;
using VotingAPI.Application.Dto.Response.ProfilePhoto;
using VotingAPI.Application.Dto.Response.Student;
using VotingAPI.Domain.Entities;
using VotingAPI.Domain.Entities.FileTypes;

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


        }
    }
}
