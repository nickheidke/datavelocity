using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace dvvWeb.Hubs
{
    public class ChartHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }

        public void Start()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(10000);
                Clients.All.addPointToChart();
            }
        }
    }
}