using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.ObsService.Data;
using VotingAPI.ObsService.Entities;
using VotingAPI.ObsService.Interfaces;

namespace VotingAPI.ObsService.Services
{
    public class ObsStudentService : IObsStudentService
    {
        //string filePath;
        public ObsStudentService()
        {
            //string currentDirectory = Directory.GetCurrentDirectory();
            //filePath = Path.Combine(currentDirectory, "..", "..", "..", "..", "..", "Infrastructure", "VotingAPI.ObsService", "Data", "students.json");
        }
        public Student FindUserByStudentId()
        {
            throw new NotImplementedException();
        }

        public Student FindUserByUserName(string userName)
        {
            List<Student> studentList = GetStudents().ToList();
            var student = studentList.FirstOrDefault(x => x.UserName == userName);
            //var studentResponse = JsonConvert.SerializeObject(student);
            return student;
        }

        public ICollection<Student> GetStudents() //todo şimdilik string olarak alıyom ama daha sonraları bunları çevirecem
        {
            List<Student> studentList = JsonConvert.DeserializeObject<List<Student>>(StudentData.Students);

            return studentList;
        }
    }
}
