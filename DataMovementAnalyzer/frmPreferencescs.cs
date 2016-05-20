using dmaModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMovementAnalyzer
{
    public partial class frmPreferencescs : Form
    {
        frmDataMovementAnalyzer objDataAnalyzer;
        dmaPreferences objModel;
        public frmPreferencescs(frmDataMovementAnalyzer sender, dmaPreferences objPrefsModel)
        {
            InitializeComponent();

            objDataAnalyzer = sender;

            objModel = objPrefsModel;

            setupBindings();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPreferencescs_Load(object sender, EventArgs e)
        {
            //txtNumberOfPoints.Text = objDataAnalyzer.iNumberOfPoints.ToString();
            //txtPollingFrequency.Text = objDataAnalyzer.iPollingFrequency.ToString();
            //chkRunCustomQuery.Checked = objDataAnalyzer.bRunCustomQuery;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Saving preferences will remove previous data points", "Warning: Data Reset", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                objDataAnalyzer.Prefs = objModel;
                objDataAnalyzer.saveConfig();
                this.Close();
            }
        }

        private void setupBindings()
        {
            txtNumberOfPoints.DataBindings.Add("Text",
                                objModel,
                                "iNumberOfPoints",
                                false,
                                DataSourceUpdateMode.OnPropertyChanged);

            txtPollingFrequency.DataBindings.Add("Text",
                                objModel,
                                "iPollingFrequency",
                                false,
                                DataSourceUpdateMode.OnPropertyChanged);

            chkRunCustomQuery.DataBindings.Add("Checked",
                                objModel,
                                "bCustomQuery",
                                false,
                                DataSourceUpdateMode.OnPropertyChanged);

            rdbTotalRowsLinear.DataBindings.Add("Checked",
                                objModel,
                                "bTotalRowsLinear",
                                false,
                                DataSourceUpdateMode.OnPropertyChanged);

            rdbTotalRowsLog.DataBindings.Add("Checked",
                                objModel,
                                "bTotalRowsLog",
                                false,
                                DataSourceUpdateMode.OnPropertyChanged);

            rdbRPSLinear.DataBindings.Add("Checked",
                                objModel,
                                "bRPSScaleLinear",
                                false,
                                DataSourceUpdateMode.OnPropertyChanged);

            rdbRPSLog.DataBindings.Add("Checked",
                                objModel,
                                "bRPSScaleLog",
                                false,
                                DataSourceUpdateMode.OnPropertyChanged);

            rdbTopColumnsLinear.DataBindings.Add("Checked",
                                objModel,
                                "bTopColumnsScaleLinear",
                                false,
                                DataSourceUpdateMode.OnPropertyChanged);

            rdbTopColumnsLog.DataBindings.Add("Checked",
                                objModel,
                                "bTopColumnsScaleLog",
                                false,
                                DataSourceUpdateMode.OnPropertyChanged);

        }

        private void rdbTotalRowsLinear_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if (!((RadioButton)sender).Checked)
            {
                rdbTotalRowsLog.Checked = true;
            }
             */
        }

    }
}
