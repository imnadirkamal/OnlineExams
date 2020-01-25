using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using OnlineExams.BAL.Models;

namespace OnlineExams.BAL.Repository
{
    public interface IUserRepo
    {
        DataSet UserLoginAuthentication(UserInfo _userinfo);
    }
}
