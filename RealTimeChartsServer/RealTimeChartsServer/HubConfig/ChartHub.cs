using Microsoft.AspNetCore.SignalR;
using RealTimeChartsServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealTimeChartsServer.HubConfig
{
    public class ChartHub : Hub
    {
        public async Task BroadCastChartData(List<ChartModel> data) => await Clients.All.SendAsync("broadcastchartdata", data);
    }
}
