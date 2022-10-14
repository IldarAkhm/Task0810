using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TuMak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Задание 1");
            //string file = @"C:\\Users\\ahmet\\source\\repos\\DZ\\TuMak\\TextFile1.txt";
            //List<string> list = new List<string>();
            //using (StreamReader sr = new StreamReader(file, Encoding.UTF8))
            //{
            //    string line;
            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        foreach (var i in line)
            //        {
            //            list.Add(Convert.ToString(i));
            //        }
            //    }
            //}

            //GS(list);

            //Console.WriteLine("Задание 2");

            //LinkedList<LinkedList<int>> ints = new LinkedList<LinkedList<int>>();
            //Console.WriteLine("Сколько будет строк в матрице?");
            //int cnt = int.Parse(Console.ReadLine());
            //Console.WriteLine("Сколько столбцов будет в матрице?");
            //int st = int.Parse(Console.ReadLine());
            //for (int i = 0; i < cnt; i++)
            //{
            //    LinkedList<int> l = new LinkedList<int>();
            //    for (int j = 0; j < st; j++)
            //    {
            //        Console.WriteLine($"Укажи значения {i+1} строки");
            //        int number = int.Parse(Console.ReadLine());
            //        l.AddLast(number);
            //        if (j + 1 == st)
            //        {
            //            ints.AddLast(l);
            //        }
            //    }
            //}
            //LinkedList<LinkedList<int>> ints1 = new LinkedList<LinkedList<int>>();
            //Console.WriteLine("Сколько будет строк в матрице?");
            //int cnt1 = int.Parse(Console.ReadLine());
            //Console.WriteLine("Сколько столбцов будет в матрице?");
            //int st1 = int.Parse(Console.ReadLine());
            //for (int i = 0; i < cnt1; i++)
            //{
            //    LinkedList<int> l1 = new LinkedList<int>();
            //    for (int j = 0; j < st1; j++)
            //    {
            //        Console.WriteLine($"Укажи значения {i + 1} строки");
            //        int number = int.Parse(Console.ReadLine());
            //        l1.AddLast(number);
            //        if (j + 1 == st1)
            //        {
            //            ints1.AddLast(l1);
            //        }
            //    }
            //}
            //MultMatric(ints, ints1);


            Console.Write("Задание 3\n");
            int[,] temperature = new int[12, 30];
            Random random = new Random();
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                for(int j = 0; j < temperature.GetLength(1); j++)
                {
                    temperature[i, j] = Convert.ToInt32(random.Next(-30,30));
                }
            }


            
            
            Sr(temperature);



            Console.Read();
            
        }
        static void Sr(int[,] temperature)
        {
            Dictionary<int, int[]> b = new Dictionary<int, int[]>();
            double sr = 0;
            var newtemp = new List<double>();
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                var cntint = new int[30];
                int cnt = 0;
                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    cnt += temperature[i, j];
                    cntint[j] = temperature[i, j];
                    if (j + 1 == temperature.GetLength(1))
                    {
                        sr = ((double)cnt / 30d);
                        newtemp.Add(sr);
                        b.Add(i, cntint);
                    }
                    
                }
            }
            
            newtemp.Sort();
            CheckMass1(newtemp);
            Dict(b);
        }
        static void Dict(Dictionary<int, int[]> a) //Метод проверки
        {
            foreach (var person in a)
            {
                Console.Write($"{person.Key} ");
                foreach (var pr in person.Value)
                {
                    Console.Write($"{pr} ");
                }
                Console.Write("\n");
                
            }
        }

        static void MultMatric(LinkedList<LinkedList<int>> a, LinkedList<LinkedList<int>> b)
        {

            int i = a.Count;
            int j = b.Count;
            var newlist = new List<List<int>>();
            var list = Enumerable.ToList(a);
            var blist = Enumerable.ToList(b);
            for (int q = 0, r = 0; q < i; q++,r++)
            {
                var lst = Enumerable.ToList(list[q]);
                var blst = Enumerable.ToList(list[r]);
                
                if (lst.Count > blst.Count)
                {
                    var newl = new List<int>();
                    for (int q1 = 0, r1 = 0; q1 < lst.Count; q1++,r1++)
                    {
                        try
                        {
                            var xer = lst[q1] * blst[q1];
                            newl.Add(xer);
                        }
                        catch  
                        {
                            var xer = 0;
                            newl.Add(xer);
                        }
                        
                    }
                    newlist.Add(newl);
                }
                else if (lst.Count < blst.Count)
                {
                    var newl = new List<int>();
                    for (int q1 = 0, r1 = 0; q1 < blst.Count; q1++, r1++)
                    {
                        try
                        {
                            var xer = lst[q1] * blst[q1];
                            newl.Add(xer);
                        }
                        catch
                        {
                            var xer = 0;
                            newl.Add(xer);
                        }

                    }
                    newlist.Add(newl);
                }
                else
                {
                    var newl = new List<int>();
                    for (int q1 = 0, r1 = 0; q1 < blst.Count; q1++, r1++)
                    {
                        try
                        {
                            var xer = lst[q1] * blst[q1];
                            newl.Add(xer);
                        }
                        catch
                        {
                            var xer = 0;
                            newl.Add(xer);
                        }

                    }
                    newlist.Add(newl);
                }
            }
            CheckListList(newlist);
        }
        static void CheckLinkedList(LinkedList<LinkedList<int>> a) // Проверка двусвязных списков
        {
            foreach (var i in a)
            {
                foreach (var j in i)
                {
                    Console.Write(j);
                }
                Console.Write("\n");
            }
            
        }
        static void GS(List<string> a)
        {
            int Scnt = 0;
            int Gcnt = 0;
            var g = "ауоыэяюёиеeyuioa";
            var s = "цкншщзхфвпрлджчсмтбqwrtpasdfghjklzxcvbnm";
            
            foreach (var i in a)
            {
                i.ToLower();
                if (g.Contains(i))
                {
                    Gcnt++;
                }
                else if (s.Contains(i))
                {
                    Scnt++;
                }
            }
            Console.WriteLine($"Гласных букв: {Gcnt}\nСогласных: {Scnt}");
        }
        static void CheckListList(List<List<int>> a)  // Метод Проверки
        {
            foreach (var i in a)
            {
                foreach (var j in i)
                {
                    Console.Write($"{j} ");
                }
                Console.Write("\n");
            }
        }
        static void CheckList(List<string> a) // Метод Проверки
        {
            foreach (var i in a)
            {
                Console.WriteLine(i);
            }
        }
        static void CheckMass(int[,] a) // Метод проверки
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.WriteLine($"{i + 1} {a[i,j]}");
                }
            }
        }
        static void CheckMass1(List<double> a)
        {
            foreach (var i in a)
            {
                Console.WriteLine(i);
            }    
        }
    }
}
