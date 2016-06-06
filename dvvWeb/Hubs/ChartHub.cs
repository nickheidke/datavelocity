using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace dvvWeb.Hubs
{
    public class ChartHub : Hub
    {
        public void Start()
        {
            while (true)
            {
                Clients.Caller.addPointToChart();
                System.Threading.Thread.Sleep(10000);
            }
        }
    }
}