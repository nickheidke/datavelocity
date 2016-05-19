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
        public frmPreferencescs(frmDataMovementAnalyzer sender)
        {
            InitializeComponent();

            objDataAnalyzer = sender;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPreferencescs_Load(object sender, EventArgs e)
        {
            txtNumberOfPoints.Text = objDataAnalyzer.iNumberOfPoints.ToString();
            txtPollingFrequency.Text = objDataAnalyzer.iPollingFrequency.ToString();
            chkRunCustomQuery.Checked = objDataAnalyzer.bRunCustomQuery;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Saving preferences will remove previous data points", "Warning: Data Reset", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                objDataAnalyzer.iNumberOfPoints = int.Parse(txtNumberOfPoints.Text);
                objDataAnalyzer.iPollingFrequency = int.Parse(txtPollingFrequency.Text);
                objDataAnalyzer.bRunCustomQuery = chkRunCustomQuery.Checked;
                objDataAnalyzer.saveConfig();
                this.Close();
            }
        }
    }
}
