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
            bool studentAdded = await _studentWriteRepo.AddAsync(studentMapped);
            await _studentWriteRepo.SaveChangesAsync();

            var response = await _studentReadRepo.GetSingleAsync(x => x.StudentNumber == student.StudentNumber);
            var responseMapped = _mapper.Map<AddStudentResponse>(response);
            return responseMapped;
        }

        public async Task<GetStudentResponse> GetStudentByStudentNumber(long studentNumber) 
        {
            var studentDb = await _studentReadRepo.GetSingleAsync(s => s.StudentNumber == studentNumber, false);
            var getStudentResponse = _mapper.Map<GetStudentResponse>(studentDb);
            return getStudentResponse;
        }

        public GetStudentListResponse GetStudentList()
        {
            var studentsDb = _studentReadRepo.GetAll(false).AsEnumerable();
            var studentListResponse = _mapper.Map<GetStudentListResponse>(studentsDb);
            return studentListResponse;
        }
    }
}
