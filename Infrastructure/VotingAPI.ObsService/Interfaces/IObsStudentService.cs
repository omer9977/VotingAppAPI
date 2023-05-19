using System.IO;
using System.Reflection;
using System.Text.Json.Nodes;
using VotingAPI.ObsService.Entities;

namespace VotingAPI.ObsService.Interfaces
{
    public interface IObsStudentService
    {
        ICollection<Student> GetStudents();
        Student FindUserByStudentId();
        Student FindUserByUserName(string userName);


    }
}
