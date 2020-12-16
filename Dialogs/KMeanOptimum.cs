using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Math;
using Accord.Math.Distances;
using Accord.Statistics;

namespace SWD.Dialogs
{
    public partial class KMeanOptimum : Form
    {
        public MetricsEnum Metric
        {
            get
            {
                return (MetricsEnum)(comboBox1.SelectedIndex + 1);
            }
        }
        public KMeanOptimum()
        {
            InitializeComponent();
            chart1.Series.FirstOrDefault().ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int k = 1; k <= 10; k++)
            {
                var distances = Operator.KMeanGroup(Metric, k);
                double sum = 0;
                foreach(var cl in distances.Select(i=>i.Value).Distinct())
                {
                    double []values = distances.Where(i => i.Value == cl).Select(i => i.Weight).ToArray();
                    sum += Measures.Variance(values);
                }
                chart1.Series.FirstOrDefault().Points.AddXY(k, sum);
            }

            

        }
    }
}
