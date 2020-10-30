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
            this.CenterToScreen();
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
            if ((!String.IsNullOrWhiteSpace(textBox_Nev.Text)) && (dateTimePicker_SzulDatum.Value.Date <= DateTime.Now.Date) && (radioButton_Ferfi.Checked || radioButton_No.Checked) && (listBox_KedvencHobbi.SelectedIndex != -1))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filenev = saveFileDialog.FileName;
                    StreamWriter sw = new StreamWriter(filenev);

                    sw.Write(textBox_Nev.Text.Trim() + ";" + dateTimePicker_SzulDatum.Value.Date + ";" + radioButton_Ferfi.Checked + ";" + radioButton_No.Checked+";");
                    foreach (var item in listBox_KedvencHobbi.Items)
                    {
                        sw.Write(item+",");
                    }

                    sw.Close();

                }
            }
            else
            {
                MessageBox.Show("Valami nincs rendesen kitöltve");
            }
        }

        private void button_Betoltes_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filenev = openFileDialog.OpenFile();
                StreamReader sr = new StreamReader(filenev);

                string[] beolvas;
                beolvas = sr.ReadToEnd().Split(';');
                textBox_Nev.Text = beolvas[0];
                dateTimePicker_SzulDatum.Value = DateTime.Parse(beolvas[1]);
                radioButton_Ferfi.Checked = Boolean.Parse(beolvas[2]);
                radioButton_No.Checked = Boolean.Parse(beolvas[3]);
                string[] hobbik=beolvas[4].Split(',');
                foreach (var item in hobbik)
                {
                    listBox_KedvencHobbi.Items.Add(item);
                }

            }

        }
    }
}
