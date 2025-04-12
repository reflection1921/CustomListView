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
            AddItems();
        }

        private void AddItems()
        {
            var item = new ListViewItem("1");
            item.SubItems.Add("生きていたんだよな");
            item.SubItems.Add("あいみょん");
            customListView1.Items.Add(item);

            item = new ListViewItem("2");
            item.SubItems.Add("ノット・オーケー");
            item.SubItems.Add("あいみょん");
            customListView1.Items.Add(item);

            item = new ListViewItem("3");
            item.SubItems.Add("初恋が泣いている");
            item.SubItems.Add("あいみょん");
            customListView1.Items.Add(item);
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
