using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dvvModels;
using DataAccess;
using System.Data;

namespace dvvController
{
    public class dvvGraphingController
    {
        #region PrivateFields
        private dvvGraphingModel _model;
        private dvvDatabase _db;
        private List<int> _RowCounts, _RowsMoved;
        private List<double> _RPSs;
        #endregion

        #region Constructors
        public dvvGraphingController(dvvGraphingModel model, string connectionstring){
            _model = model;
            _db = new dvvSqlServerDB(connectionstring);

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
            _RowsMoved.Add(_model.PreviousRowCount - _model.CurrentRowCount);
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

            _model.TotalRowsMoved = _RowsMoved.Sum();

            _model.RowCounts = _db.getAllRowCounts(false);


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

            _model.TickNumber++;

            return _model;
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
