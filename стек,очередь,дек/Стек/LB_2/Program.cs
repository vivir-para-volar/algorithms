using System;

//Задание 1.
//1.Сформировать стек из 10 чисел. Найти сумму последних 5 чисел и результат поместить в стек. 
//2.Сформировать стек из 8 чисел. Найти среднее арифметическое второго и третьего чисел. Результат поместить в стек. 
//Задание 2.
//Дан стек, заполненный случайным образом из целых чисел. Поменять в данном стеке содержимое вершины и дна. 
//Задание 3.
//Стек заполнен элементами типа struct с полем year типа int. Записать в стек сначала четные элементы, затем – нечетные. Для решения задачи используйте два дополнительных стека.


namespace LB_2
{
    class Program
    {
        public class Node<T>
        {
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Node<T> Next { get; set; }
        }

        public class NodeStack<T> 
        {
            Node<T> head;
            int count;

            public bool IsEmpty
            {
                get { return count == 0; }
            }
            public int Count
            {
                get { return count; }
            }

            public void Push(T item)
            {
                // увеличиваем стек
                Node<T> node = new Node<T>(item);
                node.Next = head; // переустанавливаем верхушку стека на новый элемент
                head = node;
                count++;
            }
            public T Pop()
            {
                // если стек пуст, выбрасываем исключение
                if (IsEmpty)
                    throw new InvalidOperationException("Стек пуст");
                Node<T> temp = head;
                head = head.Next; // переустанавливаем верхушку стека на следующий элемент
                count--;
                return temp.Data;
            }
            

            public static void Reverse(ref NodeStack<T> stack)
            {
                var newStack = new NodeStack<T>();
                while (!stack.IsEmpty)
                {
                    newStack.Push(stack.Pop());
                }
                stack = newStack;
            }

            public static void Print(ref NodeStack<T> stack)
            {
                var tempStack = new NodeStack<T>();
                Copy(ref stack, ref tempStack);
                Reverse(ref tempStack);
                while (!tempStack.IsEmpty)
                {
                    Console.WriteLine(tempStack.Pop());
                }
            }
            public static void Copy(ref NodeStack<T> which, ref NodeStack<T> where)
            {
                var newStack = new NodeStack<T>();
                while (!which.IsEmpty)
                {
                    var temp = which.Pop();
                    newStack.Push(temp);
                    where.Push(temp);
                }
                Reverse(ref newStack);
                Reverse(ref where);
                which = newStack;
            }
        }


        static void Main(string[] args)
        {
            var rnd = new Random();

            Console.WriteLine("1 задание");
            Console.WriteLine("1 пункт\n");
            //1.Сформировать стек из 10 чисел.Найти сумму последних 5 чисел и результат поместить в стек.
            var stack_10 = new NodeStack<int>();
            for(var i = 0; i < 10; i++)
            {
                stack_10.Push(rnd.Next(0, 100));
            }
            Console.WriteLine("Изначальный стек");
            NodeStack<int>.Print(ref stack_10);
            Console.WriteLine("----------------------------");

            var tempStack = new NodeStack<int>();
            NodeStack<int>.Copy(ref stack_10, ref tempStack);
            int sum = 0;
            for (var i = 0; i < 5; i++)
            {
                sum += tempStack.Pop();
            }
            stack_10.Push(sum);

            Console.WriteLine("Стек после изменения");
            NodeStack<int>.Print(ref stack_10);


            Console.WriteLine();
            Console.WriteLine("2 пункт\n");
            //2.Сформировать стек из 8 чисел.Найти среднее арифметическое второго и третьего чисел.Результат поместить в стек.
            var stack_8 = new NodeStack<int>();
            for (var i = 0; i < 8; i++)
            {
                stack_8.Push(rnd.Next(0, 100));
            }
            Console.WriteLine("Изначальный стек");
            NodeStack<int>.Print(ref stack_8);
            Console.WriteLine("----------------------------");

            NodeStack<int>.Copy(ref stack_8, ref tempStack);
            NodeStack<int>.Reverse(ref tempStack);
            sum = 0;
            for (var i = 0; i < 3; i++)
            {
                var temp = tempStack.Pop();
                if (i != 0)
                {
                    sum += temp;
                }
            }
            stack_8.Push(sum / 2);

            Console.WriteLine("Стек после изменения");
            NodeStack<int>.Print(ref stack_8);


            Console.WriteLine();
            Console.WriteLine("2 задание\n");
            //Дан стек, заполненный случайным образом из целых чисел.Поменять в данном стеке содержимое вершины и дна. 
            var stack_2 = new NodeStack<int>();
            for (var i = 0; i < 5; i++)
            {
                stack_2.Push(rnd.Next(0, 100));
            }
            Console.WriteLine("Изначальный стек");
            NodeStack<int>.Print(ref stack_2);
            Console.WriteLine("----------------------------");

            var end = stack_2.Pop();
            NodeStack<int>.Reverse(ref stack_2);
            var start = stack_2.Pop();
            stack_2.Push(end);
            NodeStack<int>.Reverse(ref stack_2);
            stack_2.Push(start);

            Console.WriteLine("Стек после изменения");
            NodeStack<int>.Print(ref stack_2);


            Console.WriteLine();
            Console.WriteLine("3 задание\n");
            //Стек заполнен элементами типа struct с полем year типа int. Записать в стек сначала четные элементы, затем – нечетные. Для решения задачи используйте два дополнительных стека.
            var stack_3 = new NodeStack<task_3>();
            task_3 num1; num1.year = 2000; stack_3.Push(num1);
            task_3 num2; num2.year = 2001; stack_3.Push(num2);
            task_3 num3; num3.year = 2002; stack_3.Push(num3);
            task_3 num4; num4.year = 2003; stack_3.Push(num4);
            task_3 num5; num5.year = 2004; stack_3.Push(num5);
            task_3 num6; num6.year = 2005; stack_3.Push(num6);
            task_3 num7; num7.year = 2006; stack_3.Push(num7);
            Console.WriteLine("Изначальный стек");
            NodeStack<task_3>.Print(ref stack_3);
            Console.WriteLine("----------------------------");

            var stack_even = new NodeStack<task_3>();
            var stack_uneven = new NodeStack<task_3>();
            while (!stack_3.IsEmpty)
            {
                var temp = stack_3.Pop();
                if (temp.year % 2 == 0) stack_even.Push(temp);
                else stack_uneven.Push(temp);
            }
            while (!stack_even.IsEmpty)
            {
                stack_3.Push(stack_even.Pop());
            }
            while (!stack_uneven.IsEmpty)
            {
                stack_3.Push(stack_uneven.Pop());
            }

            Console.WriteLine("Стек после изменения");
            NodeStack<task_3>.Print(ref stack_3);

            Console.ReadLine();
        }
        struct task_3
        {
            public int year;
            public override string ToString()
            {
                return year.ToString();
            }
        }
    }
}

