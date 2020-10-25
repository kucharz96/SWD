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

    public partial class ChangeRange : Form
    {
        public string ColumnName
        {
            get
            {
                return comboBox1.SelectedValue.ToString();
            }
        }

        public double FromRange
        {
            get
            {
                return double.Parse(textBox1.Text);
            }
        }

        public double ToRange
        {
            get
            {
                return double.Parse(textBox2.Text);
            }
        }


        public ChangeRange()
        {
            InitializeComponent();
            comboBox1.DataSource = Operator.GetRealColumns();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
