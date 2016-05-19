using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.ConnectionUI;
using ZedGraph;
using System.IO;
using DataAccess;

namespace DataMovementAnalyzer
{
    public partial class frmDataMovementAnalyzer : Form
    {
        private int iCurrentRows, iTotalTime, iInitialRows, iPreviousRows, iMaxRPS, iMaxRows, iTickNumber, iMinRPS, iMinRows;
        public int iNumberOfPoints;
        public bool bRunCustomQuery;
        private string strConnectionString;
        public int iPollingFrequency = 10;
        RollingPointPairList objTotalRowsPairList, objRPSPairList;
        GraphPane objTotalRowsPane, objRPSPane, objAllTablesPane;
        SqlServerDB objSqlDB;
        
        private static string QUERY_FILE_PATH = "App_Data\\Query.txt";

        public frmDataMovementAnalyzer()
        {
            InitializeComponent();

            strConnectionString = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;

            iNumberOfPoints = int.Parse(ConfigurationManager.AppSettings["NumberOfPoints"]);
            iPollingFrequency = int.Parse(ConfigurationManager.AppSettings["PollingFrequency"]);

            try
            {
                bRunCustomQuery = bool.Parse(ConfigurationManager.AppSettings["RunCustomQuery"]);
            }
            catch
            {
                bRunCustomQuery = false;
            }

            objSqlDB = new SqlServerDB(strConnectionString);

            txtDBName.Text = objSqlDB.getDatabase();

            if (!File.Exists(QUERY_FILE_PATH))
            {
                File.Create(QUERY_FILE_PATH);
            }

            _clearAllStats();

            _loadQueryFile();

            _setupGraphs();            
        }

        

        private void objTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                DataTable objRowCounts;
                if (iTickNumber == 1)
                {
                    iInitialRows = objSqlDB.getTotalRowCount();

                    iPreviousRows = iInitialRows;

                    iCurrentRows = iInitialRows;
                }

                int iCurrentRowsPerSecond = 0;
                iTotalTime += iPollingFrequency;

                iPreviousRows = iCurrentRows;
                iCurrentRows = objSqlDB.getTotalRowCount();

                objRowCounts = objSqlDB.getAllRowCounts(false);
                objAllTablesPane = zgcAllTables.GraphPane;

                objAllTablesPane.YAxis.Type = AxisType.Log;

                DateTime dtNow = DateTime.Now;

                for (int i = 0; i < 5; i++)
                {
                    DataRow row = objRowCounts.Rows[i];
                    CurveItem ci = objAllTablesPane.CurveList.Find(x => x.Label.Text == row["TableName"].ToString());

                    if (ci != null)
                    {
                        ci.AddPoint((double)new XDate(dtNow), Int32.Parse(row["RowCnt"].ToString()));
                    }
                    else
                    {
                        objAllTablesPane.AddCurve(row["TableName"].ToString(), new RollingPointPairList(iNumberOfPoints), Color.Red, SymbolType.Default); ;
                        ci = objAllTablesPane.CurveList.Find(x => x.Label.Text == row["TableName"].ToString());
                        ci.AddPoint((double)new XDate(dtNow), Int32.Parse(row["RowCnt"].ToString()));
                    }
                }

                dgvTableList.DataSource = objRowCounts;


                if (bRunCustomQuery)
                {
                    dgvCustom.DataSource = _getCustomQueryResults();
                }

                objTotalRowsPairList.Add((double)new XDate(dtNow), iCurrentRows);

                lblRowCount.Text = String.Format("Current Row Count: {0}", iCurrentRows.ToString("N0"));

                iCurrentRowsPerSecond = (iCurrentRows - iPreviousRows) / iPollingFrequency;
                objRPSPairList.Add((double)new XDate(dtNow), iCurrentRowsPerSecond);

                lblRPS.Text = String.Format("Current Rows/sec: {0}", iCurrentRowsPerSecond.ToString("N0"));

                if (iCurrentRowsPerSecond > iMaxRPS)
                {
                    iMaxRPS = iCurrentRowsPerSecond;
                    lblMaxRPS.Text = String.Format("Max Rows/sec: {0}", iMaxRPS.ToString("N0"));
                }

