using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            // первое задание
            Console.WriteLine("Первое задание");
            Arrs arrs = new Arrs();
            int[] A = new int[5];
            Arrs.CreateOneDimAr(A);

            Arrs.PrintAnyArr("A", A);

            Console.WriteLine();

            int[,] arr2 = { { 1, 3 }, { 4, 5 } };

            Arrs.PrintAnyArr("arr2", arr2);
            // второе задание
            Arrs.PrintAnyArr2(arr2);
            Console.WriteLine();
            Arrs.PrintAnyArr2(A);
            int[] B = new int[5];
            Arrs.CreateOneDimAr(B);
            Console.WriteLine();
            Arrs.AllProcess(B);
            //третье задание
            int[] arr3 = new int[5] { 1, 2, 0, 7, 9 };
            int[,] arr4 = new int[2, 2] { { 2, 3 }, { 5, 6 } };
            Console.WriteLine(arr3.Length); // выводит общее число элементов
            Console.WriteLine(arr4.GetLength(0)); // считывает кол-во элементов в двумерном массиве по главному индексу
            //Console.WriteLine(arr3.GetLength(1));

            Arrs.PrintObjectArray(arr3);

            // четвертое задание
            Console.WriteLine();
            Student[] arr = new Student[3];
            Student.InitAr(arr);
            arr[0].SetValue("Ivan");
            arr[1].SetValue("Kirill");
            arr[2].SetValue("Denis");
            Student.Print(arr);
            //пятое задание

            //   Arrs.PrintArObj("A", A); - невозможно тк int[]  и object[] ( Int не ссылочный тип)
            string[] arr5 = new string[3] { "I", "like", "there" }; // string ссылочный тип
            Arrs.PrintArObj("strArr", arr5);
            //шестое задание
            Task6 first = new Task6();
            Task6 second = new Task6();

            first.Length = 10;
            first.Start = 1;
            first.End = 12;

            second.Length = 10;
            second.Start = -3;
            second.End = 9;

            int[] One = new int[first.Length];
            int[] Two = new int[second.Length];

            //вывод на экран всего массива
            first.Print(One, first.Length, first.Start, first.End);
            second.Print(Two, second.Length, second.Start, second.End);

            //обращение к отдельному элементу массива с контролем выхода за пределы массива;
            try
            {
                Console.Write("индекс элемента = ");
                int i = Int32.Parse(Console.ReadLine());
                Console.WriteLine("One[{0}]={1}", i, One[i]);
            }
            catch { Console.WriteLine("индекс элемента выходит за рамки массива"); }

            // выполнение операций поэлементного сложения
            Console.WriteLine();
            first.Sum(One, Two);
            Console.WriteLine();
            // выполнение операций поэлементного вычитания 
            first.Sustract(One, Two);
            Console.WriteLine();
            //  выполнение операций умножения и деления всех элементов массива на скаляр;
            Console.WriteLine();
            first.Mult(One, 3);
            Console.WriteLine();
            first.Del(One, 2);
            Console.WriteLine();
        }

        class Arrs
        {
            private static Random rnd;

            public Arrs()
            {
                rnd = new Random();
            }
            public static void PrintArObj(string name, Object[] Arr)
            {
                foreach (var item in Arr)
                {
                    Console.WriteLine($"{name} - {item}");
                }
            }
            public static void PrintAnyArr(string name, Array arr)
            {
                Console.WriteLine(name);
                int search = arr.Rank;
                switch (search)
                {
                    case 1:
                        for (int i = 0; i < arr.Length; i++)
                        {
                            Console.WriteLine("elem[{0}] = {1}", i, arr.GetValue(i));
                        }
                        break;
                    case 2:
                        int first = arr.GetLength(0);
                        int second = arr.GetLength(1);
                        for (int i = 0; i < first; i++)
                        {
                            for (int j = 0; j < second; j++)
                            {
                                Console.Write("{0} ", arr.GetValue(i, j));
                            }
                            Console.WriteLine();
                        }
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }

            }
            public static void PrintAnyArr2(Array arr)
            {
                int count = 0;
                foreach (int element in arr)
                {

                    Console.Write($"Element #{count}: {element} ");
                    count++;
                }
            }
            public static void CreateOneDimAr(int[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = rnd.Next(1, 11);
                }
            }
            public static void AllProcess(int[] arr)
            {
                foreach (var item in arr)
                {
                    Console.Write("{0}  ", item);
                }
                Console.WriteLine();
                int[] C = new int[5];
                Console.WriteLine("Копирование");
                Array.Copy(arr, C, 5);
                foreach (var item in C)
                {
                    Console.Write("{0}  ", item);
                }
                Console.WriteLine();
                Console.WriteLine("Первый и последний");
                Console.WriteLine(Array.IndexOf(arr, 1));
                Console.WriteLine(Array.LastIndexOf(arr, 2));
                Console.WriteLine("Перевернуть");
                Array.Reverse(arr);
                foreach (var item in arr)
                {
                    Console.Write("{0}  ", item);
                }
                Console.WriteLine();
                Console.WriteLine("Сортировка");
                Array.Sort(arr);
                foreach (var item in arr)
                {
                    Console.Write("{0}  ", item);
                }
                Console.WriteLine();
                Console.WriteLine("Двоичный поиск");
                Console.WriteLine(Array.BinarySearch(arr, 1));

            }
            public static void PrintObjectArray(Object param)
            {
                Array arr = param as Array;
                var count = 0;
                foreach (var elements in arr)
                {
                    Console.Write("{0} = {1}; ", count, elements);
                    count++;
                }
            }
            public static void CreateAr2(int[,] arr)
            {
                int first = arr.GetLength(0);
                int second = arr.GetLength(1);
                for (int i = 0; i < first; i++)
                {
                    for (int j = 0; j < second; j++)
                    {
                        arr[i, j] = rnd.Next(1, 11);
                    }
                }
            }

            public static void PrintArr1(string name, int[] arr)
            {
                Console.WriteLine(name);
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine("elem[{0}] = {1}", i, arr[i]);
                }
            }

            public static void PrintArr2(string name, int[,] arr)
            {
                int first = arr.GetLength(0);
                int second = arr.GetLength(1);
                Console.WriteLine(name);
                for (int i = 0; i < first; i++)
                {
                    for (int j = 0; j < second; j++)
                    {
                        Console.Write("{0} ", arr[i, j]);
                    }
                    Console.WriteLine();
                }
            }

        }
        class Student
        {
            private string Name;
            private int Sumb;
            public static Random Rnd = new Random();

            public void SetValue(string name)
            {
                Name = name;
                Sumb = Rnd.Next(1, 6);
            }

            public static void Print(Student[] Stud)
            {
                foreach (var item in Stud)
                {
                    Console.WriteLine("{0} = {1}", item.Name, item.Sumb);
                }
                
            }
        

       
            public static Student[] InitAr(Student[] Stud)
            {
                for (int i = 0; i < Stud.Length; i++)
                {
                    Stud[i] = new Student();
                }

                return Stud;
            }


        }
        class Task6
        {
            public int Length;
            public int Start;
            public int End;
            

            public void Print(int[] Arr, int Length, int Start, int End)
            {
                Random R = new Random();
                for (int i = 0; i < Length; i++)
                {
                    Arr[i] = R.Next(Start, End);
                    Console.Write("{0} ", Arr[i]);
                }
                Console.ReadLine();
            }
   
            public void Sum(int[] a, int[] b)
            {

                for (int i = 0; i<Length; i++)
                {

                    Console.Write("{0} ",a[i]+b[i]);
                }
                Console.WriteLine();
            }
            public void Sustract(int[] a, int[] b)
            {
                for (int i = 0; i < Length; i++)
                {

                    Console.Write("{0} ", a[i] - b[i]);
                }
                Console.WriteLine();
            }
            public void Mult(int[] a, int temp)
            {
                for (int i = 0; i < Length; i++)
                {

                    Console.Write("{0} ", a[i] * temp);
                }
                Console.WriteLine();
            }
            public void Del(int[] a, int temp)
            {
                for (int i = 0; i < Length; i++)
                {
                    ;
                    Console.Write("{0} ", a[i] / temp);
                }
                Console.WriteLine();
            }
        }
    }
 }

