using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Student;
using VotingAPI.Application.Dto.Response.Student;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Persistence.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IStudentReadRepo _studentReadRepo;
        private readonly IStudentWriteRepo _studentWriteRepo;

        public StudentService(IMapper mapper, IStudentReadRepo studentReadRepo, IStudentWriteRepo studentWriteRepo)
        {
            _mapper = mapper;
            _studentReadRepo = studentReadRepo;
            _studentWriteRepo = studentWriteRepo;
        }
        public async Task<AddStudentResponse> AddStudentAsync(AddStudentRequest student)
        {
            var studentMapped = _mapper.Map<Student>(student);//todo Burayı anlamadım Student tipinde neden veriyoz ki
            var studentResponse = await _studentWriteRepo.AddAsync(studentMapped);
            var response = _mapper.Map<AddStudentResponse>(studentResponse);
            return response;
        }
    }
}
