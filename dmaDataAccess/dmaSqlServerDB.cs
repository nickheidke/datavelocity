using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class dmaSqlServerDB : dmaDatabase
    {
        SqlConnection _conn;

        #region Constructors
        public dmaSqlServerDB(string connectionString) : base(connectionString) 
        {
            _conn = new SqlConnection(base._connectionString);
        }
        #endregion

        #region Public
        override public string DbName
        {
            get { return _conn.Database; }
        }

        override public int getTotalRowCount()
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

        override public DataTable getAllRowCounts(bool bIncludeZeros)
        {
            string sSQL;
            if (bIncludeZeros)
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

        override public DataTable getCustomResults(string sQuery)
        {
            return _getDataTable(sQuery);
        }
        #endregion

        #region Private
        override protected int _getScalar(string sQuery)
        {
            int iResult;

            _conn.Open();

            SqlCommand command = new SqlCommand(sQuery, _conn);

            iResult = int.Parse(command.ExecuteScalar().ToString());
            _conn.Close();

            return iResult;
        }


        override protected DataTable _getDataTable(string sQuery)
        {
            DataTable objResult;
            SqlDataReader objReader;

            _conn.Open();

            SqlCommand command = new SqlCommand(sQuery, _conn);

            objReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            objResult = new DataTable();
            objResult.Load(objReader);

            return objResult;
        }
        #endregion
        
    }
}
