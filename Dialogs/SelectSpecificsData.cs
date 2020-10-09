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
    public partial class SelectSpecificsData : Form
    {
        public string ColumnName
        {
            get
            {
                return comboBox1.SelectedValue.ToString();
            }
        }

        public int Percent
        {
            get
            {
                return int.Parse(textBox1.Text);
            }
        }
        public SelectSpecificsData()
        {
            InitializeComponent();
            comboBox1.DataSource = Operator.GetRealColumns();
        }
    }
}
