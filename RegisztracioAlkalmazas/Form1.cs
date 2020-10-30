using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisztracioAlkalmazas
{
    public partial class RegisztracioAlkalmazas : Form
    {
        public RegisztracioAlkalmazas()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Hozzaad_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrWhiteSpace(textBox_UjHobbi.Text) && !listBox_KedvencHobbi.Items.Contains(textBox_UjHobbi.Text.Trim()))
            {
                listBox_KedvencHobbi.Items.Add(textBox_UjHobbi.Text.Trim());
            }

            textBox_UjHobbi.Text = "";

        }

        private void button_Mentes_Click(object sender, EventArgs e)
        {            
            
        }
    }
}
