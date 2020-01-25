using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DayCareManager.DAL
{
    internal class SQLDAL : IDAL
    {
        //private MySqlConnection _SqlCon;

        private SqlConnection _SqlCon;
        private String _ConString;

        public SQLDAL(String MyConString)
        {
            _ConString = MyConString;
        }

        public void OpenConnection()
        {
            try
            {

                _SqlCon = new SqlConnection(_ConString);
                _SqlCon.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().Name + "::" + ex.Message);
            }

        }
        public void CloseConnection()
        {
            try
            {
                if (_SqlCon.State != ConnectionState.Closed)
                    _SqlCon.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().Name + "::" + ex.Message);
            }

        }
        public DataSet ExecuteSPReturnDataSet(String SPName, Parameters SPParams, String strTableName)
        {

            SqlDataAdapter oAdapter;
            DataTable oTable = new DataTable(strTableName);
            DataSet oDataSet = new DataSet(); ;
            try
            {
                oAdapter = new SqlDataAdapter();
                oAdapter = ExecSPReturnAdapter(SPName, SPParams);
                oAdapter.Fill(oTable);
                oDataSet.Merge(oTable);
                return oDataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().Name + "::" + ex.Message);
            }
            finally
            {
                oAdapter = null;
            }
        }
        public DataSet ExecuteSPReturnDataSet(String SPName, String strTableName)
        {
            SqlDataAdapter oAdapter;
            DataTable oTable = new DataTable(strTableName);
            DataSet oDataSet = new DataSet(); ;
            try
            {
                oAdapter = new SqlDataAdapter();
                oAdapter = ExecSPReturnAdapter(SPName);
                oAdapter.Fill(oTable);
                oDataSet.Merge(oTable);
                return oDataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().Name + "::" + ex.Message);
            }
            finally
            {
                oAdapter = null;
            }
        }


        public SqlDataAdapter ExecSPReturnAdapter(String SPName)
        {
            SqlDataAdapter oAdapter;
            SqlCommand ocmd;
            try
            {
                OpenConnection();
                ocmd = new SqlCommand(SPName, _SqlCon);
                ocmd.CommandType = CommandType.StoredProcedure;
                // ocmd.CommandType = CommandType.Text;

                oAdapter = new SqlDataAdapter(ocmd);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().Name + "::" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return oAdapter;
        }
        public SqlDataAdapter ExecSPReturnAdapter(String SPName, Parameters SPParams)
        {
            SqlDataAdapter oAdapter;
            SqlCommand ocmd;
            try
            {
                OpenConnection();
                ocmd = new SqlCommand(SPName, _SqlCon);
                ocmd.CommandType = CommandType.StoredProcedure;
                // ocmd.CommandType = CommandType.Text;
                SqlParameter sqlParam;

                foreach (Parameter param in SPParams)
                {
                    sqlParam = new SqlParameter();
                    // sqlParam.ParameterName = "?" + param.ParamName;
                    sqlParam.ParameterName = "@" + param.ParamName;
                    sqlParam.Value = param.Value;
                    sqlParam.DbType = param.Dbtype;
                    sqlParam.Direction = ParameterDirection.Input;

                    ocmd.Parameters.Add(sqlParam);
                    sqlParam = null;
                }
                oAdapter = new SqlDataAdapter(ocmd);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().Name + "::" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return oAdapter;
        }

        // Execute query retrun DS
        public DataSet ExecuteQueryReturnDataSet(String Query, String strTableName)
        {
            SqlDataAdapter oAdapter;
            DataTable oTable = new DataTable(strTableName);
            DataSet oDataSet = new DataSet(); ;
            try
            {
                oAdapter = new SqlDataAdapter();
                oAdapter = ExecQueryReturnAdapter(Query);
                oAdapter.Fill(oTable);
                oDataSet.Merge(oTable);
                return oDataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().Name + "::" + ex.Message);
            }
            finally
            {
                oAdapter = null;
            }
        }
        public DataSet ExecuteQueryReturnDataSet(String Query, Parameters QRParams, String strTableName)
        {

            SqlDataAdapter oAdapter;
            DataTable oTable = new DataTable(strTableName);
            DataSet oDataSet = new DataSet(); ;
            try
            {
                oAdapter = new SqlDataAdapter();
                oAdapter = ExecQueryReturnAdapter(Query, QRParams);
                oAdapter.Fill(oTable);
                oDataSet.Merge(oTable);
                return oDataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().Name + "::" + ex.Message);
            }
            finally
            {
                oAdapter = null;
            }
        }

        public SqlDataAdapter ExecQueryReturnAdapter(String SqlQuery)
        {
            SqlDataAdapter oAdapter;
            SqlCommand ocmd;
            try
            {
                OpenConnection();
                ocmd = new SqlCommand(SqlQuery, _SqlCon);
                ocmd.CommandType = CommandType.Text;

                oAdapter = new SqlDataAdapter(ocmd);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().Name + "::" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return oAdapter;
        }

        public SqlDataAdapter ExecQueryReturnAdapter(String Query, Parameters SPParams)
        {
            SqlDataAdapter oAdapter;
            SqlCommand ocmd;
            try
            {
                OpenConnection();
                ocmd = new SqlCommand(Query, _SqlCon);
                // ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandType = CommandType.Text;
                SqlParameter sqlParam;

                foreach (Parameter param in SPParams)
                {
                    sqlParam = new SqlParameter();
                    // sqlParam.ParameterName = "?" + param.ParamName;
                    sqlParam.ParameterName = "@" + param.ParamName;
                    sqlParam.Value = param.Value;
                    sqlParam.DbType = param.Dbtype;
                    sqlParam.Direction = ParameterDirection.Input;

                    ocmd.Parameters.Add(sqlParam);
                    sqlParam = null;
                }
                oAdapter = new SqlDataAdapter(ocmd);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.Name + "::" +
                    System.Reflection.MethodInfo.GetCurrentMethod().Name + "::" + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return oAdapter;
        }
    }
}
