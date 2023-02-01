using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Exceptions
{
    public static class ResultMessages
    {
        public const string AddedRecord = "The record added successfully!";
        public const string NotAddedRecord = "The record could not added!";
        public const string NotFoundRecord = "The record you were looking for was not found!";
        public const string FoundRecord = "The record found successfully!";
        public const string DeleteRecord = "The record deleted successfully!";

        public static string PropertyNotFound(string nameOfProperty)
        {
            return $"{nameOfProperty} could not found!";
        }

    }
}
