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
            Models model = new Models(textBox1.Text, (Math.Round(double.Parse(textBox2.Text), 3)), textBox3.Text);

            
   
            using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
            {           
                modellist = (List<Models>)formatter.Deserialize(fs);
                modellist.Add(model);
            }
           using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
           {
               formatter.Serialize(fs, modellist);
           }
            MessageBox.Show("Модель " + textBox1.Text + " добавлено.");
           
            Close();

        }

   private void Form2_Load(object sender, EventArgs e)
   {
   }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }
    }
}
 
