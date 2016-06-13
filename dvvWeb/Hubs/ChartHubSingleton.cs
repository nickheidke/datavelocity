using dvvHelpers;
using dvvModels;
using dvvWeb.Hubs;
using dvvWeb.Models;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

public sealed class ChartHubSingleton
{
    private static volatile ChartHubSingleton instance;
    private static object syncRoot = new Object();
    ConcurrentDictionary<string, CancellationTokenSource> cancelsDictionary;

    private ChartHubSingleton() {
        cancelsDictionary = new ConcurrentDictionary<string, CancellationTokenSource>();
    }

    public static ChartHubSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new ChartHubSingleton();
                }
            }

            return instance;
        }
    }

    public void Start(string serverName, string dbName, string numberOfPoints, string pollingFrequency, ChartHub hub)
    {
        ConfigModel config = new ConfigModel();
        CancellationTokenSource tokenSource;
        CancellationToken ct;

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

        cancelsDictionary.TryAdd(identity.User.Value, tokenSource);

        Task.Run(() => workItemAsync(ct, graphingModel, graphingHelper, config, identity, hub));

    }

    private async Task<CancellationToken> workItemAsync(CancellationToken ct, dvvGraphingModel graphingModel, dvvGraphingHelper graphingHelper, ConfigModel configModel, WindowsIdentity identity, ChartHub hub)
    {
        await addDataAsync(ct, graphingModel, graphingHelper, configModel, identity, hub);
        return ct;
    }

    private async Task<CancellationToken> addDataAsync(CancellationToken ct, dvvGraphingModel graphingModel, dvvGraphingHelper graphingHelper, ConfigModel configModel, WindowsIdentity identity, ChartHub hub)
    {

        try
        {
            while (!ct.IsCancellationRequested)
            {
                identity.Impersonate();
                hub.AddPoint(graphingModel);
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

    public void Stop(string userId)
    {
        CancellationTokenSource tokenSource;
        if(cancelsDictionary.TryGetValue(userId, out tokenSource))
        {
            tokenSource.Cancel();
            cancelsDictionary.TryRemove(userId,  out tokenSource);
        }
    }
}