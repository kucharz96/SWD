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
    public partial class DiscretizeHistogram : Form
    {
        public DiscretizeHistogram()
        {
            InitializeComponent();
            comboBox1.DataSource = Operator.GetStringColumns();
        }


        void AddData()
        {
            chart1.Series.Clear();
            string columnName = (string)comboBox1.SelectedItem;

            Series s = chart1.Series.Add(columnName);
            s.ChartType = SeriesChartType.Column;
            Dictionary<string, int> discValue = new Dictionary<string, int>();

            foreach (DataRow row in Operator.Dt.Rows)
            {
                if(discValue.TryGetValue((string)row[columnName], out int sum))
                {
                    discValue[(string)row[columnName]]++;

                }
                else
                {
                    discValue.Add((string)row[columnName], 0);
                }


            }

            foreach(var val in discValue)
            {
                s.Points.AddXY(val.Key, val.Value);
            }
        }

  

        private void button1_Click(object sender, EventArgs e)
        {
            AddData();
        }
    }
}
