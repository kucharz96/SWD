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

    public partial class ChangeToNumber : Form
    {
        public string ColumnName
        {
            get
            {
                return comboBox1.SelectedValue.ToString();
            }
        }


        public ChangeToNumber()
        {
            InitializeComponent();
            comboBox1.DataSource = Operator.GetStringColumns();
        }
    }
}