                if (iCurrentRowsPerSecond < iMinRPS)
                {
                    iMinRPS = iCurrentRowsPerSecond;
                    lblMinRPS.Text = String.Format("Min Rows/sec: {0}", iMinRPS.ToString("N0"));
                }

                if (iCurrentRows > iMaxRows)
                {
                    iMaxRows = iCurrentRows;
                    lblMaxRowCount.Text = String.Format("Max Row Count: {0}", iMaxRows.ToString("N0"));
                }

                if (iCurrentRows < iMinRows)
                {
                    iMinRows = iCurrentRows;
                    lblMinRowCount.Text = String.Format("Min Row Count: {0}", iMinRows.ToString("N0"));
                }

                iTickNumber++;
                _updateGraphs();
            }
            catch (Exception ex)
            {
                objTimer.Stop();
                MessageBox.Show("Exception thrown: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void editConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _editConnection();
        }


        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objTimer.Stop();
            startToolStripMenuItem.Enabled = true;
            stopToolStripMenuItem.Enabled = false;
            resetToolStripMenuItem.Enabled = true;
            preferencesToolStripMenuItem.Enabled = true;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objTimer.Start();
            stopToolStripMenuItem.Enabled = true;
            startToolStripMenuItem.Enabled = false;
            resetToolStripMenuItem.Enabled = false;
            preferencesToolStripMenuItem.Enabled = false;

            DataTable dt = objSqlDB.getAllRowCounts(false);
            for (int i = 0; i < 5; i++)
            {
                DataRow row = dt.Rows[i];

                Random randomGen = new Random();
                KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                KnownColor randomColorName = names[randomGen.Next(names.Length)];
                Color randomColor = Color.FromKnownColor(randomColorName);

                objAllTablesPane.AddCurve(row["TableName"].ToString(), new RollingPointPairList(iNumberOfPoints), _randomColorForInt(i), SymbolType.Default); ;
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _clearAllStats();
        }

        public void saveConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["NumberOfPoints"].Value = iNumberOfPoints.ToString();
            config.AppSettings.Settings["PollingFrequency"].Value = iPollingFrequency.ToString();
            config.AppSettings.Settings["RunCustomQuery"].Value = bRunCustomQuery.ToString();
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");

            _clearAllStats();
            _setupGraphs();
            
        }

        private void _setupGraphs()
        {
            
            zgcTotalRows.AutoSize = true;
            zgcRPS.AutoSize = true;
            zgcAllTables.AutoSize = true;

            // pane used to draw your chart
            objTotalRowsPane = zgcTotalRows.GraphPane;
            objRPSPane = zgcRPS.GraphPane;
            objAllTablesPane = zgcAllTables.GraphPane;

            objAllTablesPane.Title.Text = "Top ~5 Tables";
            objTotalRowsPane.Title.Text = "Total Rows";
            objRPSPane.Title.Text = "Rows Per Second";

            objRPSPane.CurveList.Clear();
            objTotalRowsPane.CurveList.Clear();
            objAllTablesPane.CurveList.Clear();

            // poing pair lists
            objTotalRowsPairList = new RollingPointPairList(iNumberOfPoints);
            objRPSPairList = new RollingPointPairList(iNumberOfPoints);


            objTotalRowsPane.AddCurve("Total Rows", objTotalRowsPairList, Color.Red, SymbolType.Default);
            objRPSPane.AddCurve("Rows per Second", objRPSPairList, Color.Blue, SymbolType.Default);


            objTotalRowsPane.XAxis.Title.Text = "Time";
            objTotalRowsPane.YAxis.Title.Text = "Rows";
            objTotalRowsPane.XAxis.Type = AxisType.Date;

            objRPSPane.XAxis.Title.Text = "Time";
            objRPSPane.YAxis.Title.Text = "Rows";
            objRPSPane.XAxis.Type = AxisType.Date;

            objAllTablesPane.XAxis.Title.Text = "Time";
            objAllTablesPane.YAxis.Title.Text = "Rows";
            objAllTablesPane.XAxis.Type = AxisType.Date;
        }
        

