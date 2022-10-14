using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;


namespace DZ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<int, string> students = new Dictionary<int, string>()
            //{
            //    { 201, "Черный матрос" },
            //    { 214, "Красный ключ" },
            //    { 2042, "Чокнутый телевизор" },
            //    { 145, "Перевернутый попугай" },
            //    { 234, "Чокнутый Дагестанец" },
            //    { 522, "Вкинутый овощ" },
            //    { 325, "Заброшенный детский сад" },
            //    { 123, "Петух из провинции" },
            //    { -100, "Опасный Тумаков" },
            //    { 23, "Здоровый Карчевский" },
            //    { 125, "телефон из трущеб" },
            //};
            //Console.Write("Задание 1\nВведите одну из трех команд" +
            //    "\n'Новый студент'\n'Удалить'\n'Сортировать'\n"); 
            //string word = Console.ReadLine();

            //switch (word.ToUpper())
            //{
            //    case "НОВЫЙ СТУДЕНТ":
            //        Console.WriteLine("Введите информацию о нем:");
            //        NewStud(ref students); Dict(ref students);
            //        break;
            //    case "УДАЛИТЬ":
            //        Console.WriteLine("Выберите студента которого хотите удалить");
            //        Del(ref students); Dict(ref students);
            //        break;
            //    case "СОРТИРОВАТЬ":
            //        Sortt(ref students);
            //        break;
            //    default:
            //        Console.WriteLine("Попробуй еще раз"); Environment.Exit(100);
            //        break;


            //}




            //Console.Write("Задание 2\n");
            //int cnt = 10;
            //var beerBav = new int[cnt];
            //var beerScan = new int[cnt];
            //Beer(ref beerBav, ref beerScan, ref cnt);


            //Console.Write("Задание 3\nПервое окно - отопление\nВторое окно - оплата\nТретье окно - другое" +
            //    "\nВо всех окнах очереди из 10 человек\n\n");
            //Citizen ildar = new Citizen("ildar", 800, 2, "оплата", 10, 1);
            //ildar.Print();

            //Console.WriteLine("\nСоздайте своего жителя\nВведите имя:");
            //string name = Console.ReadLine();
            //Console.WriteLine("Кратко опишите проблему");
            //string problem = Console.ReadLine();
            //Console.WriteLine("Темперамент(10-скандалист, 0-паинька)");
            //int temp = int.Parse(Console.ReadLine());
            //Console.WriteLine("Ум(1-умный,0-тупой)");
            //int brain = int.Parse(Console.ReadLine());
            //int roomproblem;
            //Raspr(name,problem,temp,brain,out roomproblem);


            Console.WriteLine("Задание 4");
            Console.WriteLine("Задание 4, обход графа в ширину");
            Random rand = new Random();
            Queue<int> NomersVersh = new Queue<int>();
            Console.Write("Введите количество вершин: ");
            int CountVersh = int.Parse(Console.ReadLine()) - 1;
            if (CountVersh >= 3)
            {
                bool[] UsedVersh = new bool[CountVersh + 1];
                int[][] SmezhVersh = new int[CountVersh + 1][];

                for (int i = 0; i < CountVersh + 1; i++)
                {
                    SmezhVersh[i] = new int[CountVersh + 1];
                    Console.Write($"\n{i + 1} вершина - [");
                    for (int j = 0; j < CountVersh + 1; j++)
                    {
                        SmezhVersh[i][j] = rand.Next(0, 2);
                    }
                    SmezhVersh[i][i] = 0;
                    foreach (var item in SmezhVersh[i])
                    {
                        Console.Write($" {item}");
                    }
                    Console.Write("]\n");
                }
                UsedVersh[CountVersh] = true;     //информация о том, посещали мы вершину или нет 
                NomersVersh.Enqueue(CountVersh);
                Console.WriteLine("Начинаем обход с {0} вершины", CountVersh + 1);
                while (NomersVersh.Count != 0)
                {
                    CountVersh = NomersVersh.Peek();
                    NomersVersh.Dequeue();
                    Console.WriteLine("Перешли к узлу {0}", CountVersh + 1);

                    for (int i = 0; i < SmezhVersh.Length; i++)
                    {
                        if (Convert.ToBoolean(SmezhVersh[CountVersh][i]))
                        {
                            int v = i;
                            if (!UsedVersh[v])
                            {
                                UsedVersh[v] = true;
                                NomersVersh.Enqueue(v);
                                Console.WriteLine("Добавили в очередь узел {0}", v + 1);
                            }
                        }



                    }
                }

            }
            



            Console.Read();

        }
        static void Raspr(string name, string problem, int temp, int brain,out int roomproblem) // Задание 3
        {
            var str = new List<string>();
            var mass = problem.Split();
            int cnt = 3;
            Random random = new Random();
            
            foreach (var q in mass)
            {
                
                if (Convert.ToString(q).ToUpper() == "ОПЛАТА")
                {                   
                    Console.WriteLine("Вам во второе окно");
                    cnt = 2;
                    break;
                }
                else if (Convert.ToString(q).ToUpper() == "ПОДКЛЮЧЕНИЕ")
                {
                    Console.WriteLine("Вам в первое окно");
                    cnt = 1;
                    break;
                }
            }
            if (cnt == 3)
            {
                Console.WriteLine("Вам в третье окно");
            }
            roomproblem = cnt;
            Console.WriteLine("Очереди по 10 человек");
            int turn = 10;
            if (temp >= 5)
            {
                Console.WriteLine("Введите количество людей которых обгонит человек");
                int people = int.Parse(Console.ReadLine());
                if (people > 10 && people < 0)
                {
                    Console.WriteLine("Читать научись");
                }
                else
                {
                    if (brain == 0)
                    {
                        int rooms = random.Next(1, 3);
                        while (roomproblem == rooms)
                        {
                            rooms = random.Next(1, 3);
                        }
                        Console.WriteLine($"{name} обогнал {people} человек " +
                            $"поэтому он {10 - people} в очереди, но" +
                            $"{name} тупой как пробка и встал на {rooms} окно");
                    }
                    else
                    {
                        Console.WriteLine($"{name} обогнал {people} человек " +
                            $"поэтому он {10 - people} в очереди");
                    }
                }
            }
            else
            {
                if (brain == 0)
                {
                    int rooms = random.Next(1, 3);
                    while (roomproblem == rooms)
                    {
                        rooms = random.Next(1, 3);
                    }
                    Console.WriteLine($"{name} паинька, но такой тупой, что встал на {rooms} окно");
                }
                else
                {
                    Console.WriteLine($"{name} паинька, но дохера философ, поэтому встал на {roomproblem} окно");
                }
            }
            
        }
        struct Citizen 
        {
            public string name;
            public int room;
            public int roomproblem;
            public string problem;
            public int temperament;
            public int brain;

            public Citizen(string name, int room, int roomproblem, string problem, int temperament, int brain)
            {
                this.name = name;
                this.room = room;  
                this.roomproblem = roomproblem;
                this.problem = problem;
                this.temperament = temperament;
                this.brain = brain;
            }
            
            public void Print()
            {
                Console.WriteLine($"Имя {name}\nНомер паспорта {room}\n" +
                    $"Номер проблемы {roomproblem}\nПроблема {problem}" +
                    $"Темперамент {temperament}\nУм {brain}");
            }
                
        } // Задание 3

        static void Beer(ref int[] a, ref int[] b, ref int cnt) // Задание 2
        {
            Console.WriteLine("Заполните цифрами массив первой команды");
            for (int i = 0; i < cnt; i++)
            {
                try
                {
                    a[i] = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ты ошибся, попробуй еще раз"); Beer(ref a, ref b, ref cnt);
                }
                
            }
            Console.WriteLine("Заполните цифрами массив второй команды");
            for (int i = 0; i < cnt; i++)
            {
                try
                {

                    b[i] = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ты ошибся, попробуй еще раз"); Beer(ref a, ref b, ref cnt);
                }
            }
            int cnt1 = 0;
            foreach (var i in a)
            {
                if (i == 5)
                {
                    cnt1 += 1;
                }
            }
            int cnt2 = 0;
            foreach (var i in a)
            {
                if (i == 5)
                {
                    cnt2 += 1;
                }
            }
            if (cnt2 == cnt1)
            {
                Console.WriteLine("Drinks All Round! Free Beers on Bjorg!");
            }
            else
            {
                Console.WriteLine("Ой, Бьорг - пончик! Ни для кого пива!");
            }
        } // Задание 2
        static void Sortt(ref Dictionary<int, string> a) //Задание 1
        {
            Dictionary<int, string> s = new Dictionary<int,string>();
            List<int> ints = new List<int>();
            foreach (var keys in a)
            {
                ints.Add(keys.Key);
            }
            ints.Sort();
            
            foreach (var key in ints)
            {
                
                s.Add(key, a[key]);
                
            }
            Dict(ref s);
        }
        static void Dict(ref Dictionary<int, string> a) //Метод проверки
        {
            foreach (var person in a)
            {
                Console.WriteLine($"{person.Key}  {person.Value}");
            }
        }
        static void Del(ref Dictionary<int, string> a)
        {
            foreach (var person in a)
            {
                Console.WriteLine($"{person.Key}  {person.Value}");
            }
            Console.WriteLine("Введи балл студента студента:\n");
            var key = int.Parse(Console.ReadLine());
            try
            {
                a.Remove(key);
            }
            catch
            {
                Console.WriteLine("Попробуй еще раз");
                Del(ref a);
            }
        }
        static void NewStud(ref Dictionary<int, string> a)
        {
            try
            {
                Console.WriteLine("Введите его имя");
                var name = Console.ReadLine();
                Console.WriteLine("Введите его фамилию");
                var firstname = Console.ReadLine();
                Console.WriteLine("На сколько баллов он сдал егэ?");
                var ball = int.Parse(Console.ReadLine());
                var namefirstname = name + " " + firstname;
                a.Add(ball, namefirstname);    
            }
            catch
            {
                Console.WriteLine("Внимательно прочитай требования");
                NewStud(ref a);
            }

        }
        


        struct Student
        {
            public string firstname;
            public string name;
            public DateTime data;
            public string ekz;
            public int ball;

            public Student(string firstname, string name, DateTime data, string ekz, int ball)
            {
                this.firstname = firstname;
                this.name = name;
                this.data = data;
                this.ekz = ekz;
                this.ball = ball;
            }
            

        } //Задание 1
        static void CheckList(List<int> a) //Метод для проверок
        {
            foreach (var i in a)
            {
                Console.WriteLine(i);
            }
        }
        static void CheckMass(string[] a)
        {
            foreach (var i in a)
            {
                Console.WriteLine(i);
            }
        }
    }
}
