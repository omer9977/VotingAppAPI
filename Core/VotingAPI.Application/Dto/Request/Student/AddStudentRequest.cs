using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Request.Student
{
    public class AddStudentRequest
    {
        public int StudentNumber { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
