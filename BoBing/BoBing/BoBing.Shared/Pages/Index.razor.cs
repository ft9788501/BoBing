using BootstrapBlazor.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoBing.Shared.Pages
{
    public partial class Index
    {
        private Random Randomer { get; } = new Random();
        private int DoughnutDatasetCount = 1;
        private int DoughnutDataCount = 5;

        [NotNull]
        private Chart DoughnutChart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstRender"></param>
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender)
            {
            }
        }

        private Task OnAfterInit()
        {
            return Task.CompletedTask;
        }

        private Task OnAfterUpdate(ChartAction action)
        {
            return Task.CompletedTask;
        }
        public static IEnumerable<string> Colors { get; } = new List<string>() { "Red", "Blue", "Green", "Orange", "Yellow", "Tomato", "Pink", "Violet" };

        private Task<ChartDataSource> OnInit()
        {
            var ds = new ChartDataSource();
            ds.Options.Title = "Doughnut 折线图";
            ds.Labels = Colors.Take(DoughnutDataCount);
            for (var index = 0; index < DoughnutDatasetCount; index++)
            {
                ds.Data.Add(new ChartDataset()
                {
                    Label = $"数据集 {index}",
                    Data = Enumerable.Range(1, DoughnutDataCount).Select(i => Randomer.Next(20, 37)).Cast<object>()
                });
            }
            return Task.FromResult(ds);
        }

        private bool IsCircle { get; set; }
    }
}
