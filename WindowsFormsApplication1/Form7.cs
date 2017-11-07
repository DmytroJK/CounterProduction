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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            List<Order> orderlist;
            string path = @"All information\\Orders.dat";
            using (FileStream fs2 = new FileStream(path, FileMode.Open))
            {
                orderlist = (List<Order>)formatter.Deserialize(fs2);
            }
            foreach (Order Ord in orderlist)
            {
                dataGridView1.Rows.Add(Ord.Name, Ord.ZminaA,Ord.ZminaB,Ord.ZminaC,Ord.Count,Ord.Date);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path2 = @"All information\\Orders.dat";
            List<Order> orderlistCH = new List<Order>();
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                for (int j = 0; j < 1; ++j)
                {
                   
                    Order newfuckingorder = new Order();
                    newfuckingorder.Name = Convert.ToString(dataGridView1[j, i].Value);
                    newfuckingorder.ZminaA = Convert.ToInt32(dataGridView1[j + 1, i].Value);
                    newfuckingorder.ZminaB = Convert.ToInt32(dataGridView1[j + 2, i].Value);
                    newfuckingorder.ZminaC = Convert.ToInt32(dataGridView1[j + 3, i].Value);
                    newfuckingorder.Count = Convert.ToInt32(dataGridView1[j + 4, i].Value);
                    newfuckingorder.Date = Convert.ToDateTime(dataGridView1[j + 5, i].Value);
                    

                    orderlistCH.Add(newfuckingorder);
                }
            }
            using (FileStream fs = new FileStream(path2, FileMode.Create))
            {
                formatter.Serialize(fs, orderlistCH);
            }
        }
    }
}
