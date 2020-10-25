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
    public partial class Chart2D : Form
    {
        public Chart2D()
        {
            InitializeComponent();
            comboBox1.DataSource = Operator.GetRealColumns();
            comboBox2.DataSource = Operator.GetRealColumns();
            comboBox4.DataSource = Operator.GetStringColumns();
        }


        void AddData()
        {
            // we add two series:
            chart1.Series.Clear();

            List<string> allValuesFromColumn = Operator.Dt
                .AsEnumerable()
                .Select(row => row.Field<string>((string)comboBox4.SelectedItem)).Distinct().ToList();
            foreach (string col in allValuesFromColumn)
            {
                Series s = chart1.Series.Add(col);
                s.ChartType = SeriesChartType.Point;
                s.MarkerStyle = MarkerStyle.Circle;
            }
            chart1.ApplyPaletteColors();

            if (comboBox1.SelectedItem != null || comboBox2.SelectedItem != null)
            {


                var XValues = Operator.ConvertToListDouble(comboBox1.SelectedItem.ToString());
                var YValues = Operator.ConvertToListDouble(comboBox2.SelectedItem.ToString());

                for (int count = 0; count < Operator.Dt.Rows.Count; count++)
                {
                    string className = Operator.Dt.Rows[count].Field<string>((string)comboBox4.SelectedItem);
                    chart1.Series.Where(i => i.Name == className).FirstOrDefault().Points.AddXY(XValues[count], YValues[count]);

                }
            }
        }

  

        private void button1_Click(object sender, EventArgs e)
        {
            AddData();
        }
    }
}
