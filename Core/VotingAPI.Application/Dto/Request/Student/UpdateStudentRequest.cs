using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Request.Student
{
    public class UpdateStudentRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentNumber { get; set; }
        public int DepartmentId { get; set; }
    }
}
