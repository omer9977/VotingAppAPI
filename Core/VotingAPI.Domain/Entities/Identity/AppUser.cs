//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;
//using VotingAPI.Domain.Entities.Common;

//namespace VotingAPI.Domain.Entities.Identity
//{
//    public class AppUser : IdentityUser<int>
//    {
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public override int Id { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public string UserName { get; set; }
//        public Token Token { get; set; }
//    }
//}
