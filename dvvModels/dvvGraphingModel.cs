using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvvModels
{
    public class dvvGraphingModel
    {
        #region PrivateFields
        private int _iCurrentRowCount, _iTotalTime, _iInitialRows, _iPreviousRows, _iMaxRows, _iTickNumber, _iMinRows, _iStartingRowCount, _iTotalRowsMoved;
        private DateTime _dRunStart, _dRunEnd, _dEstimatedEnd;
        private TimeSpan _tsTimeLeft;
        private double _dCurrentRPS, _dMaxRPS, _dMinRPS, _dAverageRowCount, _dAverageRowCountNZ, _dAverageRPS, _dAverageRPSNZ;
        DataTable _objRowCounts;
        #endregion

        #region Properties
        public int MinRowCount
        {
            get { return _iMinRows; }
            set { _iMinRows = value; }
        }

        public double MinRPS
        {
            get { return _dMinRPS; }
            set { _dMinRPS = value; }
        }

        public int TickNumber
        {
            get { return _iTickNumber; }
            set { _iTickNumber = value; }
        }

        public int MaxRowCount
        {
            get { return _iMaxRows; }
            set { _iMaxRows = value; }
        }

        public double MaxRPS
        {
            get { return _dMaxRPS; }
            set { _dMaxRPS = value; }
        }

        public int PreviousRowCount
        {
            get { return _iPreviousRows; }
            set { _iPreviousRows = value; }
        }

        public int InitialRowCount
        {
            get { return _iInitialRows; }
            set { _iInitialRows = value; }
        }

        public int TotalTime
        {
            get { return _iTotalTime; }
            set { _iTotalTime = value; }
        }

        public int CurrentRowCount
        {
            get { return _iCurrentRowCount; }
            set { _iCurrentRowCount = value; }
        }


        public DataTable RowCounts
        {
            get { return _objRowCounts; }
            set { _objRowCounts = value; }
        }


        public double CurrentRPS
        {
            get { return _dCurrentRPS; }
            set { _dCurrentRPS = value; }
        }

        public int TotalRowsMoved
        {
            get { return _iTotalRowsMoved; }
            set { _iTotalRowsMoved = value; }
        }

        public int StartingRowCount
        {
            get { return _iStartingRowCount; }
            set { _iStartingRowCount = value; }
        }

        public DateTime EstimatedEnd
        {
            get { return _dEstimatedEnd; }
            set { _dEstimatedEnd = value; }
        }

        public DateTime RunEnd
        {
            get { return _dRunEnd; }
            set { _dRunEnd = value; }
        }

        public DateTime RunStart
        {
            get { return _dRunStart; }
            set { _dRunStart = value; }
        }

        public TimeSpan TimeLeft
        {
            get { return _tsTimeLeft; }
            set { _tsTimeLeft = value; }
        }

        public double AverageRowCount
        {
            get { return _dAverageRowCount; }
            set { _dAverageRowCount = value; }
        }

        public double AverageRowCountNZ
        {
            get { return _dAverageRowCountNZ; }
            set { _dAverageRowCountNZ = value; }
        }

        public double AverageRPS
        {
            get { return _dAverageRPS; }
            set { _dAverageRPS = value; }
        }

        public double AverageRPSNZ
        {
            get { return _dAverageRPSNZ; }
            set { _dAverageRPSNZ = value; }
        }
        #endregion

        #region Constructors
        public dvvGraphingModel()
        {
            _iTickNumber = 1;

            _iMaxRows = -1;
            _dMaxRPS = -1;

            _iMinRows = Int32.MaxValue;
            _dMinRPS = Int32.MaxValue;

            _iCurrentRowCount = 0;
            _iTotalTime = 0;
            _iInitialRows = 0;
            _iPreviousRows = 0;
        }
        #endregion
    }
}
