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
        private int _iCurrentRowCount, _iTotalTime, _iInitialRows, _iPreviousRows, _iMaxRows, _iTickNumber,  _iMinRows;
        private double _dCurrentRPS, _dMaxRPS, _dMinRPS;
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
