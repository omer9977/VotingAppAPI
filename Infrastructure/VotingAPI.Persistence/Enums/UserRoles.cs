using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Persistence.Enums
{
    public enum UserRoles
    {
        [Description("Admin")]
        Admin,
        [Description("Student")]
        Student,
        [Description("Candidate")]
        Candidate
    }
}
