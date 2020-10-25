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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Operator.LoadData(openFileDialog1.FileName);
                RefreshTable();
            }
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
                Operator.NormalizeData(form.ColumnName);
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
                Operator.DiscretizeData(form.ColumnName, form.SectionNumber);
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
    }
}
