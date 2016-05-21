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
    public abstract class dmaDatabase : IDisposable
    {
        protected string _connectionString;
        bool _disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        protected dmaDatabase(string connectionString)
        {
            _connectionString = connectionString;
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

            _disposed = true;
        }

        abstract public string DbName
        {
            get;
        }
        abstract public int getTotalRowCount();
        abstract public DataTable getAllRowCounts(bool bIncludeZeros);
        abstract public DataTable getCustomResults(string sQuery);

        #region Private
        abstract protected int _getScalar(string sql);
        abstract protected DataTable _getDataTable(string sql);
        #endregion

    }
}
