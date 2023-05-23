using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.ObsService.Data
{
    public static class StudentData
    {
        public static readonly string Students = @"[
  {
    ""UserName"": ""123456789"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Sarah"",
    ""LastName"": ""Karadeniz"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Mechanical Engineering"",
    ""Year"": 1
  },
  {
    ""UserName"": ""987654321"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Metin"",
    ""LastName"": ""İnce"",
    ""Faculty"": ""Science"",
    ""Department"": ""Mechanical Engineering"",
    ""Year"": 4
  },
  {
    ""UserName"": ""567891234"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Selin"",
    ""LastName"": ""Anadol"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Computer Engineering"",
    ""Year"": 1
  },
  {
    ""UserName"": ""987123456"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Selin"",
    ""LastName"": ""Yılmaz"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Architecture"",
    ""Year"": 2
  },
  {
    ""UserName"": ""654789321"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Metin"",
    ""LastName"": ""İnce"",
    ""Faculty"": ""Science"",
    ""Department"": ""Electrical Engineering"",
    ""Year"": 3
  },
  {
    ""UserName"": ""321456987"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Emily"",
    ""LastName"": ""Özer"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Physics"",
    ""Year"": 4
  },
  {
    ""UserName"": ""789123654"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Burak"",
    ""LastName"": ""Yılmaz"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Electrical Engineering"",
    ""Year"": 3
  },
  {
    ""UserName"": ""456789123"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Selin"",
    ""LastName"": ""Aydoğan"",
    ""Faculty"": ""Architecture"",
    ""Department"": ""Architecture"",
    ""Year"": 4
  },
  {
    ""UserName"": ""789654321"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""David"",
    ""LastName"": ""İnce"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Mechanical Engineering"",
    ""Year"": 4
  },
  {
    ""UserName"": ""123789456"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Barış"",
    ""LastName"": ""Aydoğan"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Physics"",
    ""Year"": 4
  },
  {
    ""UserName"": ""321987654"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Ömer"",
    ""LastName"": ""Anadol"",
    ""Faculty"": ""Architecture"",
    ""Department"": ""Chemistry"",
    ""Year"": 3
  },
  {
    ""UserName"": ""654321987"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Emily"",
    ""LastName"": ""Yılmaz"",
    ""Faculty"": ""Architecture"",
    ""Department"": ""Fotonics"",
    ""Year"": 4
  },
  {
    ""UserName"": ""123456987"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Elif"",
    ""LastName"": ""Özer"",
    ""Faculty"": ""Science"",
    ""Department"": ""Chemistry"",
    ""Year"": 4
  },
  {
    ""UserName"": ""789456123"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Ömer"",
    ""LastName"": ""Aydoğan"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Electrical Engineering"",
    ""Year"": 1
  },
  {
    ""UserName"": ""321654789"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Mehmet"",
    ""LastName"": ""Erdoğan"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Mechanical Engineering"",
    ""Year"": 1
  },
  {
    ""UserName"": ""789321654"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Sarah"",
    ""LastName"": ""Erdoğan"",
    ""Faculty"": ""Science"",
    ""Department"": ""Fotonics"",
    ""Year"": 3
  },
  {
    ""UserName"": ""123789654"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Selin"",
    ""LastName"": ""Özer"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Architecture"",
    ""Year"": 1
  },
  {
    ""UserName"": ""654987321"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Mehmet"",
    ""LastName"": ""Kılıç"",
    ""Faculty"": ""Science"",
    ""Department"": ""Computer Engineering"",
    ""Year"": 2
  },
  {
    ""UserName"": ""321789456"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Emily"",
    ""LastName"": ""Erdoğan"",
    ""Faculty"": ""Architecture"",
    ""Department"": ""Chemistry"",
    ""Year"": 1
  },
  {
    ""UserName"": ""789654123"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Selin"",
    ""LastName"": ""İnce"",
    ""Faculty"": ""Science"",
    ""Department"": ""Electronics"",
    ""Year"": 3
  },
  {
    ""UserName"": ""456123789"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Ömer"",
    ""LastName"": ""Yılmaz"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Computer Engineering"",
    ""Year"": 3
  },
  {
    ""UserName"": ""123987654"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""İbrahim"",
    ""LastName"": ""Aydoğan"",
    ""Faculty"": ""Science"",
    ""Department"": ""Electronics"",
    ""Year"": 1
  },
  {
    ""UserName"": ""789456321"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Zeynep"",
    ""LastName"": ""Kılıç"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Physics"",
    ""Year"": 4
  },
  {
    ""UserName"": ""654321789"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Metin"",
    ""LastName"": ""Erdoğan"",
    ""Faculty"": ""Architecture"",
    ""Department"": ""Mechanical Engineering"",
    ""Year"": 4
  },
  {
    ""UserName"": ""321456789"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Ömer"",
    ""LastName"": ""Özer"",
    ""Faculty"": ""Architecture"",
    ""Department"": ""Computer Engineering"",
    ""Year"": 1
  },
  {
    ""UserName"": ""789123456"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""İbrahim"",
    ""LastName"": ""Kılıç"",
    ""Faculty"": ""Architecture"",
    ""Department"": ""Chemistry"",
    ""Year"": 2
  },
  {
    ""UserName"": ""654789123"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Metin"",
    ""LastName"": ""Yılmaz"",
    ""Faculty"": ""Architecture"",
    ""Department"": ""Architecture"",
    ""Year"": 4
  },
  {
    ""UserName"": ""321789654"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Metin"",
    ""LastName"": ""Yılmaz"",
    ""Faculty"": ""Science"",
    ""Department"": ""Mechanical Engineering"",
    ""Year"": 1
  },
  {
    ""UserName"": ""123456789"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Fahri"",
    ""LastName"": ""Karadeniz"",
    ""Faculty"": ""Architecture"",
    ""Department"": ""Electronics"",
    ""Year"": 3
  },
  {
    ""UserName"": ""987654321"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Burak"",
    ""LastName"": ""Anadol"",
    ""Faculty"": ""Science"",
    ""Department"": ""Fotonics"",
    ""Year"": 1
  }
]";
    }
}
