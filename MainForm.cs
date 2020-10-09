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
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
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
    }
}
