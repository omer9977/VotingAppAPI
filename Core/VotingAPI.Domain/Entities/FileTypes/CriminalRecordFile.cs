using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities.Common;
using File = VotingAPI.Domain.Entities.Common.File;

namespace VotingAPI.Domain.Entities.FileTypes
{
    [Table("CriminalRecordFiles", Schema = "dbo")]
    public class CriminalRecordFile : File
    {

    }
}
