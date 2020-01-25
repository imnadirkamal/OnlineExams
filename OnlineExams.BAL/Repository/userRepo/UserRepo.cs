using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExams.BAL.Models;
using System.Data;
using DayCareManager.DAL;

namespace OnlineExams.BAL.Repository
{
    public class UserRepo: IUserRepo
    {
        DataSet ds;
        public DataSet UserLoginAuthentication(UserInfo _userInfo)
        {
            try
            {
                cDBServices objcDB = new cDBServices();
                Parameter paramUserName = new Parameter("UserName", DbType.String, _userInfo.Username);
                Parameter paramPassword = new Parameter("Password", DbType.String, _userInfo.Password);

                Parameters spParam = new Parameters();
                spParam.Add(paramUserName);
                spParam.Add(paramPassword);

                ds = objcDB.ExecuteSPReturnDataSet("UserLoginAuthentication", spParam, "Login");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
}   
