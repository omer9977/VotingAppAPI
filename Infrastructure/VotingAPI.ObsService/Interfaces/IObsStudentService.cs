using System.IO;
using System.Reflection;
using System.Text.Json.Nodes;

namespace VotingAPI.ObsService.Interfaces
{
    public interface IObsStudentService
    {
        string GetStudents();
        string FindUserByStudentId();
        string FindUserByUserName(string userName);


    }
}
