using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Student;
using VotingAPI.Application.Dto.Response.Student;
using VotingAPI.Application.Exceptions;
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
        public List<GetStudentResponse> GetStudentList()
        {
            var studentsDb = _studentReadRepo.GetAll(false).ToList();
            var studentListResponse = _mapper.Map<List<GetStudentResponse>>(studentsDb);
            return studentListResponse;
        }

        public async Task<GetStudentResponse> GetStudentByIdAsync(int id)
        {
            var studentDb = await _studentReadRepo.GetByIdAsync(id);
            if (studentDb == null)
                throw new DataNotFoundException(id);

            var response = _mapper.Map<GetStudentResponse>(studentDb);
            return response;
        }

        public async Task<GetStudentResponse> GetStudentByStudentNumberAsync(long studentNumber)
        {
            var studentDb = await _studentReadRepo.GetSingleAsync(s => s.StudentNumber == studentNumber, false);
            if (studentDb == null)
                throw new DataNotFoundException(studentNumber);
            var getStudentResponse = _mapper.Map<GetStudentResponse>(studentDb);
            return getStudentResponse;
        }

        public async Task AddStudentAsync(AddStudentRequest student)
        {
            var studentMapped = _mapper.Map<Student>(student);//todo : 1 Burayı anlamadım Student tipinde neden veriyoz ki
            bool addedStatus = await _studentWriteRepo.AddAsync(studentMapped);
            if (!addedStatus)
                throw new DataAddedException();

            await _studentWriteRepo.SaveChangesAsync();
        }
        //todo : 5 buralarda null dönmesi sonucu çok fazla throw atma yapıyorum, ben repolarda bu işlemin yapılmasını daha uygun görüyorum fakat single responsibility ilkesine ters imiş. Fakat 
        //bu şekilde de kod tekrarı yaşanıyor
    }
}
