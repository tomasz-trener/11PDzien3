using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P10AplikacjaOkienkowa
{
    public partial class Form1 : Form
    {
        string[] napisy = { "ala", "ma", "kota" };
        int napisx = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtImie.Text = napisy[napisx];

            napisx++;

            if (napisx == napisy.Length)
                napisx = 0;
        }
    }
}
