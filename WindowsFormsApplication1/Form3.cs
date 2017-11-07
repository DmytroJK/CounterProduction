using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            dataGridView1.Rows.Clear();   
            DateTime from = dateTimePicker1.Value.Date;
            DateTime to =   dateTimePicker2.Value.Date.AddDays(1);
            MessageBox.Show(Convert.ToString(from));
            BinaryFormatter formatter = new BinaryFormatter();
            List<Order> orderlist;
            List<Models> modellist;
            string path = @"All information\\Models.dat";
            string path2 = @"All information\\Orders.dat";
            double cubes = 0;
            double ZminaACub = 0, ZminaBCub = 0, ZminaCCub = 0, AllCub = 0;
            int All = 0, Count;
            using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
            {
                orderlist = (List<Order>)formatter.Deserialize(fs);
            }


            using (FileStream fs2 = new FileStream(path, FileMode.OpenOrCreate))
            {
                modellist = (List<Models>)formatter.Deserialize(fs2);
            }

            

            string selectedItem2 = comboBox1.SelectedItem.ToString();
            foreach (Order Ord in orderlist)
            {
               
                if (from <= Ord.Date && to >= Ord.Date && Ord.Name==selectedItem2)
                { foreach (Models Mod in modellist)
                    {

                        if (Mod.Name == Ord.Name)
                            cubes = Mod.Cub;

                    }
                    Count = (Ord.ZminaA + Ord.ZminaB + Ord.ZminaC);
                    dataGridView1.Rows.Add(Ord.Name, Ord.ZminaA, Ord.ZminaB, Ord.ZminaC, Count, Ord.Date);
                    ZminaACub += Ord.ZminaA * cubes;
                    ZminaBCub += Ord.ZminaB * cubes;
                    ZminaCCub += Ord.ZminaC * cubes;
                    AllCub += Count * cubes;
                    All++;
           //        string text = "Назва моделі: " + Ord.Name + Environment.NewLine + "Кількість: " +
           //            Ord.Count + Environment.NewLine + "Кубатура: " +
           //            Math.Round((cubes * Ord.Count), 3) +
           //            Environment.NewLine + "Зміна А: " + Ord.ZminaA + Environment.NewLine + "Зміна Б: "
           //            + Ord.ZminaB + Environment.NewLine + "Зміна С: " + Ord.ZminaC + Environment.NewLine + Ord.Date +
           //            Environment.NewLine + "_____________________________________________________________________________" +
           //            "_____________________________________________________________________________";
           //
           //        ;
           //        textBox1.Text += text;

                }
               
                else
                {

                }
               
            }
           
                dataGridView1.Rows.Add("Загальна кубатура", ZminaACub, ZminaBCub, ZminaCCub, AllCub);
                dataGridView1.Rows[All].DefaultCellStyle.ForeColor = Color.Red;
        

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
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
    }
}
