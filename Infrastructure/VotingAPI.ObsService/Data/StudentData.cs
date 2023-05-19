﻿using System;
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
    ""UserName"": ""sarahkaradeniz@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Sarah"",
    ""LastName"": ""Karadeniz"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Mechanical Engineering"",
    ""Year"": 1
  },
  {
    ""UserName"": ""metinince@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Metin"",
    ""LastName"": ""İnce"",
    ""Faculty"": ""Science"",
    ""Department"": ""Mechanical Engineering"",
    ""Year"": 4
  },
  {
    ""UserName"": ""selinanadol@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Selin"",
    ""LastName"": ""Anadol"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Computer Engineering"",
    ""Year"": 1
  },
  {
    ""UserName"": ""selinyilmaz@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Selin"",
    ""LastName"": ""Yılmaz"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Architecture"",
    ""Year"": 2
  },
  {
    ""UserName"": ""metinince@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Metin"",
    ""LastName"": ""İnce"",
    ""Faculty"": ""Science"",
    ""Department"": ""Electrical Engineering"",
    ""Year"": 3
  },
  {
    ""UserName"": ""emilyozer@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Emily"",
    ""LastName"": ""Özer"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Physics"",
    ""Year"": 4
  },
  {
    ""UserName"": ""burakyilmaz@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Burak"",
    ""LastName"": ""Yılmaz"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Electrical Engineering"",
    ""Year"": 3
  },
  {
    ""UserName"": ""selinaydogan@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Selin"",
    ""LastName"": ""Aydoğan"",
    ""Faculty"": ""Architecture"",
    ""Department"": ""Architecture"",
    ""Year"": 4
  },
  {
    ""UserName"": ""davidince@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""David"",
    ""LastName"": ""İnce"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Mechanical Engineering"",
    ""Year"": 4
  },
  {
    ""UserName"": ""barisaydogan@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Barış"",
    ""LastName"": ""Aydoğan"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Physics"",
    ""Year"": 4
  },
  {
    ""UserName"": ""omeranadol@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Ömer"",
    ""LastName"": ""Anadol"",
    ""Faculty"": ""Architecture"",
    ""Department"": ""Chemistry"",
    ""Year"": 3
  },
  {
    ""UserName"": ""emilyyilmaz@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Emily"",
    ""LastName"": ""Yılmaz"",
    ""Faculty"": ""Architecture"",
    ""Department"": ""Fotonics"",
    ""Year"": 4
  },
  {
    ""UserName"": ""elifozer@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Elif"",
    ""LastName"": ""Özer"",
    ""Faculty"": ""Science"",
    ""Department"": ""Chemistry"",
    ""Year"": 4
  },
  {
    ""UserName"": ""omeraydogan@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Ömer"",
    ""LastName"": ""Aydoğan"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Electrical Engineering"",
    ""Year"": 1
  },
  {
    ""UserName"": ""mehmeterdogan@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Mehmet"",
    ""LastName"": ""Erdoğan"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Mechanical Engineering"",
    ""Year"": 1
  },
  {
    ""UserName"": ""saraherdogan@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Sarah"",
    ""LastName"": ""Erdoğan"",
    ""Faculty"": ""Science"",
    ""Department"": ""Fotonics"",
    ""Year"": 3
  },
  {
    ""UserName"": ""selinozer@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Selin"",
    ""LastName"": ""Özer"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Architecture"",
    ""Year"": 1
  },
  {
    ""UserName"": ""mehmetkilic@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Mehmet"",
    ""LastName"": ""Kılıç"",
    ""Faculty"": ""Science"",
    ""Department"": ""Computer Engineering"",
    ""Year"": 2
  },
  {
    ""UserName"": ""emilyerdogan@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Emily"",
    ""LastName"": ""Erdoğan"",
    ""Faculty"": ""Architecture"",
    ""Department"": ""Chemistry"",
    ""Year"": 1
  },
  {
    ""UserName"": ""selinince@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Selin"",
    ""LastName"": ""İnce"",
    ""Faculty"": ""Science"",
    ""Department"": ""Electronics"",
    ""Year"": 3
  },
  {
    ""UserName"": ""omeryilmaz@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Ömer"",
    ""LastName"": ""Yılmaz"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Computer Engineering"",
    ""Year"": 3
  },
  {
    ""UserName"": ""ibrahimaydogan@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""İbrahim"",
    ""LastName"": ""Aydoğan"",
    ""Faculty"": ""Science"",
    ""Department"": ""Electronics"",
    ""Year"": 1
  },
  {
    ""UserName"": ""zeynepkilic@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Zeynep"",
    ""LastName"": ""Kılıç"",
    ""Faculty"": ""Engineering"",
    ""Department"": ""Physics"",
    ""Year"": 4
  },
  {
    ""UserName"": ""metinerdogan@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Metin"",
    ""LastName"": ""Erdoğan"",
    ""Faculty"": ""Architecture"",
    ""Department"": ""Mechanical Engineering"",
    ""Year"": 4
  },
  {
    ""UserName"": ""omerozer@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Ömer"",
    ""LastName"": ""Özer"",
    ""Faculty"": ""Architecture"",
    ""Department"": ""Computer Engineering"",
    ""Year"": 1
  },
  {
    ""UserName"": ""ibrahimkilic@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""İbrahim"",
    ""LastName"": ""Kılıç"",
    ""Faculty"": ""Architecture"",
    ""Department"": ""Chemistry"",
    ""Year"": 2
  },
  {
    ""UserName"": ""metinyilmaz@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Metin"",
    ""LastName"": ""Yılmaz"",
    ""Faculty"": ""Architecture"",
    ""Department"": ""Architecture"",
    ""Year"": 4
  },
  {
    ""UserName"": ""metinyilmaz@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Metin"",
    ""LastName"": ""Yılmaz"",
    ""Faculty"": ""Science"",
    ""Department"": ""Mechanical Engineering"",
    ""Year"": 1
  },
  {
    ""UserName"": ""fahrikaradeniz@std.iyte.edu.tr"",
    ""PasswordHash"": ""password123"",
    ""Name"": ""Fahri"",
    ""LastName"": ""Karadeniz"",
    ""Faculty"": ""Architecture"",
    ""Department"": ""Electronics"",
    ""Year"": 3
  },
  {
    ""UserName"": ""burakanadol@std.iyte.edu.tr"",
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
