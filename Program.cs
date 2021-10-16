using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Обобщённые классы
            Account<int> account1 = new() { Sum = 5000 };
            Account<string> account2 = new() { Sum = 4000 };

            // присвоение значений универсальным параметром (обобщенный тип)
            account1.Id = 2;      
            account2.Id = "4356";

            // Статические поля обобщенных классов
            Account<int>.session = 5436;
            Account<string>.session = "45245";

            // никакой ошибки (можно var)
            int id1 = account1.Id;  
            string id2 = account2.Id;

            // Проверка значений
            Console.WriteLine(id1);
            Console.WriteLine(id2);
            Console.WriteLine(Account<int>.session);      // 5436
            Console.WriteLine(Account<string>.session);   // 45245

            // 2. Использование нескольких универсальных параметров
            Account<int> acc1 = new() { Id = 1857, Sum = 4500 };
            Account<int> acc2 = new() { Id = 3453, Sum = 5000 };

            Transaction<Account<int>, string> transaction1 = new()
            {
                FromAccount = acc1,
                ToAccount = acc2,
                Code = "45478758",
                Sum = 900
            };

            // Проверка значений
            Console.WriteLine(transaction1.FromAccount.Id);     // 1857
            Console.WriteLine(transaction1.FromAccount.Sum);    // 4500
            Console.WriteLine(transaction1.ToAccount.Id);       // 3453
            Console.WriteLine(transaction1.ToAccount.Sum);      // 5000

            // Обобщенные методы
            int x = 7;
            int y = 25;
            Swap(ref x, ref y); 
            Console.WriteLine($"x={x}    y={y}");   // x=25   y=7

            string s1 = "hello";
            string s2 = "bye";
            Swap(ref s1, ref s2); 
            Console.WriteLine($"s1={s1}    s2={s2}"); // s1=bye   s2=hello
        }

        // обобщённый метод
        public static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }
    }

    class Account<T>
    {
        public static T session;

        //T id = default(T);        // default value null or 0
        public T Id { get; set; }
        public int Sum { get; set; }
    }

    class Transaction<U, V>
    {
        public U FromAccount { get; set; }  // с какого счета перевод
        public U ToAccount { get; set; }    // на какой счет перевод
        public V Code { get; set; }         // код операции
        public int Sum { get; set; }        // сумма перевода
    }
}
