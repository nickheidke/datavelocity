using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvvModels
{
    public class dvvPrefsModel
    {
        private bool _bTotalRowsLinear;
        private bool _bTotalRowsLog;
        private bool _bRPSScaleLinear;
        private bool _bRPSScaleLog;
        private bool _bTopColumnsScaleLinear;
        private bool _bTopColumnsScaleLog;

        private int _iNumberofPoints;
        private int _iPollingFrequency;
        private bool _bCustomQuery;


        public dvvPrefsModel()
        {
            
        }

        public bool bTotalRowsLinear
        {
            get { return _bTotalRowsLinear; }
            set { _bTotalRowsLinear = value; _bTotalRowsLog = !value; }
        }

        public bool bTotalRowsLog
        {
            get { return _bTotalRowsLog; }
            set { _bTotalRowsLog = value; _bTotalRowsLinear = !value; }
        }

        public bool bRPSScaleLinear
        {
            get { return _bRPSScaleLinear; }
            set { _bRPSScaleLinear = value; _bRPSScaleLog = !value; }
        }

        public bool bRPSScaleLog
        {
            get { return _bRPSScaleLog; }
            set { _bRPSScaleLog = value; _bRPSScaleLinear = !value; }
        }

        public bool bTopColumnsScaleLinear
        {
            get { return _bTopColumnsScaleLinear; }
            set { _bTopColumnsScaleLinear = value; _bTopColumnsScaleLog = !value; }
        }

        public bool bTopColumnsScaleLog
        {
            get { return _bTopColumnsScaleLog; }
            set { _bTopColumnsScaleLog = value; _bTopColumnsScaleLinear = !value; }
        }

        [DisplayName("Number of Points")]
        public int NumberOfPoints
        {
            get { return _iNumberofPoints; }
            set { _iNumberofPoints = value; }
        }

        [DisplayName("Polling Frequency")]
        public int PollingFrequency
        {
            get { return _iPollingFrequency; }
            set { _iPollingFrequency = value; }
        }


        public bool RunCustomQuery
        {
            get { return _bCustomQuery; }
            set { _bCustomQuery = value; }
        }
    }
}
