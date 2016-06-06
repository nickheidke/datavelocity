using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dvvModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dvvWeb.Models
{
    public class ConfigModel
    {
        dvvPrefsModel _preferences;
        string _servername, _dbName;


        public ConfigModel()
        {
            _preferences = new dvvPrefsModel();
        }

        
        public dvvPrefsModel Preferences
        {
            get { return _preferences; }
            set { _preferences = value; }
        }

        [Required]
        [DisplayName("Database Name")]
        public string DbName
        {
            get { return _dbName; }
            set { _dbName = value; }
        }

        [Required]
        [DisplayName("Server Name")]
        public string Servername
        {
            get { return _servername; }
            set { _servername = value; }
        }


    }
}