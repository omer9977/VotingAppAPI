using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Exceptions
{
    public static class ResultMessages
    {
        public const string AddedRecord = "The data added successfully!";
        public const string NotAddedRecord = "The data could not added!";
        public const string NotFoundRecord = "The data you were looking for was not found!";
        public const string FoundRecord = "The record found successfully!";
        public const string DeleteRecord = "The record deleted successfully!";
        public const string UserNotFound = "User not found in our database. Please register first!";

        public static string PropertyNotFound(string nameOfProperty)
        {
            return $"{nameOfProperty} could not found!";
        }

    }
}
