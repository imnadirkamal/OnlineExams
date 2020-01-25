using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DayCareManager.DAL;

namespace OnlineExams.BAL.Repository
{
    public class TestRepo: ITestRepo
    {
        DataSet ds = new DataSet();
        public DataSet GetData()
        {
            try
            {
                cDBServices objDB = new cDBServices();
                Parameters spParam = new Parameters();
                ds = objDB.ExecuteSPReturnDataSet("GetData", spParam, "TestData");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
