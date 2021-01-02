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

    public partial class DiscretizeData : Form
    {
        public string ColumnName
        {
            get
            {
                return comboBox1.SelectedValue.ToString();
            }
        }
        public bool AllColumns
        {
            get
            {
                return checkBox1.Checked;
            }
        }

        public int SectionNumber
        {
            get
            {
                return (int)numericUpDown1.Value;
            }
        }


        public DiscretizeData()
        {
            InitializeComponent();
            comboBox1.DataSource = Operator.GetRealColumns();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
