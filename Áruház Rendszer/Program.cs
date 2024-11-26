namespace Áruház_Rendszer
{
	internal class Program
	{
		static string[] termekek = new string[10];
		static int[] termekAr = new int[10];
		static int[] termekMennyiseg = new int[10];

		static List<string> kosar = new List<string>();
		static List<int> kosarMennyiseg = new List<int>();

		static void Main(string[] args)


		{



			bool fut = true;

			while (fut)
			{

				Console.WriteLine("Áruház Rendszer:");
				Console.WriteLine("1. Raktárkészlet kezelése");
				Console.WriteLine("2. Vásárlói kosár kezelése");
				Console.WriteLine("3. Vásárlási művelet szimulálása");
				Console.WriteLine("4. Statisztikák előállítása");
				Console.WriteLine("5. Kilépés");

				int opcio = Convert.ToInt32(Console.ReadLine());

				switch (opcio)
				{
					case 1:
						Console.Clear();
						Console.WriteLine("1. Raktárkészlet frissítése");
						Console.WriteLine("2. Raktárkészlet megtekintése");
						int option3 = Convert.ToInt32(Console.ReadLine());

						switch (option3) 
						{ 
						case 1:
							Console.Clear();
									raktarFrissites();
								break;

						case 2:
							Console.Clear();
							termekMegtekintes();
							break;
						}
						break;

				
					case 2:
						Console.Clear();
						Console.WriteLine("1. Termék hozzáadása a kosárhoz");
						Console.WriteLine("2. Termék eltávolítása a kosárból");
						Console.WriteLine("3. Kosár ürítése");

						int opcio2 = Convert.ToInt32(Console.ReadLine());

						switch (opcio2)
						{
							case 1:
								Console.Clear();
								termekHozzaadas();
								break;
							case 2:
								Console.Clear();
								kosarTorles();
								break;
							case 3:
								Console.Clear();
								kosarUrites();
								break;

						}

						break;

					case 3:
						Console.Clear();
						Vasarlas();
						break;
					case 4:
						Console.Clear();
						break;
					case 5:
						Console.Clear();
						Console.WriteLine("Kilépés...");
						fut = false;
						break;

					default:
						Console.WriteLine("Nincs ilyen opció");
						break;
				}
			}
		}

		static void termekMegtekintes()
		{
			Console.WriteLine("A raktárban lévő termékek:");

			for (int i = 0; i < termekek.Length; i++)
			{
				if (termekek[i] == null)
				{
					Console.WriteLine($"{i + 1} helyen nincsenek termékek");
				}
				else
				{
					Console.WriteLine($"- {termekek[i]}: {termekMennyiseg[i]} db - {termekAr[i]} ft");
				}
			}
		}

		static void raktarFrissites()
		{
			Console.WriteLine("Add meg a termék nevét: ");
			string termek = Console.ReadLine();

			int index = Array.IndexOf(termekek, termek);

			if (index == -1)
			{
				Console.WriteLine("Ez a termek nem szerepel a raktárban, hozzáadjuk! ");

				index = Array.IndexOf(termekek, null);
				if (index == -1)
				{
					Console.WriteLine("Nincs több hely a raktárban");
					return;
				}
			}
				termekek[index] = termek;
				termekMennyiseg[index] = 0;

				Console.WriteLine("Add meg a frissítendő mennyiséget: ");
				int mennyiseg = Convert.ToInt32(Console.ReadLine());
			

				if (mennyiseg < 0)
				{
					Console.WriteLine("A termék mennyisége nem lehet negatív szám");
					return;
				}
				else
				{
					termekMennyiseg[index] += mennyiseg;
					Console.WriteLine("A raktár sikeresen frissítve!");
				}

		}

		static void termekHozzaadas()
			{
				Console.WriteLine("Add meg a termék nevét: ");
				string termek = Console.ReadLine();

				if (termek == null)
				{
					Console.WriteLine("A termék neve nem lehet üres");
				}
				else if (kosar.Contains(termek))
				{
					Console.WriteLine("Ez a termék már benne van a kosaradban");
				}

				Console.WriteLine("Add meg a termék mennyiségét: ");
				int mennyiseg = Convert.ToInt32(Console.ReadLine());

				if (mennyiseg < 0)
				{
					Console.WriteLine("A termék mennyisége nem lehet negatív");
				}

				kosar.Add(termek);
				kosarMennyiseg.Add(mennyiseg);
				int index = Array.IndexOf(termekek, termek);
				termekMennyiseg[index] -= mennyiseg;
				Console.WriteLine("A terméket sikeresen beleraktuk a kosaradba");

			}

			static void kosarTartalma()
			{
				for (int i = 0; i < kosar.Count; i++)
				{
					Console.WriteLine($"{kosar[i]}: {kosarMennyiseg[i]} db");
				}
			}

			static void kosarTorles()
			{
				Console.WriteLine("Add meg a törölni kívánt termék nevét: ");
				string termek = Console.ReadLine();

				if (!kosar.Contains(termek))
				{
					Console.WriteLine("Ez a termék nem szerepel a kosaradban");
				}
				else
				{
					int index = kosar.IndexOf(termek);
					kosar.RemoveAt(index);
					kosarMennyiseg.RemoveAt(index);
					Console.WriteLine("A termék eltávolítva a kosárból");
				}

			}

			static void kosarUrites()
			{
				for (int i = 0; i < kosar.Count; i++)
				{
					string termek = kosar[i];
					int mennyiseg = kosarMennyiseg[i];
					int index = Array.IndexOf(termekek, termek);

					termekMennyiseg[index] += mennyiseg;
				}

				kosar.Clear();
				Console.WriteLine("A kosár üres");
			}

			static void Vasarlas()
			{
				Console.WriteLine("Vásárlás véglegesítése...");

				for (int i = 0; i < kosar.Count; i++)
				{
					string termek = kosar[i];
					int mennyiseg = kosarMennyiseg[i];
					int index = Array.IndexOf(termekek, termek);
					int ar = 0;
					if (index == -1)
					{
						Console.WriteLine($"Nincs ilyen termék a raktárban: {termek} ");
						continue;
					}
					if (termekMennyiseg[index] < mennyiseg)
					{
						Console.WriteLine("Nincs elég termék a raktárban");
					}
					else
					{
						termekMennyiseg[index] -= mennyiseg;
						ar += termekAr[index];
						Console.WriteLine($"Sikeresen megvásárolt: {termek}, {mennyiseg}");
						Console.WriteLine($"Összesen: {ar} ft");
					}

				}

				static int Legdragabb(int[] ar)
				{
					int Legdragabb = termekAr.Max();
					return Legdragabb;
				}

				static int Legolcsobb(int[] ar)
				{
					int legolcsobb = termekAr.Min();
					return legolcsobb;

				}


			}

		}
	}


