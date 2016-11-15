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
using dvvModels;
using dvvHelpers;

namespace DataMovementAnalyzer
{
    public partial class DataVelocityVisualizer : Form
    {
        //private int _iCurrentRows, _iTotalTime, _iInitialRows, _iPreviousRows, _iMaxRPS, _iMaxRows, _iTickNumber, _iMinRPS, _iMinRows;
        public bool bRunCustomQuery;
        private string _sConnectionString;
        dvvPrefsModel _objPrefsModel;
        dvvGraphingModel _objGraphingModel;

        dvvGraphingHelper _objGraphingController;
        dvvPrefsHelper _objPrefsController;

        
        RollingPointPairList objTotalRowsPairList, objRPSPairList;
        GraphPane objTotalRowsPane, objRPSPane, objAllTablesPane;
        //dvvDatabase objSqlDB;
        
        private static string QUERY_FILE_PATH = "App_Data\\Query.txt";

        public DataVelocityVisualizer()
        {
            InitializeComponent();

            

            _sConnectionString = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;

            try
            {
                bRunCustomQuery = bool.Parse(ConfigurationManager.AppSettings["RunCustomQuery"]);
            }
            catch
            {
                bRunCustomQuery = false;
            }

            _objGraphingModel = new dvvGraphingModel();
            _objPrefsModel = new dvvPrefsModel();


            _setupBindings();

            _objGraphingController = new dvvGraphingHelper(_objGraphingModel, _sConnectionString);

            txtDBName.Text = _objGraphingController.GetDatabaseName();

            if (!File.Exists(QUERY_FILE_PATH))
            {
                File.Create(QUERY_FILE_PATH);
            }

            _loadPrefs();

            _clearAllStats();

            _loadQueryFile();

            _setupGraphs(Prefs.bTotalRowsLinear ? AxisType.Linear : AxisType.Log,
                Prefs.bRPSScaleLinear ? AxisType.Linear : AxisType.Log,
                Prefs.bTopColumnsScaleLinear ? AxisType.Linear : AxisType.Log);    
        }

        public dvvPrefsModel Prefs
        {
            get { return _objPrefsModel; }
            set { _objPrefsModel = value; }
        }

        private void objTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                _objGraphingModel = _objGraphingController.Tick(_objPrefsModel);

                objAllTablesPane = zgcAllTables.GraphPane;

                DateTime dtNow = DateTime.Now;

                for (int i = 0; i < 5; i++)
                {
                    DataRow row = _objGraphingModel.RowCounts.Rows[i];
                    CurveItem ci = objAllTablesPane.CurveList.Find(x => x.Label.Text == row["TableName"].ToString());

                    if (ci != null)
                    {
                        ci.AddPoint((double) new XDate(dtNow), Int32.Parse(row["RowCnt"].ToString()));
                    }
                    else
                    {
                        objAllTablesPane.AddCurve(row["TableName"].ToString(),
                            new RollingPointPairList(_objPrefsModel.NumberOfPoints), Color.Red, SymbolType.Default);
                        ;
                        ci = objAllTablesPane.CurveList.Find(x => x.Label.Text == row["TableName"].ToString());
                        ci.AddPoint((double) new XDate(dtNow), Int32.Parse(row["RowCnt"].ToString()));
                    }
                }

                dgvTableList.DataSource = _objGraphingModel.RowCounts;


                if (Prefs.RunCustomQuery)
                {
                    dgvCustom.DataSource = _getCustomQueryResults(txtCustomQuery.Text);
                }

                objTotalRowsPairList.Add((double) new XDate(dtNow), _objGraphingModel.CurrentRowCount);

                lblRowCount.Text = String.Format("Current Row Count: {0}",
                    _objGraphingModel.CurrentRowCount.ToString("N0"));


                objRPSPairList.Add((double) new XDate(dtNow), _objGraphingModel.CurrentRPS);

                lblRPS.Text = String.Format("Current Rows/sec: {0}", _objGraphingModel.CurrentRPS.ToString("N1"));

                if (_objGraphingModel.CurrentRPS >= _objGraphingModel.MaxRPS)
                {
                    lblMaxRPS.Text = String.Format("Max Rows/sec: {0}", _objGraphingModel.MaxRPS.ToString("N1"));
                }

