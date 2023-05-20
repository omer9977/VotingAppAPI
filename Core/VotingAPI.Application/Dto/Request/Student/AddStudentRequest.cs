using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Request.Student
{
    public class AddStudentRequest
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Year { get; set; }
        public int? DepartmentId { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}