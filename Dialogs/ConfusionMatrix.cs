using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWD.Dialogs
{
    public partial class ConfusionMatrix : Form
    {
        public ConfusionMatrix()
        {
            InitializeComponent();
            comboBox1.DataSource = Operator.Dt.Columns.Cast<DataColumn>().Select(i => i.ColumnName).ToList();
            comboBox2.DataSource = Operator.Dt.Columns.Cast<DataColumn>().Select(i => i.ColumnName).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            List<string> allValuesFromColumn1 = Operator.Dt
                .AsEnumerable()
                .Select(row => row.Field<string>((string)comboBox1.SelectedItem)).Distinct().OrderBy(i => i).ToList();
            List<string> allValuesFromColumn2 = Operator.Dt
                .AsEnumerable()
                .Select(row => row.Field<string>((string)comboBox2.SelectedItem)).Distinct().OrderBy(i => i).ToList();


            foreach(var col1Val in allValuesFromColumn1)
            {
                dataGridView1.Columns.Add(col1Val, col1Val);
            }

            foreach (var col1Val in allValuesFromColumn2)
            {
                var dgR = new DataGridViewRow();
                dgR.HeaderCell.Value = col1Val;
                dataGridView1.Rows.Add(dgR);
            }


            foreach(DataRow row in Operator.Dt.Rows)
            {

                var x = row[comboBox1.SelectedItem.ToString()];
                var y = row[comboBox2.SelectedItem.ToString()];

                int idx = allValuesFromColumn1.IndexOf(x.ToString());
                int idy = allValuesFromColumn2.IndexOf(y.ToString());
                int.TryParse(dataGridView1[idx, idy].Value == null ? "0" : dataGridView1[idx, idy].Value.ToString(), out int val);
                val++;
                dataGridView1[idx, idy].Value = val;

            }

            for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count; col++)
                {
                    dataGridView1.Rows[rows].Cells[col].Value = dataGridView1.Rows[rows].Cells[col].Value == null ? 0 : dataGridView1.Rows[rows].Cells[col].Value;

                }
            }



            dataGridView1.Refresh();





        }
    }
}
