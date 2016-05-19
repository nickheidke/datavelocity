using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class Database
    {
        protected string _connectionString;
        private SqlConnection _conn;

        public Database(string connectionString)
        {
            _connectionString = connectionString;
            _conn = new SqlConnection(connectionString);
        }

        abstract public string getDatabase();
        abstract public int getTotalRowCount();
        abstract public DataTable getAllRowCounts(bool blnIncludeZeros);
        abstract public DataTable getCustomResults(string sql);

        #region Private
        abstract protected int _getScalar(string sql);
        abstract protected DataTable _getDataTable(string sql);
        #endregion

    }
}
