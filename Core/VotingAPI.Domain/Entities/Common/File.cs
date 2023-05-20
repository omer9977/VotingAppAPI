//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using VotingAPI.Domain.Entities.Identity;

//namespace VotingAPI.Domain.Entities.Common
//{
//    [Table("Files", Schema = "dbo")]
//    public class File : BaseEntity
//    {
//        public string FileName { get; set; }
//        public string Path { get; set; }
//        public AppUser User { get; set; }
//        public string Storage { get; set; }
//        [ForeignKey("AspNetUsers")]
//        public int UserId { get; set; }
//        [ForeignKey("FileTypes")]
//        public short FileTypeId { get; set; }
//        //[ForeignKey("TranscriptFiles")]
//        //[Column("TranscriptFileId")]
//        //public int TranscriptFileId { get; set; }
//        //[ForeignKey("CriminalRecordFiles")]
//        //[Column("CriminalRecordFileId")]
//        //public int CriminalRecordFileId { get; set; }
//        public virtual short ApprovedStatus { get; set; }
//    }
//}
