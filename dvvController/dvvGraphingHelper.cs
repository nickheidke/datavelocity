using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dvvModels;
using DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace dvvHelpers
{
    public class dvvGraphingHelper
    {
        #region PrivateFields
        private dvvGraphingModel _model;
        private dvvDatabase _db;
        private List<int> _RowCounts, _RowsMoved;
        private List<double> _RPSs;
        #endregion

        #region Constructors
        public dvvGraphingHelper(dvvGraphingModel model, string connectionstring){
            _model = model;
            _db = new dvvSqlServerDB(connectionstring);

            _RowCounts = new List<int>();
            _RPSs = new List<double>();
            _RowsMoved = new List<int>();
        }

        public dvvGraphingHelper(dvvGraphingModel model, string serverName, string dbName)
        {
            _model = model;
            _db = new dvvSqlServerDB("Integrated Security=SSPI;Initial Catalog=" + dbName + ";Data Source=" + serverName+";");

            _RowCounts = new List<int>();
            _RPSs = new List<double>();
            _RowsMoved = new List<int>();
        }
        #endregion

        #region Properties
        //public dvvGraphingModel Model
        //{
        //    get { return _model; }
        //    set { _model = value; }
        //}
        #endregion

        #region PublicMethods
        public string GetDatabaseName()
        {
            return _db.DbName;
        }

        public dvvGraphingModel ResetModel()
        {
            _model = new dvvGraphingModel();

            return _model;
        }

        public dvvGraphingModel Tick(dvvPrefsModel prefsModel)
        {
            if (_model.TickNumber == 1)
            {
                _model.InitialRowCount = _db.getTotalRowCount();

                _model.PreviousRowCount = _model.InitialRowCount;

                _model.CurrentRowCount = _model.InitialRowCount;

                _model.RunStart = DateTime.Now;
            }

            _model.TotalTime += prefsModel.PollingFrequency;
            _RowsMoved.Add(_model.CurrentRowCount - _model.PreviousRowCount);
            _model.PreviousRowCount = _model.CurrentRowCount;

            //Find current Row Count and store it, then calculate average
            _model.CurrentRowCount = _db.getTotalRowCount();
            _RowCounts.Add(_model.CurrentRowCount);
            _model.AverageRowCount = _RowCounts.Average();
            _model.AverageRowCountNZ = _RowCounts.Where(x => x != 0).Average();

            
            //Find current RPS and store it, then calculate average
            _model.CurrentRPS = (_model.CurrentRowCount - _model.PreviousRowCount) / (double)prefsModel.PollingFrequency;
            _RPSs.Add(_model.CurrentRPS);
            _model.AverageRPS = _RPSs.Average();
            if (_RPSs.Where(x => x != 0).ToList().Count > 0)
            {
                _model.AverageRPSNZ = _RPSs.Where(x => x != 0).Average();
            }

            var absoluteValueList = _RowsMoved.Select(x => Math.Abs(x)).ToList();
            _model.TotalRowsMoved = absoluteValueList.Sum();

            _model.TotalRowsAdded = _RowsMoved.Where(x => x > 0).Sum();
            _model.TotalRowsRemoved = Math.Abs(_RowsMoved.Where(x => x < 0).Sum());

            _model.RowCounts = _db.getAllRowCounts(false);


            //Update maximums
            if (_model.CurrentRPS > _model.MaxRPS)
            {
                _model.MaxRPS = _model.CurrentRPS;
            }

            if (_model.CurrentRPS < _model.MinRPS)
            {
                _model.MinRPS = _model.CurrentRPS;
            }

            if (_model.CurrentRowCount > _model.MaxRowCount)
            {
                _model.MaxRowCount = _model.CurrentRowCount;
            }

            if (_model.CurrentRowCount < _model.MinRowCount)
            {
                _model.MinRowCount = _model.CurrentRowCount;
            }


            //Calculate time remaining
            if (_model.TickNumber != 1)
            {
                int secondsLeft = (int)(_model.CurrentRPS != 0 ? ((_model.MaxRowCount - _model.CurrentRowCount) / _model.CurrentRPS) : 0);
                _model.TimeLeft = new TimeSpan(0, 0, secondsLeft);
                _model.EstimatedEnd = DateTime.Now + _model.TimeLeft;
            }            

            _model.TickNumber++;

            return _model;
        }

        public void Stop()
        {
            _model.RunEnd = DateTime.Now;
        }

        public DataTable getAllRowCounts(bool includeZeros)
        {
            _model.RowCounts = _db.getAllRowCounts(includeZeros);

            return _model.RowCounts;
        }

        public DataTable getCustomResults(string sQuery)
        {
            return _db.getCustomResults(sQuery);
        }

        public void resetConnection(string connectionString)
        {
            _db = new dvvSqlServerDB(connectionString);
        }

        #endregion
    }
}
