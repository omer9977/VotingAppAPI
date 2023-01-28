using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Domain.Entities.Common
{
    public class File : BaseEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public Candidate Candidate { get; set; }
        public string Storage { get; set; }
        public int CandidateId { get; set; }
        //[ForeignKey("TranscriptFiles")]
        //[Column("TranscriptFileId")]
        //public int TranscriptFileId { get; set; }
        //[ForeignKey("CriminalRecordFiles")]
        //[Column("CriminalRecordFileId")]
        //public int CriminalRecordFileId { get; set; }
        public virtual short ApprovedStatus { get; set; }
    }
}
