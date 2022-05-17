//Створити суперклас Судно і підкласи Військовий корабель, Грузовий корабель,
//Фрегат, Паром. В конструкторі задати грузопідйомність кожного судна. Вивести
//кількість гармат у тих кораблів, в яких вони можуть бути. Вивести максимальну
//кількість пасажирів в кожному кораблі.
using System;
namespace laba_4
{
	abstract class Ship
	{
		public abstract int numb_gun { get; }
		public abstract int numb_pas { get; }
		public int Capacity;
		public string Name;
		public Ship(int capacity, string name)
		{
			Capacity = capacity;
			Name = name;
		}
		public void Show_Inf()
		{
			Console.WriteLine($"\nType: {Name}\nCapacity: {Capacity}kg\nPassangers:" +
                $" {numb_pas}");
			if (numb_gun!=0)
            {
				Console.WriteLine($"Gans: {numb_gun}");
            }
		}
	}

	class Warship : Ship
	{
		public Warship(int capacity, string name) : base(capacity, name) { }
		public override int numb_gun { get { return 10; } }
		public override int numb_pas { get { return 200; } }
	}
	class Cargo_ship : Ship
	{
		public Cargo_ship(int capacity, string name) : base(capacity, name) { }
		public override int numb_gun { get { return 0; } }
		public override int numb_pas { get { return 10; } }
	}
	class Fregate : Ship
	{
		public Fregate(int capacity, string name) : base(capacity, name) { }
		public override int numb_gun { get { return 5; } }
		public override int numb_pas { get { return 100; } }
	}
	class Ferry : Ship
	{
		public Ferry(int capacity, string name) : base(capacity, name) { }
		public override int numb_gun { get { return 0; } }
		public override int numb_pas { get { return 1000; } }
	}

	class Program
	{
		static void Main(string[] args)
		{
			Ship[] ships = { new Warship(50000, "Warship"), new Cargo_ship(100000,"Cargo ship"),
				new Fregate(20000, "Fregate"), new Ferry(10000, "Ferry") };
			foreach (var item in ships)
			{
				item.Show_Inf();
			}

			Console.ReadKey();

		}
	}
}

