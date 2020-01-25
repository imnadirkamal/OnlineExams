using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace DayCareManager.DAL
{
    public class cDBServices
    {
        private IDAL _idal;
        private String _strDbType;

        internal String StrDbType
        {
            get { return _strDbType; }
            set { _strDbType = value; }
        }
        private String _strCon;

        internal String StrCon
        {
            get { return _strCon; }
            set { _strCon = value; }
        }

        private String GetAppSettings(String AppSettingsKey)
        {
            return ConfigurationManager.AppSettings[AppSettingsKey].ToString();
        }


        public cDBServices()
        {
            try
            {
                _strDbType = GetAppSettings("DBType");
                _strCon = GetAppSettings("conStr");
                GetInstance();

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        private void GetInstance()
        {
            switch (_strDbType)
            {
                case "SQL":
                    _idal = new SQLDAL(_strCon);
                    break;
                default:
                    break;

            }
        }

        public DataSet ExecuteSPReturnDataSet(String SPName, String TableName)
        {
            return _idal.ExecuteSPReturnDataSet(SPName, TableName);
        }

        public DataSet ExecuteSPReturnDataSet(String SPName, Parameters paramerters, String TableName)
        {
            return _idal.ExecuteSPReturnDataSet(SPName, paramerters, TableName);
        }

        public DataSet ExecuteQueryReturnDataSet(String Query, String TableName)
        {
            return _idal.ExecuteQueryReturnDataSet(Query, TableName);
        }

        DataSet ExecuteQueryReturnDataSet(String Query, Parameters QRParams, String TableName)
        {
            return _idal.ExecuteQueryReturnDataSet(Query, QRParams, TableName);
        }
    }
}
