//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using VotingAPI.Application.Data.DataModels;
//using VotingAPI.Domain.Entities;

//namespace VotingAPI.Application.Data.ObsData
//{
//    public static class StudentData
//    {
//        public static ICollection<Student> students;
//        public static ICollection<Student> Seed()
//        {

//            return students;
//        }
//        private static Student MapToStudent(this StudentModel studentModel)
//        {
//            var student = new Student
//            {
//                Name = studentModel.Name,
//                LastName = studentModel.LastName,
//                Email = $"{studentModel.UserName}@std.iyte.edu.tr", // E-posta, kullanıcı adıyla birleştirilerek oluşturuluyor
//                StudentId = GenerateStudentId(),
//                DepartmentId = GetDepartmentId(studentModel.Faculty, studentModel.Department),
//                UserRole = UserRole.Student
//            };

//            return student;
//        }
//    }

//}
