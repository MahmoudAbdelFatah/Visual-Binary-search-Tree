using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS_project
{
    public partial class Choose : Form
    {
        public string cho;
        public Choose()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cho = comboBox1.Text;
            if (cho == "")
            {
                MessageBox.Show("invalid !");
            }
            else
                this.Close();
        }
    }
}
