using System;


namespace WindowsFormsApplication1
{   [Serializable]
    class Models
    {
        public string Name { get; set; }
        public double Cub { get; set; }

        public Models (string name, double cub)
        {
            Name = name;
            Cub = cub;
        }
        public Models() { }
    }
}
