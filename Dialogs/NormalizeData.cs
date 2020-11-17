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

    public partial class NormalizeData : Form
    {
        public string ColumnName
        {
            get
            {
                return comboBox1.SelectedValue.ToString();
            }
        }

        public bool AllColumnsAndChange
        {
            get
            {
                return checkBox1.Checked;
            }
        }


        public NormalizeData()
        {
            InitializeComponent();
            comboBox1.DataSource = Operator.GetRealColumns();
        }
    }
}
