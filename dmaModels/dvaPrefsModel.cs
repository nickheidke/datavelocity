using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvaModels
{
    public class dvaPrefsModel
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


        public dvaPrefsModel()
        {
            
        }

        public bool bTotalRowsLinear
        {
            get { return _bTotalRowsLinear; }
            set { _bTotalRowsLinear = value; }
        }

        public bool bTotalRowsLog
        {
            get { return _bTotalRowsLog; }
            set { _bTotalRowsLog = value; }
        }

        public bool bRPSScaleLinear
        {
            get { return _bRPSScaleLinear; }
            set { _bRPSScaleLinear = value; }
        }

        public bool bRPSScaleLog
        {
            get { return _bRPSScaleLog; }
            set { _bRPSScaleLog = value; }
        }

        public bool bTopColumnsScaleLinear
        {
            get { return _bTopColumnsScaleLinear; }
            set { _bTopColumnsScaleLinear = value; }
        }

        public bool bTopColumnsScaleLog
        {
            get { return _bTopColumnsScaleLog; }
            set { _bTopColumnsScaleLog = value; }
        }


        public int NumberofPoints
        {
            get { return _iNumberofPoints; }
            set { _iNumberofPoints = value; }
        }


        public int PollingFrequency
        {
            get { return _iPollingFrequency; }
            set { _iPollingFrequency = value; }
        }


        public bool CustomQuery
        {
            get { return _bCustomQuery; }
            set { _bCustomQuery = value; }
        }
    }
}
