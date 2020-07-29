using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;
using CakeShop.Models;

namespace CakeShop.ViewModels
{
    public class StatisticsViewModel : Screen
    {
        public SeriesCollection CartesianChartData { get; set; } = new SeriesCollection();
        public string[] MonthLabels { get; set; }
        private GetListObject _getList { get; } = new GetListObject();

        public StatisticsViewModel ()
        {
            

            MonthLabels = new[] { "Tháng 1", "Tháng 2", "Tháng 3" };
        }

        public void GetDataForCartesianChart()
        {
            //Order OrderInMonth = 
            //_getList.Get_MonthlyOrder();
            CartesianChartData.Add(
                new ColumnSeries
                {
                    Title = string.Empty,
                    Values = new ChartValues<int> { 10, 20, 30 },
                }
            );
        }
    }
}
