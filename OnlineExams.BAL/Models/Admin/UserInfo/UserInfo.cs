using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExams.BAL.Models
{
    public class UserInfo
    {
        public int? ID { get; set; }
        public int? UserId { get; set; }
        public string Usergroup { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? GroupId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int? Status { get; set; }
        public int Test2 { get; set; }
    }
}
