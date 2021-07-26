using System;
using System.Collections.Generic;
using System.Linq;

//Очередь
//Задание 1.
//Заполнить очередь случайными целыми числами и отсортировать её по убыванию.
//Задание 2
//Дана очередь из целых чисел, заданных случайным образом.Оставить в очереди только двухзначные числа, все остальные удалить.
//Задание 3
//Дана очередь из целых чисел.Удалить из нее числа кратные заданному с клавиатуры числу.

namespace LB_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();

            Console.WriteLine("1 задание\n");
            //Заполнить очередь случайными целыми числами и отсортировать её по убыванию. 
            var queue_1 = new Queue<int>();
            for (var i = 0; i < 10; i++)
            {
                queue_1.Enqueue(rnd.Next(0, 100));
            }
            Console.WriteLine("Изначальная очередь");
            foreach(var item in queue_1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------");

            Queue<int> queue_sort = new Queue<int>(queue_1.OrderByDescending(z => z));

            Console.WriteLine("Очередь после изменения");
            foreach (var item in queue_sort)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine();
            Console.WriteLine("2 задание\n");
            //Дана очередь из целых чисел, заданных случайным образом. Оставить в очереди только двухзначные числа, все остальные удалить. 
            var queue_2 = new Queue<int>();
            for (var i = 0; i < 10; i++)
            {
                queue_2.Enqueue(rnd.Next(0, 150));
            }
            Console.WriteLine("Изначальная очередь");
            foreach (var item in queue_2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------");

            var queue_result = new Queue<int>();
            while(queue_2.Count != 0)
            {
                var temp = queue_2.Dequeue();
                if(temp / 100 == 0 && temp / 10 != 0)
                {
                    queue_result.Enqueue(temp);
                }
            }

            Console.WriteLine("Очередь после изменения");
            foreach (var item in queue_result)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine();
            Console.WriteLine("3 задание\n");
            //Дана очередь из целых чисел. Удалить из нее числа кратные заданному с клавиатуры числу.
            Console.Write("Введите число = "); 
            int number = Convert.ToInt32(Console.ReadLine());
            var queue_3 = new Queue<int>();
            for (var i = 0; i < 10; i++)
            {
                queue_3.Enqueue(rnd.Next(0, 100));
            }
            Console.WriteLine("Изначальная очередь");
            foreach (var item in queue_3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------");

            var queue_res = new Queue<int>();
            while (queue_3.Count != 0)
            {
                var temp = queue_3.Dequeue();
                if (temp % number != 0)
                {
                    queue_res.Enqueue(temp);
                }
            }

            Console.WriteLine("Очередь после изменения");
            foreach (var item in queue_res)
            {
                Console.WriteLine(item);
            }
        }
    }
}
