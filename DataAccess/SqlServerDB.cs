using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SqlServerDB
    {
        private SqlConnection _conn;

        #region Constructors
        public SqlServerDB(string connectionString)
        {
            _conn = new SqlConnection(connectionString);
        }
        #endregion

        #region Public
        public string getDatabase()
        {
            return _conn.Database;
        }

        public int getTotalRowCount()
        {
            string sSQL = " SELECT SUM(pa.rows) RowCnt " +
                         "FROM sys.tables ta " +
                         "INNER JOIN sys.partitions pa " +
                         "ON pa.OBJECT_ID = ta.OBJECT_ID " +
                         "INNER JOIN sys.schemas sc " +
                         "ON ta.schema_id = sc.schema_id " +
                         "WHERE ta.is_ms_shipped = 0 AND pa.index_id IN (1,0);";

            return _getScalar(sSQL);

        }

        public DataTable getAllRowCounts(bool blnIncludeZeros)
        {
            string sSQL;
            if (blnIncludeZeros)
            {
                sSQL = "SELECT sc.name +'.'+ ta.name TableName " +
                                ",SUM(pa.rows) RowCnt " +
                                "FROM sys.tables ta " +
                                "INNER JOIN sys.partitions pa " +
                                "ON pa.OBJECT_ID = ta.OBJECT_ID " +
                                "INNER JOIN sys.schemas sc " +
                                "ON ta.schema_id = sc.schema_id " +
                                "WHERE ta.is_ms_shipped = 0 AND pa.index_id IN (1,0) " +
                                "GROUP BY sc.name,ta.name " +
                                "ORDER BY SUM(pa.rows) DESC";
            }
            else
            {
                sSQL = "SELECT sc.name +'.'+ ta.name TableName " +
                                ",SUM(pa.rows) RowCnt " +
                                "FROM sys.tables ta " +
                                "INNER JOIN sys.partitions pa " +
                                "ON pa.OBJECT_ID = ta.OBJECT_ID " +
                                "INNER JOIN sys.schemas sc " +
                                "ON ta.schema_id = sc.schema_id " +
                                "WHERE ta.is_ms_shipped = 0 AND pa.index_id IN (1,0) " +
                                "GROUP BY sc.name,ta.name " +
                                "HAVING SUM(pa.Rows) > 0 " +
                                "ORDER BY SUM(pa.rows) DESC";

            }

            return _getDataTable(sSQL);
        }

        public DataTable getCustomResults(string sql)
        {
            return _getDataTable(sql);
        }
        #endregion

        #region Private
        private int _getScalar(string sql)
        {
            int iResult;

            _conn.Open();


            SqlCommand command = new SqlCommand(sql, _conn);

            iResult = int.Parse(command.ExecuteScalar().ToString());
            _conn.Close();

            return iResult;
        }


        private DataTable _getDataTable(string sql)
        {
            DataTable objResult;
            string sSQL = "";
            SqlDataReader objReader;

            _conn.Open();

            SqlCommand command = new SqlCommand(sql, _conn);

            objReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            objResult = new DataTable();
            objResult.Load(objReader);

            return objResult;
        }
        #endregion
    }
}
