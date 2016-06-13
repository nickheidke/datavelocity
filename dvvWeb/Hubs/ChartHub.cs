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
        CancellationTokenSource tokenSource;
        CancellationToken ct;
        public void Start(string serverName, string dbName, string numberOfPoints, string pollingFrequency)
        {
            ConfigModel config = new ConfigModel();

            tokenSource = new CancellationTokenSource();
            ct = tokenSource.Token;

            config.Servername = HttpUtility.UrlDecode(serverName);
            config.DbName = HttpUtility.UrlDecode(dbName);
            config.Preferences.NumberOfPoints = int.Parse(numberOfPoints);
            config.Preferences.PollingFrequency = int.Parse(pollingFrequency);

            dvvGraphingModel graphingModel = new dvvGraphingModel();

            dvvGraphingHelper graphingHelper = new dvvGraphingHelper(graphingModel, config.Servername, config.DbName);

            graphingModel = graphingHelper.Tick(config.Preferences);

            var identity = WindowsIdentity.GetCurrent();

            Task.Run(() => workItemAsync(ct, graphingModel, graphingHelper, config, identity));

            /*while (true)
            {
                Clients.Caller.addPointToChart(JsonConvert.SerializeObject(graphingModel));
                System.Threading.Thread.Sleep(config.Preferences.PollingFrequency * 1000);
                graphingModel = graphingHelper.Tick(config.Preferences);
            }
             * */
        }

        public void Stop()
        {
            tokenSource.Cancel();
        }


        private async Task<CancellationToken> workItemAsync(CancellationToken ct, dvvGraphingModel graphingModel, dvvGraphingHelper graphingHelper, ConfigModel configModel, WindowsIdentity identity)
        {
            await addLogAsync(ct, graphingModel, graphingHelper, configModel, identity);
            return ct;
        }

        private async Task<CancellationToken> addLogAsync(CancellationToken ct, dvvGraphingModel graphingModel, dvvGraphingHelper graphingHelper, ConfigModel configModel, WindowsIdentity identity)
        {

            try
            {
                while(!ct.IsCancellationRequested)
                {
                    identity.Impersonate();
                    Clients.Caller.addPointToChart(JsonConvert.SerializeObject(graphingModel));
                    System.Threading.Thread.Sleep(configModel.Preferences.PollingFrequency * 1000);
                    graphingModel = graphingHelper.Tick(configModel.Preferences);

                }
            }
            catch (TaskCanceledException tce)
            {
                Trace.TraceError("Caught TaskCanceledException - signaled cancellation " + tce.Message);
            }
            return ct;
        }
    }
}