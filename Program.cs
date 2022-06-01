//Створити суперклас Судно і підкласи Військовий корабель, Грузовий корабель,
//Фрегат, Паром. В конструкторі задати грузопідйомність кожного судна. Вивести
//кількість гармат у тих кораблів, в яких вони можуть бути. Вивести максимальну
//кількість пасажирів в кожному кораблі.

//Переробити структуру згідно завдання, додати клас порт у ньому список кораблів,
//методи додати корабель, загальну кількість гармат у кораблях, підрахувати
//загальну кількість пасажирів та знайти кораблі з максимальною кількістю
//пасажирів та максимальною кількістю гармат відповідно
using System;

namespace laba_4
{
	abstract class Ship
	{
		public int numb_pas;
		public int Capacity;
		public string Name;
		public string Type;
		public Ship(int capacity,string type,int passangers, string name)
		{
			Capacity = capacity;
			Name = name;
			Type = type;
			numb_pas = passangers;
		}
	}
	class Ports
    {
		public static List<Ship> port = new List<Ship>();
		public static List<Warship> warships = new List<Warship>();
		public void ship(Ship[] ships)
        {
			foreach(var it in ships)
            {
				Console.WriteLine($"\nName: {it.Name}\nType: {it.Type}\nCapacity: {it.Capacity} kg\nPassangers: {it.numb_pas} person");
				port.Add(it);
				if (it.Type=="Warship")
                {
					warships.Add((Warship)it);
                }
				
            }

        }
		public void list_guns()
        {
			Console.WriteLine("\nList(guns):");
			foreach(var it in warships)
            {
				Console.WriteLine($"{it.Name} - {it.numb_gun};");
            }
        }
		public void all_guns()
        {
			int guns = 0;
			foreach (var it in warships)
			{
				guns += it.numb_gun;
			}
			Console.WriteLine("\nCurrent numb. of guns: " + guns);
		}
		public void all_pass()
        {
			int pass = 0;
			foreach (var it in port)
            {
				pass += it.numb_pas;
            }
			Console.WriteLine("\nCurrent numb. of passangers: " +pass);
        }

		public void max_pass()
        {
			int max = 0;
			string name_max="";
			foreach (var it in port)
			{
				if (max < it.numb_pas)
				{
					max = it.numb_pas;
					name_max = it.Name;
				}
			}
			Console.WriteLine("\nMax numb. of passangers: " + max +" in " + name_max);
		}

		public void max_gans()
		{
			int max = 0;
			string name_max = "";
			foreach (var it in warships)
			{
				if (max < it.numb_gun)
				{
					max = it.numb_gun;
					name_max = it.Name;
				}
			}
			Console.WriteLine("\nMax numb. of guns: " + max + " in " + name_max);
		}
	}

	class  Warship : Ship
	{
		public Warship(int capacity,string type,int numb_pas, string name) : base(capacity,type,numb_pas,name) { }
		public virtual int numb_gun { get; }
    }
	class Cargo_ship : Ship
	{
		public Cargo_ship(int capacity, string type, int numb_pas,string name) : base(capacity,type,numb_pas, name) { }
		
	}
	class Fregate : Warship
	{
		static Random rnd = new Random();
		int n;
		public Fregate(int capacity, string type, int numb_pas, string name) : base(capacity,type,numb_pas, name)
		{
			if (name == "Fregate1")
			{ n = 20; }
			else if (name == "Fregate2")
			{ n = 45; }
			else
			{ n = rnd.Next(1, 50); }

		}
		public override int numb_gun { get { return n; } }
		
	}
	class Ferry : Cargo_ship
	{
		public Ferry(int capacity, string type,int numb_pas, string name) : base(capacity,type,numb_pas,name) { }
		
	}

	class Program
	{
		static void Main(string[] args)
		{
			Ports port1 = new Ports();
			Ship[] ships_port1 = { new Fregate(20000,"Warship",10, "Fregate1"),
				new Ferry(100000,"Cargo ship",1000, "Ferry1"), new Fregate(25000,"Warship",15, "Fregate2"),
			new Ferry(500000,"Cargo ship",450, "Ferry2"), new Fregate(35000,"Warship",35, "Fregate3")};
			port1.ship(ships_port1);
			port1.list_guns();
			port1.all_pass();
			port1.max_pass();
			port1.all_guns();
			port1.max_gans();
			Console.ReadKey();

		}
	}
}


