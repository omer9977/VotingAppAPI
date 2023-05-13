using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VotingAPI.Tests
{
    public class StudentModelService
    {
        public string GenerateRandomStudentModelsJson(int count)
        {
            var studentModels = GenerateRandomStudentModels(count);
            return JsonConvert.SerializeObject(studentModels, Formatting.Indented);
        }

        private List<StudentModel> GenerateRandomStudentModels(int count)
        {
            var studentModels = new List<StudentModel>();

            for (int i = 0; i < count; i++)
            {
                var studentModel = new StudentModel
                {
                    PasswordHash = GenerateRandomPasswordHash(),
                    Name = GenerateRandomName(),
                    LastName = GenerateRandomLastName(),
                    Faculty = GenerateRandomFaculty(),
                    Department = GenerateRandomDepartment(),
                    Year = GenerateRandomYear()
                };

                studentModels.Add(studentModel);
            }

            return studentModels;
        }

        //private string GenerateRandomUserName()
        //{
        //    var random = new Random();
        //    var randomId = random.Next(1000, 9999);
        //    return $"user{randomId}";
        //}

        private string GenerateRandomPasswordHash()
        {
            return "password123"; // Burada rastgele bir şifre oluşturmanız gerekebilir
        }

        private string GenerateRandomName()
        {
            var random = new Random();
            var names = new[] { "Ömer", "Barış", "Zeynep", "Emily", "David", "Sarah", "Fahri", "Onur", "Metin", "Burak", "Selin", "İbrahim", "Elif", "Mehmet" };
            return names[random.Next(names.Length)];
        }

        private string GenerateRandomLastName()
        {
            var random = new Random();
            var lastNames = new[] { "Yılmaz", "Özer", "Karadeniz", "Anadol", "Aydoğan", "Erdoğan", "İnce", "Kılıç" };
            return lastNames[random.Next(lastNames.Length)];
        }

        private string GenerateRandomFaculty()
        {
            var random = new Random();
            var faculties = new[] { "Engineering", "Architecture", "Science" };
            return faculties[random.Next(faculties.Length)];
        }

        private string GenerateRandomDepartment()
        {
            var random = new Random();
            var departments = new[] { "Computer Engineering", "Electrical Engineering", "Electronics", "Fotonics", "Physics", "Chemistry", "Architecture", "Mechanical Engineering" };
            return departments[random.Next(departments.Length)];
        }

        private int GenerateRandomYear()
        {
            var random = new Random();
            return random.Next(1, 5);
        }
    }
}
