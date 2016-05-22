using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvaModels
{
    public class dvaGraphingModel
    {
        #region PrivateFields
        private int _iCurrentRowCount, _iTotalTime, _iInitialRows, _iPreviousRows, _iMaxRPS, _iMaxRows, _iTickNumber, _iMinRPS, _iMinRows, _iCurrentRPS;
        DataTable _objRowCounts;
        #endregion

        #region Properties
        public int MinRowCount
        {
            get { return _iMinRows; }
            set { _iMinRows = value; }
        }

        public int MinRPS
        {
            get { return _iMinRPS; }
            set { _iMinRPS = value; }
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

        public int MaxRPS
        {
            get { return _iMaxRPS; }
            set { _iMaxRPS = value; }
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


        public int CurrentRPS
        {
            get { return _iCurrentRPS; }
            set { _iCurrentRPS = value; }
        }
        #endregion

        #region Constructors
        public dvaGraphingModel()
        {
            _iTickNumber = 1;

            _iMaxRows = -1;
            _iMaxRPS = -1;

            _iMinRows = Int32.MaxValue;
            _iMinRPS = Int32.MaxValue;

            _iCurrentRowCount = 0;
            _iTotalTime = 0;
            _iInitialRows = 0;
            _iPreviousRows = 0;
        }
        #endregion
    }
}
