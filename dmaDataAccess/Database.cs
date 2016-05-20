using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class Database : IDisposable
    {
        protected string _connectionString;
        bool _disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private SqlConnection _conn;

        public Database(string connectionString)
        {
            _connectionString = connectionString;
            _conn = new SqlConnection(connectionString);
        }

        public void Dispose() 
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                _connectionString = null;
            }

            _conn = null;
            _disposed = true;
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
