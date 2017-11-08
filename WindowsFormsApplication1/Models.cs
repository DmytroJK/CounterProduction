using System;


namespace WindowsFormsApplication1
{   [Serializable]
    class Models
    {
        public string Name { get; set; }
        public double Cub { get; set; }
        public string Size { get; set; }

        public Models (string name, double cub, string size)
        {
            Name = name;
            Cub = cub;
            Size = size;
        }
        public Models() { }
    }
}
