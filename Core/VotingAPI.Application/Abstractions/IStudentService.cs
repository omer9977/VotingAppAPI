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
        Task<AddStudentResponse> AddStudentAsync(AddStudentRequest student);
    }
}
