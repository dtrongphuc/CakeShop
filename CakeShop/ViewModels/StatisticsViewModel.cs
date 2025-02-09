﻿using Caliburn.Micro;
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
        public SeriesCollection PieChart { get; set; } = new SeriesCollection();

        public string[] MonthLabels { get; set; }
        private GetListObject _getList { get; } = new GetListObject();

        public StatisticsViewModel()
        {
            GetDataForPieChart();
            GetDataForCartesianChart();

            MonthLabels = new[] {
                "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6",
                "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"
            };
        }

        public void GetDataForPieChart()
        {
            BindableCollection<dynamic> RevenueByCategory = _getList.Turnover();
            foreach(var item in RevenueByCategory)
            {
                ChartValues<double> Revenue = new ChartValues<double>();
                double TotalRevenue = Double.Parse(item.sales);
                Revenue.Add(TotalRevenue);

                PieSeries series = new PieSeries
                {
                    Values = Revenue,
                    Title = item.CategoryName
                };

                PieChart.Add(series);
            }
        }

        public void GetDataForCartesianChart()
        {
            BindableCollection<Order> OrdersInMonth = _getList.Get_MonthlyOrder();
            ChartValues<double> MonthChartValues = new ChartValues<double>();
            for( int month = 1; month <= 12; ++month)
            {
                var CurrentMonth = OrdersInMonth.Where(item => int.Parse(item.Date) == month).ToList();
                bool IsExist = CurrentMonth.Count > 0;
                if(IsExist)
                {
                    double total = 0;
                    CurrentMonth.ForEach(order => { 
                        total += Double.Parse(order.Total); 
                    });
                    MonthChartValues.Add(total);
                    continue;
                }
                MonthChartValues.Add(0);
            }

            CartesianChartData.Add(
                new ColumnSeries
                {
                    Title = string.Empty,
                    Values = MonthChartValues
                }
            );
        }
    }
}
