using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayCareManager.DAL
{
    public class Parameter
    {
        private string _paramName;

        public string ParamName
        {
            get { return _paramName; }
            set { _paramName = value; }
        }
        private System.Data.DbType _dbtype;

        public System.Data.DbType Dbtype
        {
            get { return _dbtype; }
            set { _dbtype = value; }
        }


        //private System.Data.SqlDbType _sqldbtype;

        //public System.Data.SqlDbType Sqldbtype
        //{
        //    get { return _sqldbtype; }
        //    set { _sqldbtype = value; }
        // }


        private object _value;
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        //public Parameter(String ParamName, System.Data.SqlDbType datatype, object Value)
        //{

        //    _paramName = ParamName;
        //    _sqldbtype = datatype;
        //    _value = Value;
        //}
        public Parameter(String ParamName, System.Data.DbType datatype, object Value)
        {

            _paramName = ParamName;
            _dbtype = datatype;
            _value = Value;
        }
    }
}
