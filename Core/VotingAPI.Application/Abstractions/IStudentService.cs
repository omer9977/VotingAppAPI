using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Request.Student;
using VotingAPI.Application.Dto.Response.Student;

namespace VotingAPI.Application.Abstractions
{
    public interface IStudentService
    {
        List<GetStudentResponse> GetStudentList();
        Task<GetStudentResponse> GetStudentByIdAsync(int id);
        //Task<GetStudentResponse> GetStudentByStudentNumberAsync(long studentNumber);
        Task AddStudentAsync(AddStudentRequest addStudentRequest);
        Task UpdateStudentAsync(UpdateStudentRequest updateStudentRequest);
        Task DeleteStudentAsync(int id);
    }
}
