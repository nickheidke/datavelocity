using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using dvvWeb.Models;
using dvvModels;
using dvvHelpers;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Web.Hosting;
using System.Security.Principal;

namespace dvvWeb.Hubs
{
    public class ChartHub : Hub
    {
        
        public void Start(string serverName, string dbName, string numberOfPoints, string pollingFrequency)
        {
            var singleton = ChartHubSingleton.Instance;

            singleton.Start(serverName, dbName, numberOfPoints, pollingFrequency, this);
        }

        public void Stop()
        {
            var singleton = ChartHubSingleton.Instance;

            singleton.Stop(WindowsIdentity.GetCurrent().User.Value);
        }

        public void AddPoint(dvvGraphingModel model)
        {
            Clients.Caller.addPointToChart(JsonConvert.SerializeObject(model));

        }


        
    }
}