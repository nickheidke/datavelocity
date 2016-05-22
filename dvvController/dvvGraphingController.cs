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
        #endregion

        #region Constructors
        public dvvGraphingController(dvvGraphingModel model, string connectionstring){
            _model = model;
            _db = new dvvSqlServerDB(connectionstring);
        }
        #endregion

        #region Properties
        public dvvGraphingModel Model
        {
            get { return _model; }
            set { _model = value; }
        }
        #endregion

        #region PublicMethods
        public string GetDatabaseName()
        {
            return _db.DbName;
        }

        public void Tick(dvvPrefsModel prefsModel)
        {
            if (_model.TickNumber == 1)
            {
                _model.InitialRowCount = _db.getTotalRowCount();

                _model.PreviousRowCount = _model.InitialRowCount;

                _model.CurrentRowCount = _model.InitialRowCount;
            }



            _model.TotalTime += prefsModel.PollingFrequency;

            _model.PreviousRowCount = _model.CurrentRowCount;
            _model.CurrentRowCount = _db.getTotalRowCount();

            _model.RowCounts = _db.getAllRowCounts(false);

            _model.CurrentRPS = (_model.CurrentRowCount - _model.PreviousRowCount) / (double)prefsModel.PollingFrequency;


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
