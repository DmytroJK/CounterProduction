using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    [Serializable]
    class Order
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public int ZminaA { get; set; }
        public int ZminaB { get; set; }
        public int ZminaC { get; set; }
        public DateTime Date{ get; set; }
        public string Size { get; set; }



        public Order (String name, int count, int zminaA, int zminaB, int zminaC, DateTime date, string size)
        {
            Name = name;
            Count = count;
            ZminaA = zminaA;
            ZminaB = zminaB;
            ZminaC = zminaC;
            Date = date;
            Size = size;
        }
        public Order() { }
    }
}
