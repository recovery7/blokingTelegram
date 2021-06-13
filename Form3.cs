using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blokingTelegram
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void randLabel()
        {
            Random rand = new Random();
            int i = 0;
            i = rand.Next(200, 15000);
            label2.Text = i.ToString();
            i = rand.Next(200, 15000);
            label3.Text = i.ToString();
            i = rand.Next(200, 15000);
            label4.Text = i.ToString();
            i = rand.Next(200, 15000);
            label5.Text = i.ToString();
        }
    }
}
