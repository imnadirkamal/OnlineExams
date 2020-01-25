﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExams.DAL
{
    interface IDAL
    {
        void OpenConnection();
        void CloseConnection();
        DataSet ExecuteSPReturnDataSet(String SPName, String TableName);
        DataSet ExecuteSPReturnDataSet(String SPName, Parameters SPParams, String TableName);

        DataSet ExecuteQueryReturnDataSet(String Query, String TableName);
        DataSet ExecuteQueryReturnDataSet(String Query, Parameters QRParams, String TableName);

    }
}
