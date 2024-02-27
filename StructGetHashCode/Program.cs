using System.Security.Cryptography.X509Certificates;

class Program
{
    struct House
    {
        public int Length { get; set; }
        public int Height { get; set; }
        public string City { get; set; }
        public House(int length, int height, string city)
        {
            Length = length;
            Height = height;
            City = city;
        }
        public override string ToString()
        {
            return $"House in {City} has {Length} length and {Height} height";
        }
        public override int GetHashCode()
        {
            int hash = 17 ;
            hash = hash * 23 + Length.GetHashCode();
            hash = hash * 23 + Height.GetHashCode();
            hash = hash * 23 + City.GetHashCode();
            return hash;
        }
    }
    readonly struct Car
    {
        public int Length {  get; }
        public int Height { get; }
        public string Brand { get; }
        public Car(int length, int height, string brand)
        {
            Length = length;
            Height = height;
            Brand = brand;
        }
        public override string ToString()
        {
            return $"{Brand} car has {Length} length and {Height} height";
        }
    }
    static void Main(string[] args)
    {
        Car c1 = new Car(700, 300, "BMW");
        Console.WriteLine(c1.GetHashCode().ToString());
        Car c2 = new Car(700, 300, "BMW");
        Console.WriteLine(c2.GetHashCode().ToString());

        House h1 = new House(3000, 1000, "London");
        House h2 = new House(3000, 1000, "London");
        Console.WriteLine(h1.GetHashCode().ToString());
        Console.WriteLine(h2);
        Console.WriteLine(h2.GetHashCode().ToString());
        h2.Length = 245;
        h2.City = "Paris";
        Console.WriteLine(h2);
        Console.WriteLine(h2.GetHashCode().ToString());
        Console.WriteLine(h1.Equals(h2));
        House h3 = new House(3000, 1000, "Paris");
        Console.WriteLine(h3.GetHashCode().ToString());
        House h4 = new House(3000, 100, "Berlin");
        Console.WriteLine(h4.GetHashCode().ToString());
    }
}