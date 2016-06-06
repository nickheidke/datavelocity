using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using dvvWeb.Models;
using dvvModels;
using dvvHelpers;
using System.Web.Mvc;

namespace dvvWeb.Hubs
{
    public class ChartHub : Hub
    {
        public void Start(string serverName, string dbName, string numberOfPoints, string pollingFrequency)
        {
            ConfigModel config = new ConfigModel();

            config.Servername = HttpUtility.UrlDecode(serverName);
            config.DbName = HttpUtility.UrlDecode(dbName);
            config.Preferences.NumberOfPoints = int.Parse(numberOfPoints);
            config.Preferences.PollingFrequency = int.Parse(pollingFrequency);

            dvvGraphingModel graphingModel = new dvvGraphingModel();

            dvvGraphingHelper graphingHelper = new dvvGraphingHelper(graphingModel, config.Servername, config.DbName);

            graphingModel = graphingHelper.Tick(config.Preferences);


            while (true)
            {
                Clients.Caller.addPointToChart(graphingModel.CurrentRowCount);
                System.Threading.Thread.Sleep(config.Preferences.PollingFrequency * 10000);
                graphingModel = graphingHelper.Tick(config.Preferences);
            }
        }
    }
}