        private void _clearAllStats()
        {

            objTimer.Interval = iPollingFrequency * 1000;

            iTickNumber = 1;

            iMaxRows = -1;
            iMaxRPS = -1;

            iMinRows = Int32.MaxValue;
            iMinRPS = Int32.MaxValue;

            iCurrentRows = 0;
            iTotalTime = 0;
            iInitialRows = 0;
            iPreviousRows = 0;

            if (objTotalRowsPairList != null && objRPSPairList != null)
            {
                objTotalRowsPairList.Clear();
                objRPSPairList.Clear();
            }

            if (objAllTablesPane != null && objAllTablesPane.CurveList != null)
            {
                objAllTablesPane.CurveList.Clear();
            }

            dgvTableList.DataSource = null;
            dgvCustom.DataSource = null;

            _updateGraphs();

            lblRowCount.Text = "Current Row Count:";
            lblRPS.Text = "Current Rows/sec:";
            lblMaxRowCount.Text = "Max Row Count:";
            lblMaxRPS.Text = "Max Rows/sec:";
            lblMinRowCount.Text = "Min Row Count:";
            lblMinRPS.Text = "Min Rows/sec:";
        }

        private void _updateGraphs()
        {

            zgcTotalRows.AxisChange();
            zgcTotalRows.Invalidate();
            zgcTotalRows.Refresh();

            zgcRPS.AxisChange();
            zgcRPS.Invalidate();
            zgcRPS.Refresh();

            zgcAllTables.AxisChange();
            zgcAllTables.Invalidate();
            zgcAllTables.Refresh();
        }


        

        private DataTable _getCustomQueryResults()
        {
            string sSQL = "";

            if (string.IsNullOrEmpty(sSQL))
            {
                throw new ApplicationException("Custom query set to run, but no custom query present. Either disable custom query in the options or enter one on the Custom Query tab.");
            }

            sSQL = txtCustomQuery.Text;

            return objSqlDB.getCustomResults(sSQL); ;
        }

        

        private void _editConnection()
        {

            if(_tryGetDataConnectionStringFromUser(out strConnectionString)){
                txtDBName.Text = new SqlConnection(strConnectionString).Database;

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings["SqlServerConnString"].ConnectionString = strConnectionString;
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("connectionStrings");
            }
        }

        private Color _randomColorForInt(int i)
        {
            switch(i)
            {
                case 0:
                    return Color.Black;
                case 1:
                    return Color.Blue;
                case 2:
                    return Color.Green;
                case 3:
                    return Color.Purple;
                case 4:
                    return Color.Orange;
                case 5:
                    return Color.Yellow;
                case 6:
                    return Color.Pink;
                case 7:
                    return Color.Maroon;
                case 8:
                    return Color.Lime;
                case 9:
                    return Color.LightSkyBlue;
            }
            return Color.White;
        }


        void _loadQueryFile()
        {
            try
            {

                txtCustomQuery.LoadFile(QUERY_FILE_PATH, RichTextBoxStreamType.RichText);
            }
            catch (ArgumentException aex)
            {
                txtCustomQuery.LoadFile(QUERY_FILE_PATH, RichTextBoxStreamType.PlainText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception thrown: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        bool _tryGetDataConnectionStringFromUser(out string outConnectionString)
        {
                using (var dialog = new DataConnectionDialog())
                {
                    // If you want the user to select from any of the available data sources, do this:
                    //DataSource.AddStandardDataSources(dialog);

                    // OR, if you want only certain data sources to be available
                    // (e.g. only SQL Server), do something like this instead: 
                    dialog.DataSources.Add(DataSource.SqlDataSource);

                    // The way how you show the dialog is somewhat unorthodox; `dialog.ShowDialog()`
                    // would throw a `NotSupportedException`. Do it this way instead:
                    DialogResult userChoice = DataConnectionDialog.Show(dialog);

                    // Return the resulting connection string if a connection was selected:
                    if (userChoice == DialogResult.OK)
                    { 
                        outConnectionString = dialog.ConnectionString;
                        return true;
                    }
                    else
                    {
                        outConnectionString = "";
                        return false;
                    }
        }
    }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPreferencescs objPrefs = new frmPreferencescs(this);

            objPrefs.ShowDialog();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAboutBox().ShowDialog();
        }

        private void btnSaveCustom_Click(object sender, EventArgs e)
        {
            txtCustomQuery.SaveFile(QUERY_FILE_PATH, RichTextBoxStreamType.RichText);

            MessageBox.Show("File Saved!");
        }

    }
}
