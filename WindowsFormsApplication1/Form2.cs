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
using System.Runtime.Serialization.Formatters.Binary;


namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        double A, B, C, D;

        public Form2()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            List<Models> modellist;
            Form1 mainform = this.Owner as Form1;   // 1 пункт в зошиті
                                                    //     mainform.comboBox1.Items.Add(textBox1.Text);
            string path2 = @"All information\\Models.dat";
            Models model = new Models(textBox1.Text, (double.Parse(label4.Text)));

            using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
            {
                modellist = (List<Models>)formatter.Deserialize(fs);
                modellist.Add(model);
            }
            using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, modellist);
            }
            MessageBox.Show("Модель " + textBox1.Text + " з кубатурою " + label4.Text+ " добавлено.");

            Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }



        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "") textBox4.Text = "0";
            if (textBox5.Text == "") textBox5.Text = "0";
            A = Convert.ToDouble(textBox4.Text);
            B = Convert.ToDouble(textBox5.Text);
            C = Convert.ToDouble(textBox6.Text);
            D = Math.Round((A * B * C), 6);
            label4.Text = Convert.ToString(D);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch!= 44) 
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //  double A, B, C, D;
            if (textBox5.Text == "") { textBox5.Text = "0"; }


            if (textBox6.Text == "") { textBox6.Text = "0"; }


            A = Convert.ToDouble(textBox4.Text);
            B = Convert.ToDouble(textBox5.Text);
            C = Convert.ToDouble(textBox6.Text);
            D = Math.Round((A * B * C), 6);
            label4.Text = Convert.ToString(D);

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "") textBox4.Text = "0";
            if (textBox6.Text == "") textBox6.Text = "0";
            A = Convert.ToDouble(textBox4.Text);
            B = Convert.ToDouble(textBox5.Text);
            C = Convert.ToDouble(textBox6.Text);
            D = Math.Round((A * B * C), 6);
            label4.Text = Convert.ToString(D);
        }
    }
}
 
