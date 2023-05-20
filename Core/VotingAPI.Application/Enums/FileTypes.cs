using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Enums
{
    public enum FileTypes
    {//todo şu değişken isimlerini düzelt amk
        [Description("profile-photos")]
        ProfilePhotos = 1,
        [Description("transcript-files")]
        Transcript = 2,
        [Description("criminal-record-files")]
        CriminalRecord = 3,
    }
}
