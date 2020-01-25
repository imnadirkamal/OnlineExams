using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace OnlineExams.BAL.Repository
{
    public interface ITestRepo
    {
        DataSet GetData();
    }
}
