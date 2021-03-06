﻿using System;
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
            comboBox4.DataSource = Operator.Dt.Columns.Cast<DataColumn>().Select(i => i.ColumnName).ToList();
        }


        void AddData()
        {
            // we add two series:
            chart1.Series.Clear();

            List<string> allValuesFromColumn = Operator.Dt
                .AsEnumerable()
                .Select(row => row.Field<string>((string)comboBox4.SelectedItem)).Distinct().OrderBy(i=>i).ToList();
            foreach (string col in allValuesFromColumn)
            {
                Series s = chart1.Series.Add(col);
                s.ChartType = SeriesChartType.Point;
                s.MarkerStyle = MarkerStyle.Circle;
            }
            chart1.Series.OrderBy(i => i.Name);
            chart1.ApplyPaletteColors();

            if (comboBox1.SelectedItem != null || comboBox2.SelectedItem != null)
            {
                foreach (DataRow row in Operator.Dt.Rows)
                {
                    var className = row[(string)comboBox4.SelectedItem];
                    double x = double.Parse((string)row[(string)comboBox1.SelectedItem]);
                    double y = double.Parse((string)row[(string)comboBox2.SelectedItem]);

                    chart1.Series.Where(i => i.Name == (string)className).FirstOrDefault().Points.AddXY(x, y);
                }
            }
        }

  

        private void button1_Click(object sender, EventArgs e)
        {
            AddData();
        }
    }
}
