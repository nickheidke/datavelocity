using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dvvModels;
using System.ComponentModel;

namespace dvvWeb.Models
{
    public class ConfigModel
    {
        dvvPrefsModel _preferences;
        string _servername, _dbName;


        public void CongfigModel()
        {
            _preferences = new dvvPrefsModel();
        }

        public dvvPrefsModel Preferences
        {
            get { return _preferences; }
            set { _preferences = value; }
        }
        
        [DisplayName("Database Name")]
        public string DbName
        {
            get { return _dbName; }
            set { _dbName = value; }
        }

        [DisplayName("Server Name")]
        public string Servername
        {
            get { return _servername; }
            set { _servername = value; }
        }


    }
}