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
using dmaModels;

namespace DataMovementAnalyzer
{
    public partial class frmDataMovementAnalyzer : Form
    {
        private int _iCurrentRows, _iTotalTime, _iInitialRows, _iPreviousRows, _iMaxRPS, _iMaxRows, _iTickNumber, _iMinRPS, _iMinRows;
        public bool bRunCustomQuery;
        private string _strConnectionString;
        dmaPreferences _objPrefs;

        
        RollingPointPairList objTotalRowsPairList, objRPSPairList;
        GraphPane objTotalRowsPane, objRPSPane, objAllTablesPane;
        Database objSqlDB;
        
        private static string QUERY_FILE_PATH = "App_Data\\Query.txt";

        public frmDataMovementAnalyzer()
        {
            InitializeComponent();

            _strConnectionString = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;

            try
            {
                bRunCustomQuery = bool.Parse(ConfigurationManager.AppSettings["RunCustomQuery"]);
            }
            catch
            {
                bRunCustomQuery = false;
            }

            objSqlDB = new SqlServerDB(_strConnectionString);

            txtDBName.Text = objSqlDB.DbName;

            if (!File.Exists(QUERY_FILE_PATH))
            {
                File.Create(QUERY_FILE_PATH);
            }

            _objPrefs = new dmaPreferences();

            _loadPrefs();

            _clearAllStats();

            _loadQueryFile();

            _setupGraphs(Prefs.bTotalRowsLinear ? AxisType.Linear : AxisType.Log,
                Prefs.bRPSScaleLinear ? AxisType.Linear : AxisType.Log,
                Prefs.bTopColumnsScaleLinear ? AxisType.Linear : AxisType.Log);    
        }

        public dmaPreferences Prefs
        {
            get { return _objPrefs; }
            set { _objPrefs = value; }
        }

        private void objTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                DataTable objRowCounts;
                if (_iTickNumber == 1)
                {
                    _iInitialRows = objSqlDB.getTotalRowCount();

                    _iPreviousRows = _iInitialRows;

                    _iCurrentRows = _iInitialRows;
                }

                int iCurrentRowsPerSecond = 0;
                _iTotalTime += _objPrefs.iPollingFrequency;

                _iPreviousRows = _iCurrentRows;
                _iCurrentRows = objSqlDB.getTotalRowCount();

