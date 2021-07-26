using System;
using System.Collections;
using System.Collections.Generic;

//Найти сумму всех элементов дека, который состоит из целых чисел, и приписать эту сумму в начало дека. 

namespace LB_2_2
{
    class Program
    {
        public class DoublyNode<T>
        {
            public DoublyNode(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public DoublyNode<T> Previous { get; set; }
            public DoublyNode<T> Next { get; set; }
        }

        public class Deque<T> : IEnumerable<T>  // двусвязный список
        {
            DoublyNode<T> head; // головной/первый элемент
            DoublyNode<T> tail; // последний/хвостовой элемент
            int count;  // количество элементов в списке

            // добавление элемента
            public void AddLast(T data)
            {
                DoublyNode<T> node = new DoublyNode<T>(data);

                if (head == null)
                    head = node;
                else
                {
                    tail.Next = node;
                    node.Previous = tail;
                }
                tail = node;
                count++;
            }
            public void AddFirst(T data)
            {
                DoublyNode<T> node = new DoublyNode<T>(data);
                DoublyNode<T> temp = head;
                node.Next = temp;
                head = node;
                if (count == 0)
                    tail = head;
                else
                    temp.Previous = node;
                count++;
            }
            public T RemoveFirst()
            {
                if (count == 0)
                    throw new InvalidOperationException();
                T output = head.Data;
                if (count == 1)
                {
                    head = tail = null;
                }
                else
                {
                    head = head.Next;
                    head.Previous = null;
                }
                count--;
                return output;
            }
            public T RemoveLast()
            {
                if (count == 0)
                    throw new InvalidOperationException();
                T output = tail.Data;
                if (count == 1)
                {
                    head = tail = null;
                }
                else
                {
                    tail = tail.Previous;
                    tail.Next = null;
                }
                count--;
                return output;
            }
            public int Count { get { return count; } }
            public bool IsEmpty { get { return count == 0; } }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                DoublyNode<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }
    
        static void Main(string[] args)
        {
            var rnd = new Random();
            //Найти сумму всех элементов дека, который состоит из целых чисел, и приписать эту сумму в начало дека.
            var deque = new Deque<int>();
            for (var i = 0; i < 5; i++)
            {
                deque.AddLast(rnd.Next(0, 10));
            }
            Console.WriteLine("Изначальный дек");
            foreach (var item in deque)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------");

            var deque_result = new Deque<int>();
            int sum = 0;
            while (!deque.IsEmpty)
            {
                var temp = deque.RemoveFirst();
                deque_result.AddLast(temp);
                sum += temp;
            }
            deque_result.AddFirst(sum);

            Console.WriteLine("Дек после изменения");
            foreach (var item in deque_result)
            {
                Console.WriteLine(item);
            }

        }
    }
}
