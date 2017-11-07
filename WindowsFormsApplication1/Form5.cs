using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path4 = @"All information\\Pass.dat";
            BinaryFormatter formatter = new BinaryFormatter();
            Pass dd = new Pass();
            using (FileStream fs = new FileStream(path4, FileMode.Open))
            {
                dd = (Pass)formatter.Deserialize(fs);
            }

            if (textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Введіть старий пароль або логін");
                goto mistake;

            }

            if (textBox2.Text==""||textBox4.Text=="")
            {
                MessageBox.Show("Введіть новий пароль або логін");
                goto mistake;

            }
            if (textBox1.Text != dd.Login || textBox3.Text != dd.Password)
            {
                MessageBox.Show("Неправильний старий пароль або логін");
                goto mistake;

            }
            if (dd.Login == textBox1.Text && dd.Password == textBox3.Text)
            {
                dd.Login = textBox2.Text;
                dd.Password = textBox4.Text;
                using (FileStream fs = new FileStream(path4, FileMode.Open))
                {
                    formatter.Serialize(fs,dd);
                }
                MessageBox.Show("Логін і пароль успішно змінено");

            }

           Close();
           mistake:;


        }
    }
}
