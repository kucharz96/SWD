using SWD.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWD
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void RefreshTable()
        {
            dataGridView1.DataSource = Operator.Dt;
            dataGridView1.Refresh();
        }


        private void zamianaDanychTekstowychNaNumeryczneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeToNumber form = new ChangeToNumber();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Operator.ChangeToNumber(form.ColumnName);
                RefreshTable();
            }
        }

        private void normalizacjaZmiennychRzeczywistychToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NormalizeData form = new NormalizeData();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.AllColumnsAndChange)
                {
                    foreach(var col in Operator.GetRealColumns())
                    {

                        if(Operator.GetColumnsWithoutLast().Any(i=>i == col))
                        {
                            Operator.NormalizeData(col, true);
                        }
                        
                    }
                }
                else
                {
                    Operator.NormalizeData(form.ColumnName);
                }
                
                RefreshTable();
            }
        }

        private void wykres3DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chart3D form = new Chart3D();
            form.Show();
        }

        private void najmniejszychToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectSpecificsData form = new SelectSpecificsData();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Operator.SelectSpecificsData(dataGridView1, form.ColumnName, form.Percent);
                RefreshTable();
            }
        }

        private void największychToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectSpecificsData form = new SelectSpecificsData();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Operator.SelectSpecificsData(dataGridView1, form.ColumnName, form.Percent, true);
                RefreshTable();
            }
        }

        private void dyskretyzacjaZmiennychRzeczywistychToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiscretizeData form = new DiscretizeData();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Operator.DiscretizeData(form.ColumnName, form.SectionNumber,form.AllColumns);
                RefreshTable();
            }
        }

        private void zmianaPrzedziałuWartościToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeRange form = new ChangeRange();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Operator.ChangeRange(form.ColumnName, form.FromRange, form.ToRange);
                RefreshTable();
            }
        }

        private void wykres2DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chart2D form = new Chart2D();
            form.Show();
        }

        private void zmienneRzeczywisteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RealHistogram form = new RealHistogram();
            form.Show();
        }

        private void zmienneDyskretneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiscretizeHistogram form = new DiscretizeHistogram();
            form.Show();
        }

        private void klasyfikujToolStripMenuItem_Click(object sender, EventArgs e)
        {

            KNNClasifications clasifications = new KNNClasifications();
            if(clasifications.ShowDialog() == DialogResult.OK)
            {
                Operator.KNNClasifications(dataGridView1.SelectedRows[0].Index, clasifications.K, clasifications.Metric);
                RefreshTable();
            }
        }



        private void withColumnNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Operator.LoadData(openFileDialog1.FileName);
                RefreshTable();
            }
        }

        private void withoutColumnNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Operator.LoadData(openFileDialog1.FileName,true);
                RefreshTable();
            }
        }

        private void ocenaWartościKlasyfikacjiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompareKNN form = new CompareKNN();
            form.Show();
        }

        private void grupujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KMean clasifications = new KMean();
            if (clasifications.ShowDialog() == DialogResult.OK)
            {
                Operator.KMeanGroup(clasifications.Metric,clasifications.K);
                RefreshTable();
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                foreach(var cell in dataGridView1.SelectedCells.Cast<DataGridViewTextBoxCell>())
                {
                    Operator.Dt.Columns.RemoveAt(cell.ColumnIndex);
                }
                RefreshTable();
            }
        }

        private void macierzPomyłekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfusionMatrix form = new ConfusionMatrix();
            form.Show();
        }

        private void znajdzOptymalneKlastryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KMeanOptimum form = new KMeanOptimum();
            form.Show();
        }

        private void budujDrzewoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Operator.BeginBulidTree();
            Cursor.Current = Cursors.Default;
        }

        private void klasyfikujToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Operator.DecisionTreeClasify(dataGridView1.SelectedRows[0].Index);
            RefreshTable();
            
        }

        private void jakośćLeaveoneoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double quality = Operator.DecisionTreeQuality();
            var result = MessageBox.Show("Jakość wynosi: " + quality, "Jakość Leave-one-out",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

        }

        private void wektoryBinarneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WektoryBinarne wektory = new WektoryBinarne();
            wektory.Show();
        }
    }
}
