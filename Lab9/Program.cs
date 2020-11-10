using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab9
{

    class Director
    {
        public delegate void DirectorHandler(string message);
        public event DirectorHandler EventUp;
        public event DirectorHandler EventFine;

        public string Name { get; private set; }
        public int Money { get; private set; }
        public int Rang { get; private set; }


        public Director(string name, int money, int rang)
        {
            Name = name;
            Money = money;
            Rang = rang;
        }

        public void DoUp()
        {
            if (Rang > 1)
            {
                Rang -= 1;
                Money += 10;
                EventUp?.Invoke($"{Name} получил {Rang} ранг и 10 денег");   // Вызов события 
                if (Rang == 1) Console.WriteLine($"{Name} получил максимальный {Rang} ранг!");
            }
            else
            {
                Console.WriteLine($"{Rang} ранг уже максимальный!");
            }

        }
        public void DoFine()
        {

            if (Money > 0)
            {
                Money -= 5;
                EventFine?.Invoke($"{Name} оштрафован на {5}");   // Вызов события 
                if (Money <= 0)
                {
                    Money = 0;
                    Console.WriteLine($"У {Name} нету больше денег!");
                }
                Console.WriteLine($"Теперь {Name} имеет {Money} денег");
            }
            else
            {
                Console.WriteLine($"{Name} не имеет денег!");
            }


        }


    }


    class Program
    {
        delegate string ShowMethods(string str);
        static void Main(string[] args)
        {

            Console.WriteLine($"1 задание\n");
            Director stud = new Director("Student Grisha", 50, 10);
            stud.EventUp += message => Console.WriteLine(message);
            Director tokar = new Director("Tokar Vasya", 15, 5);
            tokar.EventUp += message => Console.WriteLine(message);
            tokar.EventFine += message => Console.WriteLine(message);
            Director slesar = new Director("Slesar Petya", 15, 5);
            slesar.EventUp += message => Console.WriteLine(message);
            slesar.EventFine += message => Console.WriteLine(message);

            stud.DoUp();
            tokar.DoUp();
            stud.DoUp();
            tokar.DoFine();
            stud.DoUp();
            stud.DoUp();
            slesar.DoUp();
            stud.DoUp();
            tokar.DoFine();
            stud.DoUp();
            slesar.DoUp();
            tokar.DoFine();
            stud.DoUp();
            tokar.DoFine();
            slesar.DoUp();
            stud.DoUp();
            tokar.DoFine();
            stud.DoUp();
            slesar.DoUp();
            slesar.DoFine();
            Console.ReadLine();
            Console.Clear();



            Console.WriteLine($"2 задание\n");
            Console.Write($"Введите строку: ");
            string str = Console.ReadLine();

            ShowMethods meth;
            meth = DeletePunctuationMarks;
            meth += DeleteChars;
            meth += AddChars;
            meth += ToUpperCase;
            meth += DeleteSpaces;
            meth(str);

        }
        public static string DeletePunctuationMarks(string str)
        {
            char[] pattern = new char[6] { '.', ',', ':', ';', '?', '!' };
            char[] strArray = str.ToCharArray();
            string outArray = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                if (!pattern.Contains(strArray[i])) outArray += strArray[i];
            }
            Console.WriteLine($"Результат: {outArray}");
            return outArray;
        }

        public static string DeleteChars(string str)
        {
            Console.WriteLine($"Введите то кол-во символов которое вы хотите удалить");
            int numberOfChars = Int32.Parse(Console.ReadLine());
            char[] strArray = str.ToCharArray();
            string outArray = "";
            for (int i = 0; i < strArray.Length - numberOfChars; i++)
            {
                outArray += strArray[i];
            }
            Console.WriteLine($"Результат: {outArray}");
            return outArray;
        }

        public static string AddChars(string str)
        {
            Console.WriteLine($"Введите символ");
            char insertChar = Char.Parse(Console.ReadLine());
            str += insertChar;
            Console.WriteLine($"Результат: {str}");
            return str;
        }

        public static string ToUpperCase(string str)
        {
            Console.WriteLine($"Результат: {str.ToUpper()}");
            return str.ToUpper();
        }

        public static string DeleteSpaces(string str)
        {
            char pattern = ' ';
            char[] strArray = str.ToCharArray();
            string outArray = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i] != pattern) outArray += strArray[i];
            }
            Console.WriteLine($"Результат: {outArray}");
            return outArray;
        }
    }
}
