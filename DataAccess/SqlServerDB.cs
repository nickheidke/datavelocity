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
        public SqlServerDB(string connectionString)
        {
            _conn = new SqlConnection(connectionString);
        }

        public string getDatabase()
        {
            return _conn.Database;
        }

        public DataTable getAllRowCounts(bool blnIncludeZeros)
        {
            DataTable objResult;
            string sSQL = "";
            SqlDataReader objReader;

            _conn.Open();

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

            SqlCommand command = new SqlCommand(sSQL, _conn);

            objReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            objResult = new DataTable();
            objResult.Load(objReader);

            return objResult;
        }
    }
}
