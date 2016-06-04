using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dvvModels;

namespace dvvWeb.Models
{
    public class ConfigModel
    {
        dvvPrefsModel _preferences;

        public dvvPrefsModel Preferences
        {
            get { return _preferences; }
            set { _preferences = value; }
        }
        string _servername, _dbName;

        public string DbName
        {
            get { return _dbName; }
            set { _dbName = value; }
        }

        public string Servername
        {
            get { return _servername; }
            set { _servername = value; }
        }


    }
}