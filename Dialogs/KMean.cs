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

    public partial class KMean: Form
    {
        public MetricsEnum Metric
        {
            get
            {
                return (MetricsEnum)(comboBox1.SelectedIndex +1);
            }
        }
        public int K
        {
            get
            {
                return (int)numericUpDown1.Value;
            }
        }


        public KMean()
        {
            InitializeComponent();
        }
    }
}
