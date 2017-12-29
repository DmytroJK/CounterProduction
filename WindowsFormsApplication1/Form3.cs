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
            if  (Convert.ToString(comboBox1.SelectedItem) =="")
            {
                MessageBox.Show("Виберіть модель із списку");
                goto stop;
            }

            dataGridView1.Rows.Clear();

            DateTime from = dateTimePicker1.Value.Date;
            DateTime to = dateTimePicker2.Value.Date.AddDays(1);

            BinaryFormatter formatter = new BinaryFormatter();

            List<Order> orderlist;
            List<Models> modellist;

            string path = @"All information\\Models.dat";
            string path2 = @"All information\\Orders.dat";

            double ZminaACub = 0, ZminaBCub = 0, ZminaCCub = 0, AllCub = 0, cubes = 0;       //names of variables are terrible, i know.
            int All = 0, Count, ZminaAVse = 0, ZminaBVse = 0, ZminaCVse = 0, VseVse = 0, number = 1;

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
                if (from <= Ord.Date && to >= Ord.Date && Ord.Name == comboBox1.SelectedItem.ToString())
                {
                    {
                        foreach (Models Mod in modellist)
                        {

                            if (Mod.Name == Ord.Name)
                                cubes = Mod.Cub;
                        }

                        Count = (Ord.ZminaA + Ord.ZminaB + Ord.ZminaC);
                        dataGridView1.Rows.Add(number, Ord.Name, Ord.ZminaA, Ord.ZminaB, Ord.ZminaC, Count, Ord.Date, cubes);
                        ZminaACub += Ord.ZminaA * cubes;
                        ZminaBCub += Ord.ZminaB * cubes;
                        ZminaCCub += Ord.ZminaC * cubes;
                        AllCub += Count * cubes;
                        ZminaAVse += Ord.ZminaA;
                        ZminaBVse += Ord.ZminaB;
                        ZminaCVse += Ord.ZminaC;                   
                        VseVse += Count;
                        number++;
                        All++;
                    }
                }

              
            }
            if (All != 0)
            {
                dataGridView1.Rows.Add("", "Загальна кількість", ZminaAVse, ZminaBVse, ZminaCVse, VseVse);
                dataGridView1.Rows[All].DefaultCellStyle.ForeColor = Color.Red;
                dataGridView1.Rows.Add("", "Загальна кубатура", Math.Round(ZminaACub, 3), Math.Round(ZminaBCub, 3), Math.Round(ZminaCCub, 3), Math.Round(AllCub, 3) );
                dataGridView1.Rows[All + 1].DefaultCellStyle.ForeColor = Color.Red;
            }
        stop:;
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
            string path = @"All information\\Orders.dat";
            string path2 = @"All information\\Models.dat";

            BinaryFormatter formatter = new BinaryFormatter();
            List<Models> ModelListStart = new List<Models>();
            List<Order> OrderListStart = new List<Order>();


            using (FileStream fs2 = new FileStream(path, FileMode.Open))
            {
                OrderListStart = (List<Order>)formatter.Deserialize(fs2);
                if (OrderListStart[0].Name == "Example" && OrderListStart[0].ZminaA == 0 && OrderListStart[1].ZminaA != 0)
                    OrderListStart.RemoveAt(0);
            }
            using (FileStream fs2 = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs2, OrderListStart);
            }
            using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
            {
                ModelListStart = (List<Models>)formatter.Deserialize(fs);

                if (ModelListStart[0].Name == "Example"  && ModelListStart[1].Cub != 0)
                    ModelListStart.RemoveAt(0);
            }
          
            foreach (Models item in ModelListStart)
                {    
                    comboBox1.Items.Add(item.Name);
                }
            using (FileStream fs = new FileStream(path2, FileMode.Open))
            {
                formatter.Serialize(fs, ModelListStart);
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
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DateTime from = dateTimePicker1.Value.Date;
            DateTime to = dateTimePicker2.Value.Date.AddDays(1);
            BinaryFormatter formatter = new BinaryFormatter();
            List<Order> orderlist;
            List<Models> modellist;
            string path = @"All information\\Models.dat"; 
            string path2 = @"All information\\Orders.dat";

            double ZminaACub = 0, ZminaBCub = 0, ZminaCCub = 0, AllCub = 0, cubes = 0, aCubAll = 0, bCubAll = 0, cCubAll = 0, ABCCubAll = 0;        //names of variables are terrible, i know.
            int All = 0, Count, ZminaAVse = 0, ZminaBVse = 0, ZminaCVse = 0, VseVse = 0, All2 = 0, countA = 0, сountB = 0, сountC = 0, countABC = 0, number = 1;
            using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
            {
                orderlist = (List<Order>)formatter.Deserialize(fs);
            }
            using (FileStream fs2 = new FileStream(path, FileMode.OpenOrCreate))
            {
                modellist = (List<Models>)formatter.Deserialize(fs2);
            }
            foreach (Models Mod in modellist)
            {
                foreach (Order Ord in orderlist)
                {
                    if (Mod.Name == Ord.Name)
                        cubes = Mod.Cub;


                    if (from <= Ord.Date && to >= Ord.Date && Mod.Name == Ord.Name)
                    {

                        Count = (Ord.ZminaA + Ord.ZminaB + Ord.ZminaC);
                        dataGridView1.Rows.Add(number, Ord.Name, Ord.ZminaA, Ord.ZminaB, Ord.ZminaC, Count, Ord.Date, cubes);
                        countA += Ord.ZminaA;
                        сountB += Ord.ZminaB;
                        сountC += Ord.ZminaC;
                        countABC += Count;
                        ZminaACub += Ord.ZminaA * cubes;
                        ZminaBCub += Ord.ZminaB * cubes;
                        ZminaCCub += Ord.ZminaC * cubes;
                        AllCub += Count * cubes;
                        ZminaAVse += Ord.ZminaA;
                        ZminaBVse += Ord.ZminaB;
                        ZminaCVse += Ord.ZminaC;
                        VseVse += Count;
                        aCubAll += ZminaACub;
                        bCubAll += ZminaBCub;
                        cCubAll += ZminaCCub;
                        ABCCubAll += AllCub;
                        number++;
                        All++;



                    }



                }
                if (All != 0 && All2!=All )
                {

                    dataGridView1.Rows.Add("", "Кількість "+Mod.Name, ZminaAVse, ZminaBVse, ZminaCVse, VseVse);
                    dataGridView1.Rows[All].DefaultCellStyle.ForeColor = Color.Red;
                    dataGridView1.Rows.Add("", "Кубатура " + Mod.Name, Math.Round(ZminaACub, 3), Math.Round(ZminaBCub, 3), Math.Round(ZminaCCub, 3), Math.Round(AllCub, 3));
                    dataGridView1.Rows[All + 1].DefaultCellStyle.ForeColor = Color.Red;

                    ZminaACub = 0;
                    ZminaBCub = 0;
                    ZminaCCub = 0;
                    AllCub = 0;
                    ZminaAVse = 0;
                    ZminaBVse = 0;
                    ZminaCVse = 0;
                    VseVse = 0;

                    All++;
                    All++;
                    All2 = All;
                }
            }
            dataGridView1.Rows.Add("", "Кількість по змінам:", countA, сountB, сountC, countABC );
            dataGridView1.Rows[All2].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.Rows.Add("", "Кубатура по змінам:", Math.Round(aCubAll, 3) , Math.Round(bCubAll, 3), Math.Round(cCubAll, 3), Math.Round(ABCCubAll, 3));
            dataGridView1.Rows[All2+1].DefaultCellStyle.ForeColor = Color.Blue;
        }
    }
}
