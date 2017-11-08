using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {   
        public Form1()
        { 
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String NameF1;
            int CountF1, ZminaAF1, ZminaBF1, ZminaCF1;
            string path = @"All information\\Orders.dat";
            NameF1 =  comboBox1.Text;
            CountF1  = Convert.ToInt32(textBox2.Text);
            ZminaAF1 = int.Parse(textBox4.Text);
            ZminaBF1 = int.Parse(textBox5.Text);
            ZminaCF1 = int.Parse(textBox6.Text);
            DateTime timeF1 = dateTimePicker1.Value;
            Order NewOrder = new Order(NameF1,CountF1,ZminaAF1,ZminaBF1,ZminaCF1,timeF1);
            BinaryFormatter formatter = new BinaryFormatter();
            List<Order> orderlist;


               
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                orderlist = (List<Order>)formatter.Deserialize(fs);
                orderlist.Add(NewOrder);
                
            }
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, orderlist);
            }
          Refresh();

            MessageBox.Show(NameF1 + " успішно добавлено");
            
           // textBox2.Clear();
           // textBox4.Clear();
           // textBox5.Clear();
           // textBox6.Clear();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = @"All information\\Orders.dat";
            string path2 = @"All information\\Models.dat";
           
            DirectoryInfo directory = new DirectoryInfo("All information");
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                if (!directory.Exists)
                {
                    directory.Create();
                }
                if (!File.Exists(path))
                {                 
                  Order orderexample = new Order("Example", 0, 0, 0, 0, new DateTime (1941, 06, 22));
                  List<Order> orderlist = new List<Order>();
                  orderlist.Add(orderexample);
               
                  using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                  {
                      formatter.Serialize(fs, orderlist);
                  }
                }
                if (!File.Exists(path2))
                {

                   Models modelexample = new Models("Example", 0, "size");
                   List<Models> modellist = new List<Models>();
                   modellist.Add(modelexample);
                   using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
                   {
                       formatter.Serialize(fs, modellist);
                   }

                } 
            }


            finally
            {
            }
            
           string line;
           FileStream file = new FileStream("All information\\Models.txt", FileMode.OpenOrCreate);
           StreamReader Action = new StreamReader(file, Encoding.UTF8);
           while ((line = Action.ReadLine()) != null)
           {
               comboBox1.Items.Add(line);
           }
           
            Action.Close();
            file.Close();

        }

        private void заДеньToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 newOrder = new Form7();
            newOrder.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
      
            }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Form2 NewForm2 = new Form2();
            NewForm2.Owner = this;
            NewForm2.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {      
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void заВесьЧасToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 NewForm3 = new Form3();
            NewForm3.Owner = this;
            NewForm3.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {    
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Form5 newLogPass = new Form5();
            newLogPass.ShowDialog();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {   
            int A,B,C,D;
            if (textBox5.Text == "") { textBox5.Text = "0"; }
            else;

            if (textBox6.Text == "") { textBox6.Text = "0"; }
            else;

           A = int.Parse(textBox4.Text);
           B = int.Parse(textBox5.Text);
           C = int.Parse(textBox6.Text);
           D = A + B + C;
           textBox2.Text = Convert.ToString(D);  
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "") textBox4.Text = "0";
            if (textBox6.Text == "") textBox6.Text = "0";
            int A, B, C, D;
            A = int.Parse(textBox4.Text);
            B = int.Parse(textBox5.Text);
            C = int.Parse(textBox6.Text);
            D = A + B + C;
            textBox2.Text = Convert.ToString(D);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "") textBox4.Text = "0";
            if (textBox5.Text == "") textBox5.Text = "0";
            int A, B, C, D;
            A = int.Parse(textBox4.Text);
            B = int.Parse(textBox5.Text);
            C = int.Parse(textBox6.Text);
            D = A + B + C;
            textBox2.Text = Convert.ToString(D);
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.SelectionStart = 0;
            textBox5.SelectionLength = textBox5.Text.Length;
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.SelectionStart = 0;
            textBox6.SelectionLength = textBox6.Text.Length;
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.SelectionStart = 0;
            textBox4.SelectionLength = textBox4.Text.Length;
        }

        private void добавитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 newModel = new Form6();
            newModel.ShowDialog();
        }
    }
    }

