using dvvModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvvController
{
    public class dvvPrefsController
    {
        #region PrivateFields
        dvvPrefsModel _model;
        #endregion

        #region Constructors
        public dvvPrefsController(dvvPrefsModel model)
        {
            _model = model;
        }
        #endregion
    }
}
