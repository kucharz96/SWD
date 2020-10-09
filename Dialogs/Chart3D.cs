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
    public partial class Chart3D : Form
    {
        private Point mousePoint;
        public Chart3D()
        {
            InitializeComponent();
            Prepare3dChart();
            comboBox1.DataSource = Operator.GetRealColumns();
            comboBox2.DataSource = Operator.GetRealColumns();
            comboBox3.DataSource = Operator.GetRealColumns();
            comboBox4.DataSource = Operator.GetStringColumns();
        }
        public void Prepare3dChart()
        {
            var ca = chart1.ChartAreas[0];
            ca.Area3DStyle.Enable3D = true;
            ca.AxisX.Minimum = -10;
            ca.AxisY.Minimum = -10;
            ca.AxisX.Maximum = 10;
            ca.AxisY.Maximum = 10;
            ca.AxisX.Interval = 10;
            ca.AxisY.Interval = 10;
            ca.AxisX.Title = "X";
            ca.AxisY.Title = "Y";
            ca.AxisX.MajorGrid.Interval = 10;
            ca.AxisY.MajorGrid.Interval = 10;
            ca.AxisX.MinorGrid.Enabled = true;
            ca.AxisY.MinorGrid.Enabled = true;
            ca.AxisX.MinorGrid.Interval = 10;
            ca.AxisY.MinorGrid.Interval = 10;
            ca.AxisX.MinorGrid.LineColor = Color.LightSlateGray;
            ca.AxisY.MinorGrid.LineColor = Color.LightSlateGray;

            
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
                s.ChartType = SeriesChartType.Bubble;   // this ChartType has a YValue array
                s.MarkerStyle = MarkerStyle.Circle;
                s["PixelPointWidth"] = "20";
                s["PixelPointGapDepth"] = "1";
            }
            chart1.ApplyPaletteColors();

            if (comboBox1.SelectedItem != null || comboBox2.SelectedItem != null || comboBox3.SelectedItem != null)
            {


                var XValues = Operator.ConvertToListDouble(comboBox1.SelectedItem.ToString());
                var YValues = Operator.ConvertToListDouble(comboBox2.SelectedItem.ToString());
                var ZValues = Operator.ConvertToListDouble(comboBox3.SelectedItem.ToString());

                for (int count = 0; count < Operator.Dt.Rows.Count; count++)
                {
                    string className = Operator.Dt.Rows[count].Field<string>((string)comboBox4.SelectedItem);

                    AddXY3d(chart1.Series.Where(i=>i.Name == className).FirstOrDefault(), XValues[count], YValues[count], ZValues[count]);
                }
            }
        }

        int AddXY3d(Series s, double xVal, double yVal, double zVal)
        {
            int p = s.Points.AddXY(xVal, yVal, zVal);
            // the DataPoint are transparent to the regular chart drawing:
            s.Points[p].Color = Color.Transparent;
            return p;
        }

        private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
        {
            Chart chart = sender as Chart;

            if (chart.Series.Count < 1) return;
            if (chart.Series[0].Points.Count < 1) return;

            ChartArea ca = chart.ChartAreas[0];
            e.ChartGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            List<List<PointF>> data = new List<List<PointF>>();
            foreach (Series s in chart.Series)
                data.Add(GetPointsFrom3D(ca, s, s.Points.ToList(), e.ChartGraphics));

            renderPoints(data, e.ChartGraphics.Graphics, chart, 6);   // pick one!
        }

        List<PointF> GetPointsFrom3D(ChartArea ca, Series s,
                             List<DataPoint> dPoints, ChartGraphics cg)
        {
            var p3t = dPoints.Select(x => new Point3D((float)ca.AxisX.ValueToPosition(x.XValue),
                (float)ca.AxisY.ValueToPosition(x.YValues[0]),
                (float)ca.AxisY.ValueToPosition(x.YValues[1]))).ToArray();
            ca.TransformPoints(p3t.ToArray());

            return p3t.Select(x => cg.GetAbsolutePoint(new PointF(x.X, x.Y))).ToList();
        }

        void renderPoints(List<List<PointF>> data, Graphics graphics, Chart chart, float width)
        {
            for (int s = 0; s < chart.Series.Count; s++)
            {
                Series S = chart.Series[s];
                for (int p = 0; p < S.Points.Count; p++)
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(64, S.Color)))
                        graphics.FillEllipse(brush, data[s][p].X - width / 2,
                                             data[s][p].Y - width / 2, width, width);
            }
        }

        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (mousePoint.IsEmpty)
                    mousePoint = e.Location;
                else
                {

                    int newy = chart1.ChartAreas[0].Area3DStyle.Rotation + (e.Location.X - mousePoint.X);
                    if (newy < -180)
                        newy = -180;
                    if (newy > 180)
                        newy = 180;

                    chart1.ChartAreas[0].Area3DStyle.Rotation = newy;

                    newy = chart1.ChartAreas[0].Area3DStyle.Inclination + (e.Location.Y - mousePoint.Y);
                    if (newy < -90)
                        newy = -90;
                    if (newy > 90)
                        newy = 90;

                    chart1.ChartAreas[0].Area3DStyle.Inclination = newy;

                    mousePoint = e.Location;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddData();
        }
    }
}