                objRowCounts = objSqlDB.getAllRowCounts(false);
                objAllTablesPane = zgcAllTables.GraphPane;

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
                        objAllTablesPane.AddCurve(row["TableName"].ToString(), new RollingPointPairList(_objPrefs.iNumberofPoints), Color.Red, SymbolType.Default); ;
                        ci = objAllTablesPane.CurveList.Find(x => x.Label.Text == row["TableName"].ToString());
                        ci.AddPoint((double)new XDate(dtNow), Int32.Parse(row["RowCnt"].ToString()));
                    }
                }

                dgvTableList.DataSource = objRowCounts;


                if (bRunCustomQuery)
                {
                    dgvCustom.DataSource = _getCustomQueryResults();
                }

                objTotalRowsPairList.Add((double)new XDate(dtNow), _iCurrentRows);

                lblRowCount.Text = String.Format("Current Row Count: {0}", _iCurrentRows.ToString("N0"));

                iCurrentRowsPerSecond = (_iCurrentRows - _iPreviousRows) / _objPrefs.iPollingFrequency;
                objRPSPairList.Add((double)new XDate(dtNow), iCurrentRowsPerSecond);

                lblRPS.Text = String.Format("Current Rows/sec: {0}", iCurrentRowsPerSecond.ToString("N0"));

                if (iCurrentRowsPerSecond > _iMaxRPS)
                {
                    _iMaxRPS = iCurrentRowsPerSecond;
                    lblMaxRPS.Text = String.Format("Max Rows/sec: {0}", _iMaxRPS.ToString("N0"));
                }

                if (iCurrentRowsPerSecond < _iMinRPS)
                {
                    _iMinRPS = iCurrentRowsPerSecond;
                    lblMinRPS.Text = String.Format("Min Rows/sec: {0}", _iMinRPS.ToString("N0"));
                }

                if (_iCurrentRows > _iMaxRows)
                {
                    _iMaxRows = _iCurrentRows;
                    lblMaxRowCount.Text = String.Format("Max Row Count: {0}", _iMaxRows.ToString("N0"));
                }

                if (_iCurrentRows < _iMinRows)
                {
                    _iMinRows = _iCurrentRows;
                    lblMinRowCount.Text = String.Format("Min Row Count: {0}", _iMinRows.ToString("N0"));
                }

                _iTickNumber++;
                _updateGraphs();
            }
            catch (Exception ex)
            {
                objTimer.Stop();
                displayError("Exception thrown: " + ex.Message);
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
            if (string.IsNullOrEmpty(objSqlDB.DbName))
            {
                displayError("Database connection not set.");
            }
            else
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

                    objAllTablesPane.AddCurve(row["TableName"].ToString(), new RollingPointPairList(_objPrefs.iNumberofPoints), _randomColorForInt(i), SymbolType.Default); ;
                }
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _clearAllStats();
        }

        public void saveConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["NumberOfPoints"].Value = Prefs.iNumberofPoints.ToString();
            config.AppSettings.Settings["PollingFrequency"].Value = Prefs.iPollingFrequency.ToString();
            config.AppSettings.Settings["RunCustomQuery"].Value = Prefs.bCustomQuery.ToString();

            if (Prefs.bTotalRowsLinear)
            {
                config.AppSettings.Settings["TotalRowsScale"].Value = "Linear";
            }
            else if (Prefs.bTotalRowsLog)
            {
                config.AppSettings.Settings["TotalRowsScale"].Value = "Log";
            }

            if (Prefs.bRPSScaleLinear)
            {
                config.AppSettings.Settings["RPSScale"].Value = "Linear";
            }
            else if (Prefs.bRPSScaleLog)
            {
                config.AppSettings.Settings["RPSScale"].Value = "Log";
            }

            if (Prefs.bTopColumnsScaleLinear)
            {
                config.AppSettings.Settings["TopColumnsScale"].Value = "Linear";
            }
            else if (Prefs.bTopColumnsScaleLog)
            {
                config.AppSettings.Settings["TopColumnsScale"].Value = "Log";
            }

            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");

            _clearAllStats();
            _setupGraphs(Prefs.bTotalRowsLinear ? AxisType.Linear : AxisType.Log,
                Prefs.bRPSScaleLinear ? AxisType.Linear : AxisType.Log, 
                Prefs.bTopColumnsScaleLinear ? AxisType.Linear : AxisType.Log);
            
        }

        private void _loadPrefs()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            Prefs.iNumberofPoints = int.Parse(config.AppSettings.Settings["NumberOfPoints"].Value);
            Prefs.iPollingFrequency = int.Parse(config.AppSettings.Settings["PollingFrequency"].Value);
            Prefs.bCustomQuery = bool.Parse(config.AppSettings.Settings["RunCustomQuery"].Value);

            if (config.AppSettings.Settings["TotalRowsScale"].Value == "Linear")
            {
                Prefs.bTotalRowsLinear = true;
                Prefs.bTotalRowsLog = false;
            }
            else
            {
                Prefs.bTotalRowsLinear = false;
                Prefs.bTotalRowsLog = true;
            }

            if (config.AppSettings.Settings["RPSScale"].Value == "Linear")
            {
                Prefs.bRPSScaleLinear = true;
                Prefs.bRPSScaleLog = false;
            }
            else
            {
                Prefs.bRPSScaleLinear = false;
                Prefs.bRPSScaleLog = true;
            }

            if (config.AppSettings.Settings["TopColumnsScale"].Value == "Linear")
            {
                Prefs.bTopColumnsScaleLinear = true;
                Prefs.bTopColumnsScaleLog = false;
            }
            else
            {
                Prefs.bTopColumnsScaleLinear = false;
                Prefs.bTopColumnsScaleLog = true;
            }
        }

        private void _setupGraphs(AxisType objTotalRowsY, AxisType objRPSY, AxisType objAllTablesY)
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

            //Setup Axis
            objAllTablesPane.YAxis.Type = objAllTablesY;
            objTotalRowsPane.YAxis.Type = objTotalRowsY;
            objRPSPane.YAxis.Type = objRPSY;


            objRPSPane.CurveList.Clear();
            objTotalRowsPane.CurveList.Clear();
            objAllTablesPane.CurveList.Clear();

            // poing pair lists
            objTotalRowsPairList = new RollingPointPairList(_objPrefs.iNumberofPoints);
            objRPSPairList = new RollingPointPairList(_objPrefs.iNumberofPoints);


            objTotalRowsPane.AddCurve("Total Rows", objTotalRowsPairList, Color.Red, SymbolType.Default);
            objRPSPane.AddCurve("Rows per Second", objRPSPairList, Color.Blue, SymbolType.Default);


            objTotalRowsPane.XAxis.Title.Text = "Time";
            objTotalRowsPane.YAxis.Title.Text = "Rows";
            objTotalRowsPane.XAxis.Type = AxisType.Date;

            objRPSPane.XAxis.Title.Text = "Time";
            objRPSPane.YAxis.Title.Text = "RPS";
            objRPSPane.XAxis.Type = AxisType.Date;

            objAllTablesPane.XAxis.Title.Text = "Time";
            objAllTablesPane.YAxis.Title.Text = "Rows";
            objAllTablesPane.XAxis.Type = AxisType.Date;

            _updateGraphs();
        }
        

        private void _clearAllStats()
        {

            objTimer.Interval = _objPrefs.iPollingFrequency * 1000;

            _iTickNumber = 1;

            _iMaxRows = -1;
            _iMaxRPS = -1;

            _iMinRows = Int32.MaxValue;
            _iMinRPS = Int32.MaxValue;

            _iCurrentRows = 0;
            _iTotalTime = 0;
            _iInitialRows = 0;
            _iPreviousRows = 0;

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

            if(_tryGetDataConnectionStringFromUser(out _strConnectionString)){
                txtDBName.Text = new SqlConnection(_strConnectionString).Database;

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings["SqlServerConnString"].ConnectionString = _strConnectionString;
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("connectionStrings");
            }

            objSqlDB = new SqlServerDB(_strConnectionString);
        }

        private static Color _randomColorForInt(int i)
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
                displayError(ex.Message);
            }
        }


        static bool _tryGetDataConnectionStringFromUser(out string outConnectionString)
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
            frmPreferencescs objPrefs = new frmPreferencescs(this, _objPrefs);

            objPrefs.ShowDialog();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAboutBox().ShowDialog();
        }

        private void btnSaveCustom_Click(object sender, EventArgs e)
        {
            txtCustomQuery.SaveFile(QUERY_FILE_PATH, RichTextBoxStreamType.RichText);

            MessageBox.Show("File Saved", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }

        private void displayError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }

    }
}
