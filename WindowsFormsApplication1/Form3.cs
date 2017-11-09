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
            
            dataGridView1.Rows.Clear();   
            DateTime from = dateTimePicker1.Value.Date;
            DateTime to =   dateTimePicker2.Value.Date.AddDays(1);
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

            

            
            foreach (Order Ord in orderlist)
            {
               if (checkBox1.Checked) { 
                                       
                        foreach (Models Mod in modellist)
                        {

                            if (Mod.Name == Ord.Name)
                                cubes = Mod.Cub;
                        }
                        Count = (Ord.ZminaA + Ord.ZminaB + Ord.ZminaC);
                        dataGridView1.Rows.Add(Ord.Name, Ord.ZminaA, Ord.ZminaB, Ord.ZminaC, Count, Ord.Date, Ord.Size);
                        ZminaACub += Ord.ZminaA * cubes;
                        ZminaBCub += Ord.ZminaB * cubes;
                        ZminaCCub += Ord.ZminaC * cubes;
                        AllCub += Count * cubes;
                        All++;   
                    }

                    else
                    {
                    if (from <= Ord.Date && to >= Ord.Date && Ord.Name == comboBox1.SelectedItem.ToString())
                    {
                        foreach (Models Mod in modellist)
                        {

                            if (Mod.Name == Ord.Name)
                                cubes = Mod.Cub;



                        }
                        Count = (Ord.ZminaA + Ord.ZminaB + Ord.ZminaC);
                        dataGridView1.Rows.Add(Ord.Name, Ord.ZminaA, Ord.ZminaB, Ord.ZminaC, Count, Ord.Date, Ord.Size);
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

            comboBox1.Items.Clear();
            string path2 = @"All information\\Models.dat";

            BinaryFormatter formatter = new BinaryFormatter();
            List<Models> ModelListStart = new List<Models>();

            using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
            {
                ModelListStart = (List<Models>)formatter.Deserialize(fs);
                foreach (Models item in ModelListStart)
                {
                    comboBox1.Items.Add(item.Name);
                }
            }
            //  string line;
            //  FileStream file = new FileStream("All information\\Models.txt", FileMode.OpenOrCreate);
            //  StreamReader Action = new StreamReader(file, Encoding.UTF8);
            //  while ((line = Action.ReadLine()) != null)
            //  {
            //      comboBox1.Items.Add(line);
            //  }
            //
            //  Action.Close();
            //  file.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
