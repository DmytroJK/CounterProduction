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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            List<Models> modellist;
            string path = @"All information\\Models.dat";
            using (FileStream fs2 = new FileStream(path, FileMode.OpenOrCreate))
            {
                modellist = (List<Models>)formatter.Deserialize(fs2);
            }
            foreach (Models Mod in modellist)
            {
                dataGridView1.Rows.Add(Mod.Name, Mod.Cub, Mod.Size);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = @"All information\\Models.dat";
            List<Models> modellistCH = new List<Models>();
            for (int i = 0; i < (dataGridView1.Rows.Count-1); ++i)
            {
                for (int j = 0; j < 1; ++j)
                {
                    Models newfuckingmodel = new Models();
                    newfuckingmodel.Name = Convert.ToString(dataGridView1[j, i].Value);
                    newfuckingmodel.Cub = Convert.ToDouble(dataGridView1[j+1, i].Value);
                    newfuckingmodel.Size = Convert.ToString(dataGridView1[j + 2, i].Value);

                    modellistCH.Add(newfuckingmodel);
                }
            }
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(fs, modellistCH);
            }
            Close();

       
        //    this.FormClosing += Form6_FormClosing; // чтоб срабатывал Form1_FormClosing
      

    }

       // private void Form6_FormClosing(object sender, FormClosingEventArgs e)
       // {
       //     Form1 forma = new Form1();
       //     forma.Refresh();
       // }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
