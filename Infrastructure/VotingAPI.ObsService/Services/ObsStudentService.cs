using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.ObsService.Entities;
using VotingAPI.ObsService.Interfaces;

namespace VotingAPI.ObsService.Services
{
    public class ObsStudentService : IObsStudentService
    {
        string filePath;
        public ObsStudentService()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            filePath = Path.Combine(currentDirectory, "..", "..", "..", "..", "..", "Infrastructure", "VotingAPI.ObsService", "Data", "students.json");
        }
        public string FindUserByStudentId()
        {
            throw new NotImplementedException();
        }

        public string FindUserByUserName(string userName)
        {
            List<Student> studentList = JsonConvert.DeserializeObject<List<Student>>(GetStudents());
            var student = studentList.FirstOrDefault(x => x.UserName == userName);
            var studentResponse = JsonConvert.SerializeObject(student);
            return studentResponse;
        }

        public string GetStudents() //todo şimdilik string olarak alıyom ama daha sonraları bunları çevirecem
        {
            string json = File.ReadAllText(filePath);
            return json;
        }
    }
}