                if (_objGraphingModel.CurrentRPS <= _objGraphingModel.MinRPS)
                {
                    lblMinRPS.Text = String.Format("Min Rows/sec: {0}", _objGraphingModel.MinRPS.ToString("N1"));
                }

                if (_objGraphingModel.CurrentRowCount >= _objGraphingModel.MaxRowCount)
                {
                    lblMaxRowCount.Text = String.Format("Max Row Count: {0}",
                        _objGraphingModel.MaxRowCount.ToString("N0"));
                }

                if (_objGraphingModel.CurrentRowCount <= _objGraphingModel.MinRowCount)
                {
                    lblMinRowCount.Text = String.Format("Min Row Count: {0}",
                        _objGraphingModel.MinRowCount.ToString("N0"));
                }

                _updateGraphs();
                _refreshBindings();
            }
            catch (Exception ex)
            {
                Stop();
                displayError("Exception thrown: " + ex.Message);
                throw ex;
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
            Stop();
        }

        private void Stop()
        {
            _objGraphingController.Stop();
            objTimer.Stop();
            startToolStripMenuItem.Enabled = true;
            stopToolStripMenuItem.Enabled = false;
            resetToolStripMenuItem.Enabled = true;
            preferencesToolStripMenuItem.Enabled = true;
            editConnectionToolStripMenuItem.Enabled = true;

            this.Refresh();
            _refreshBindings();

            Application.DoEvents();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_objGraphingController.GetDatabaseName()))
            {
                displayError("Database connection not set.");
            }
            else
            {
                try
                {
                    this.objTimer_Tick(null, null);


                    objTimer.Start();
                    stopToolStripMenuItem.Enabled = true;
                    startToolStripMenuItem.Enabled = false;
                    resetToolStripMenuItem.Enabled = false;
                    preferencesToolStripMenuItem.Enabled = false;
                    editConnectionToolStripMenuItem.Enabled = false;

                    DataTable dt = _objGraphingController.getAllRowCounts(false);
                    for (int i = 0; i < 5; i++)
                    {
                        DataRow row = dt.Rows[i];

                        objAllTablesPane.AddCurve(row["TableName"].ToString(),
                            new RollingPointPairList(_objPrefsModel.NumberOfPoints), _randomColorForInt(i),
                            SymbolType.Default);
                        ;
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _clearAllStats();

            _objGraphingModel = _objGraphingController.ResetModel();
            _setupBindings();
            _refreshBindings();
        }

        public void saveConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["NumberOfPoints"].Value = Prefs.NumberOfPoints.ToString();
            config.AppSettings.Settings["PollingFrequency"].Value = Prefs.PollingFrequency.ToString();
            config.AppSettings.Settings["RunCustomQuery"].Value = Prefs.RunCustomQuery.ToString();

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

            Prefs.NumberOfPoints = int.Parse(config.AppSettings.Settings["NumberOfPoints"].Value);
            Prefs.PollingFrequency = int.Parse(config.AppSettings.Settings["PollingFrequency"].Value);
            Prefs.RunCustomQuery = bool.Parse(config.AppSettings.Settings["RunCustomQuery"].Value);

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
            objTotalRowsPairList = new RollingPointPairList(_objPrefsModel.NumberOfPoints);
            objRPSPairList = new RollingPointPairList(_objPrefsModel.NumberOfPoints);


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

            objTimer.Interval = _objPrefsModel.PollingFrequency * 1000;

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


        

        private DataTable _getCustomQueryResults(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ApplicationException("Custom query set to run, but no custom query present. Either disable custom query in the options or enter one on the Custom Query tab.");
            }

            return _objGraphingController.getCustomResults(query); ;
        }

        

        private void _editConnection()
        {

            if(_tryGetDataConnectionStringFromUser(out _sConnectionString)){
                txtDBName.Text = new SqlConnection(_sConnectionString).Database;

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings["SqlServerConnString"].ConnectionString = _sConnectionString;
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("connectionStrings");
            }

            _objGraphingController.resetConnection(_sConnectionString);
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
                try
                {
                    txtCustomQuery.LoadFile(QUERY_FILE_PATH, RichTextBoxStreamType.PlainText);
                }
                catch (Exception ex)
                {
                    Stop();
                    displayError(ex.Message);
                }
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
            Preferencescs objPrefs = new Preferencescs(this, _objPrefsModel);

            objPrefs.ShowDialog();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
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

        private void _setupBindings()
        {
            txtRunStartTime.DataBindings.Clear();
            txtRunStartTime.DataBindings.Add("Text",
                                _objGraphingModel,
                                "RunStart",
                                true,
                                DataSourceUpdateMode.OnPropertyChanged,
                                string.Empty,
                                "");

            txtAverageRowCount.DataBindings.Clear();
            txtAverageRowCount.DataBindings.Add("Text",
                                _objGraphingModel,
                                "AverageRowCount",
                                true,
                                DataSourceUpdateMode.OnPropertyChanged,
                                string.Empty,
                                "N0");

            txtAverageRowCountNZ.DataBindings.Clear();
            txtAverageRowCountNZ.DataBindings.Add("Text",
                                _objGraphingModel,
                                "AverageRowCountNZ",
                                true,
                                DataSourceUpdateMode.OnPropertyChanged,
                                string.Empty,
                                "N0");

            txtAverageRPS.DataBindings.Clear();
            txtAverageRPS.DataBindings.Add("Text",
                                _objGraphingModel,
                                "AverageRPS",
                                true,
                                DataSourceUpdateMode.OnPropertyChanged,
                                string.Empty,
                                "N1");

            txtAverageRPSNZ.DataBindings.Clear();
            txtAverageRPSNZ.DataBindings.Add("Text",
                                _objGraphingModel,
                                "AverageRPSNZ",
                                true,
                                DataSourceUpdateMode.OnPropertyChanged,
                                string.Empty,
                                "N1");

            txtTotalRowsMoved.DataBindings.Clear();
            txtTotalRowsMoved.DataBindings.Add("Text",
                                _objGraphingModel,
                                "TotalRowsMoved",
                                true,
                                DataSourceUpdateMode.OnPropertyChanged,
                                string.Empty,
                                "N0");

            txtRunEndTime.DataBindings.Clear();
            txtRunEndTime.DataBindings.Add("Text",
                                _objGraphingModel,
                                "RunEnd",
                                true,
                                DataSourceUpdateMode.OnPropertyChanged,
                                string.Empty,
                                "");

            txtEstimatedRunTimeLeft.DataBindings.Clear();
            txtEstimatedRunTimeLeft.DataBindings.Add("Text",
                                _objGraphingModel,
                                "TimeLeft",
                                true,
                                DataSourceUpdateMode.OnPropertyChanged,
                                string.Empty,
                                "");

            txtEstimatedCompletionTime.DataBindings.Clear();
            txtEstimatedCompletionTime.DataBindings.Add("Text",
                                _objGraphingModel,
                                "EstimatedEnd",
                                true,
                                DataSourceUpdateMode.OnPropertyChanged,
                                string.Empty,
                                "");

            txtTotalRowsAdded.DataBindings.Clear();
            txtTotalRowsAdded.DataBindings.Add("Text",
                                _objGraphingModel,
                                "TotalRowsAdded",
                                true,
                                DataSourceUpdateMode.OnPropertyChanged,
                                string.Empty,
                                "N0");

            txtTotalRowsRemoved.DataBindings.Clear();
            txtTotalRowsRemoved.DataBindings.Add("Text",
                                _objGraphingModel,
                                "TotalRowsRemoved",
                                true,
                                DataSourceUpdateMode.OnPropertyChanged,
                                string.Empty,
                                "N0");
        }

        private void _refreshBindings()
        {
            txtRunStartTime.DataBindings[0].ReadValue();
            txtAverageRowCount.DataBindings[0].ReadValue();
            txtAverageRowCountNZ.DataBindings[0].ReadValue();
            txtAverageRPS.DataBindings[0].ReadValue();
            txtAverageRPSNZ.DataBindings[0].ReadValue();
            txtTotalRowsMoved.DataBindings[0].ReadValue();
            txtRunEndTime.DataBindings[0].ReadValue();
            txtEstimatedRunTimeLeft.DataBindings[0].ReadValue();
            txtEstimatedCompletionTime.DataBindings[0].ReadValue();
            txtTotalRowsAdded.DataBindings[0].ReadValue();
            txtTotalRowsRemoved.DataBindings[0].ReadValue();
        }

    }
}
