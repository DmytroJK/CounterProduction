using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path4 = @"All information\\Pass.dat";
            BinaryFormatter formatter = new BinaryFormatter();
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введіть логін");
                goto mistake;
            }
            if (textBox2.Text =="")
            {
                MessageBox.Show("Введіть пароль");
                goto mistake;
            }
            string login = textBox1.Text;
            string password = textBox2.Text;
            Pass dd = new Pass();
            // if (dd.Login == login && dd.password == password)
            // {
            //  
            //
            //
            //
            //
            //} else 
            // MessageBox.Show("Неправильний логін, або пароль")


          using (FileStream fs = new FileStream(path4, FileMode.OpenOrCreate))
          {
           dd =  (Pass)formatter.Deserialize(fs);
          }
          if (dd.Login==login&& dd.Password != password)
          {
              MessageBox.Show("Неправильний пароль");
              goto mistake;
          }
          if (dd.Login != login && dd.Password == password)
          {
              MessageBox.Show("Неправильний логін");
              goto mistake;
          }
          if (dd.Login != login && dd.Password != password)
          {
              MessageBox.Show("Неправильний логін і пароль");
              goto mistake;
          }

           Form1 meh= new Form1();
            Hide();
            meh.ShowDialog();
            

        mistake: ;

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string path4 = @"All information\\Pass.dat";
            BinaryFormatter formatter = new BinaryFormatter();
            if (!File.Exists(path4))
            {
                Pass passexample = new Pass("admin", "12345");


                using (FileStream fs = new FileStream(path4, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, passexample);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
