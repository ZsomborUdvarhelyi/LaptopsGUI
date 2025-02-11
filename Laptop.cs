namespace LaptopsCLI
{
    internal class Laptop
    {
        public Category Category { get; set; }
        public string CPU { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Model { get; set; }
        public string OS { get; set; }
        public string Price { get; set; }
        public int RAM { get; set; }
        public string Screen { get; set; }
        public string Storage { get; set; }

        public override string ToString() => $"{Manufacturer.ManufacturerName} {Model}";

        public Laptop(string s)
        {
            var v = s.Split(';');
            Category = new Category( int.Parse(v[0]), v[1] );
            CPU = v[2];
            Manufacturer = new Manufacturer ( int.Parse(v[3]), v[4] );
            Model = v[5];
            OS = v[6];
            Price = v[7];
            RAM = int.Parse(v[8]);
            Screen = v[9];
            Storage = v[10];
        }
    }
}
