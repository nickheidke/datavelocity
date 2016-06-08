/*global my */

my.Views.Graphing = (function ($) {
    "use strict";

    var init = function init(_serverName, _dbName, _numberOfPoints, _pollingFrequency) {

        var totalsContainer = document.getElementById('totalRowsGraph');
        var totalsDataset = new vis.DataSet();

        var rpsContainer = document.getElementById('rpsGraph');
        var rpsDataset = new vis.DataSet();

        var options = {
            start: moment(),
            end: moment() + 360000
        };
        var totalsGraph2D = new vis.Graph2d(totalsContainer, totalsDataset, options);
        var rpsGraph2D = new vis.Graph2d(rpsContainer, rpsDataset, options);

        // Reference the auto-generated proxy for the hub.  
        var chart = $.connection.chartHub;

        // Create a function that the hub can call back to display messages.
        chart.client.addPointToChart = function (totalsPoint, rpsPoint) {
            var now = moment();
            var newData = [];
            newData.push({ x: now, y: totalsPoint });
            totalsGraph2D.itemsData.add(newData);

            newData = [];
            newData.push({ x: now, y: rpsPoint });
            rpsGraph2D.itemsData.add(newData);
        };

        $.connection.hub.start().done(function () {
            //alert('initializing server');
            chart.server.start(_serverName, _dbName, _numberOfPoints, _pollingFrequency);
        });
    }


     return {
init: init
};

})(this.jQuery);