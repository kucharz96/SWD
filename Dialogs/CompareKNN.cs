using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SWD.Dialogs
{
    public partial class CompareKNN : Form
    {
        public CompareKNN()
        {
            InitializeComponent();
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;

            for(int i = 1; i < 4; i++)
            {
                List<Dictionary<int, KNNValuePair>> allDistanses = new List<Dictionary<int, KNNValuePair>>();
                for (int a = 0; a < Operator.Dt.Rows.Count; a++)
                {
                    allDistanses.Add(Operator.KNNClasificationDistances(a, (MetricsEnum)i));
                }

                for (int k = 1; k < Operator.Dt.Rows.Count; k++)
                {
                    if(i==1)
                        dataGridView1.Rows.Add();
                    dataGridView1[0, k - 1].Value = k;
                    double correctPredict = 0;
                    for (int a = 0; a < Operator.Dt.Rows.Count; a++)
                    {
                        if ((string)Operator.Dt.Rows[a][Operator.Dt.Columns[Operator.Dt.Columns.Count - 1]] == Operator.KNNPredictVariable(allDistanses[a], k))
                        {
                            correctPredict++;
                        }
                    }
                    dataGridView1[i, k - 1].Value = correctPredict / (double)Operator.Dt.Rows.Count;


                }
                string name="";

                switch ((MetricsEnum)i)
                {
                    case MetricsEnum.Czebyszew:
                        name = "Czebyszew";
                        break;
                    case MetricsEnum.Euclides:
                        name = "Euklides";
                        break;
                    case MetricsEnum.Manhattan:
                        name = "Manhattan";
                        break;
                }


                Series ser2 = chart1.Series.Add(name);
                ser2.ChartType = SeriesChartType.Line;


                for(int x = 0; x < dataGridView1.Rows.Count-1; x++)
                {
                    var kval = dataGridView1[0, x].Value;
                    var mval = dataGridView1[i, x].Value;
                    ser2.Points.AddXY(kval, mval);
                }


            }











            System.Windows.Forms.Cursor.Current = Cursors.Default;



        }
    }
}
