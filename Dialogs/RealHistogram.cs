using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SWD.Dialogs
{
    public partial class RealHistogram : Form
    {
        public RealHistogram()
        {
            InitializeComponent();
            comboBox1.DataSource = Operator.GetRealColumns();
        }


        void AddData()
        {

            chart1.Series.Clear();
            int sections = (int)numericUpDown1.Value;
            string columnName = (string)comboBox1.SelectedItem;

            double min = Operator.GetMinValueFormColumn(columnName);
            double max = Operator.GetMaxValueFormColumn(columnName);
            double diff = (max - min) / sections;
            double pom = min;
            Series s = chart1.Series.Add(columnName);
            s.ChartType = SeriesChartType.Column;
            
            for (int counter = 1; pom < max; counter++)
            {
                int sum = 0;
                foreach (DataRow row in Operator.Dt.Rows)
                {
                    double val = Convert.ToDouble(row[columnName]);
                    if (((val >= pom && val < pom + diff)) || ((pom + diff * 2) > max && val == max))
                    {
                        sum++;

                    }


                }
                s.Points.AddXY($"({Math.Round(pom,2)}-{Math.Round(pom + diff,2)})", sum);
                pom = pom + diff;
            }

        }

  

        private void button1_Click(object sender, EventArgs e)
        {
            AddData();
        }
    }
}
