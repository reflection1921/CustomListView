using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomListViewExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChangeBlankArea_Click(object sender, EventArgs e)
        {
            customListView1.ColumnHeaderBlankAreaColor = Color.Black;
        }

        private void btnChangeBorder_Click(object sender, EventArgs e)
        {
            customListView1.ColumnHeaderBorderColor = Color.Red;
        }
    }
}
