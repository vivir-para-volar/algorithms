using System;
using System.Diagnostics;

namespace LB_1
{
    class Program
    {
        //Метод сортировки перемешиванием
        static void ShakerSort(int[] myint, out ulong n_c, out ulong n_p)
        {
            n_c = 0;
            n_p = 0;
            int left = 0, right = myint.Length - 1; 

            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    n_c++;
                    if (myint[i] > myint[i + 1])
                    {
                        int glass = myint[i];
                        myint[i] = myint[i + 1];
                        myint[i + 1] = glass;

                        n_p++;
                    }  
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    n_c++;
                    if (myint[i - 1] > myint[i])
                    {
                        int glass = myint[i];
                        myint[i] = myint[i - 1];
                        myint[i - 1] = glass;

                        n_p++;
                    }
                }
                left++;
            }
        }

        //Метод сортировка Шелла
        static void ShellSort(int[] myint, out ulong n_c, out ulong n_p)
        {
            n_c = 0;
            n_p = 0;
            for (int s = myint.Length / 2; s > 0; s /= 2)
            {
                for (int i = 0; i < myint.Length; i++)
                {
                    for (int j = i + s; j < myint.Length; j += s)
                    {
                        n_c++;
                        if (myint[i] > myint[j])
                        {
                            int glass = myint[i];
                            myint[i] = myint[j];
                            myint[j] = glass;

                            n_p++;
                        }
                    }
                }
            }
        }

        //сортировка слиянием
        static int[] MergeSort(int[] array, ref ulong n_c, ref ulong n_p)
        {
            n_c = 0;
            n_p = 0;
            return MergeSort(array, 0, array.Length - 1, ref n_c, ref n_p);
        }
        static int[] MergeSort(int[] array, int lowIndex, int highIndex, ref ulong n_c, ref ulong n_p)
        {
            n_c++;
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex, ref n_c, ref n_p);
                MergeSort(array, middleIndex + 1, highIndex, ref n_c, ref n_p);
                Merge(array, lowIndex, middleIndex, highIndex, ref n_c, ref n_p);
            }

            return array;
        }
        //метод для слияния массивов
        static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex, ref ulong n_c, ref ulong n_p)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                n_c++;
                if (array[left] < array[right])
                {
                    n_p++;
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    n_p++;
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                n_p++;
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                n_p++;
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                n_p++;
                array[lowIndex + i] = tempArray[i];
            }
        }

       
        


        static void Main(string[] args)
        {
            void ShowArr(int[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine("arr[" + i + "] = " + arr[i]);
                }
            }
            void CreatArray_3(int[] arr_1, int[] arr_2, int[] arr_3)
            {
                var rnd = new Random();
                for (int i = 0; i < arr_1.Length; i++)
                {
                    arr_1[i] = rnd.Next(0, 100);
                }
                Array.Copy(arr_1, arr_2, arr_1.Length);
                Array.Copy(arr_1, arr_3, arr_1.Length);
            }

            int[] arr_1_1 = new int[10];
            int[] arr_1_2 = new int[10];
            int[] arr_1_3 = new int[10];
            CreatArray_3(arr_1_1, arr_1_2, arr_1_3);
            int[] arr_2_1 = new int[100];
            int[] arr_2_2 = new int[100];
            int[] arr_2_3 = new int[100];
            CreatArray_3(arr_2_1, arr_2_2, arr_2_3);
            int[] arr_3_1 = new int[1000];
            int[] arr_3_2 = new int[1000];
            int[] arr_3_3 = new int[1000];
            CreatArray_3(arr_3_1, arr_3_2, arr_3_3);
            int[] arr_4_1 = new int[10000];
            int[] arr_4_2 = new int[10000];
            int[] arr_4_3 = new int[10000];
            CreatArray_3(arr_4_1, arr_4_2, arr_4_3);
            int[] arr_5_1 = new int[100000];
            int[] arr_5_2 = new int[100000];
            int[] arr_5_3 = new int[100000];
            CreatArray_3(arr_5_1, arr_5_2, arr_5_3);
            int[] arr_6_1 = new int[1000000];
            int[] arr_6_2 = new int[1000000];
            int[] arr_6_3 = new int[1000000];
            CreatArray_3(arr_6_1, arr_6_2, arr_6_3);

            ulong n_c_1_1;
            ulong n_p_1_1;
            ulong n_c_1_2;
            ulong n_p_1_2;
            ulong n_c_1_3 = 0;
            ulong n_p_1_3 = 0;
            ulong n_c_2_1;
            ulong n_p_2_1;
            ulong n_c_2_2;
            ulong n_p_2_2;
            ulong n_c_2_3 = 0;
            ulong n_p_2_3 = 0;
            ulong n_c_3_1;
            ulong n_p_3_1;
            ulong n_c_3_2;
            ulong n_p_3_2;
            ulong n_c_3_3 = 0;
            ulong n_p_3_3 = 0;
            ulong n_c_4_1;
            ulong n_p_4_1;
            ulong n_c_4_2;
            ulong n_p_4_2;
            ulong n_c_4_3 = 0;
            ulong n_p_4_3 = 0;
            ulong n_c_5_1;
            ulong n_p_5_1;
            ulong n_c_5_2;
            ulong n_p_5_2;
            ulong n_c_5_3 = 0;
            ulong n_p_5_3 = 0;
            ulong n_c_6_1;
            ulong n_p_6_1;
            ulong n_c_6_2;
            ulong n_p_6_2;
            ulong n_c_6_3 = 0;
            ulong n_p_6_3 = 0;

            Stopwatch stopWatch = new Stopwatch();
            //Метод сортировки перемешиванием
            stopWatch.Start();
            ShakerSort(arr_1_1, out n_c_1_1, out n_p_1_1);
            stopWatch.Stop();
            TimeSpan ts_1_1 = stopWatch.Elapsed;
           
            stopWatch.Restart();
            ShakerSort(arr_2_1, out n_c_2_1, out n_p_2_1);
            stopWatch.Stop();
            TimeSpan ts_2_1 = stopWatch.Elapsed;
            
            stopWatch.Restart();
            ShakerSort(arr_3_1, out n_c_3_1, out n_p_3_1);
            stopWatch.Stop();
            TimeSpan ts_3_1 = stopWatch.Elapsed;
          
            stopWatch.Restart();
            ShakerSort(arr_4_1, out n_c_4_1, out n_p_4_1);
            stopWatch.Stop();
            TimeSpan ts_4_1 = stopWatch.Elapsed;

            stopWatch.Restart();
            ShakerSort(arr_5_1, out n_c_5_1, out n_p_5_1);
            stopWatch.Stop();
            TimeSpan ts_5_1 = stopWatch.Elapsed;

            stopWatch.Restart();
            ShakerSort(arr_6_1, out n_c_6_1, out n_p_6_1);
            stopWatch.Stop();
            TimeSpan ts_6_1 = stopWatch.Elapsed; 

            //Метод сортировка Шелла
            stopWatch.Restart();
            ShellSort(arr_1_2, out n_c_1_2, out n_p_1_2);
            stopWatch.Stop();
            TimeSpan ts_1_2 = stopWatch.Elapsed;
            
            stopWatch.Start();
            ShellSort(arr_2_2, out n_c_2_2, out n_p_2_2);
            stopWatch.Stop();
            TimeSpan ts_2_2 = stopWatch.Elapsed;
           
            stopWatch.Restart();
            ShellSort(arr_3_2, out n_c_3_2, out n_p_3_2);
            stopWatch.Stop();
            TimeSpan ts_3_2 = stopWatch.Elapsed;
           
            stopWatch.Start();
            ShellSort(arr_4_2, out n_c_4_2, out n_p_4_2);
            stopWatch.Stop();
            TimeSpan ts_4_2 = stopWatch.Elapsed;

            stopWatch.Restart();
            ShellSort(arr_5_2, out n_c_5_2, out n_p_5_2);
            stopWatch.Stop();
            TimeSpan ts_5_2 = stopWatch.Elapsed;

            stopWatch.Restart();
            ShellSort(arr_6_2, out n_c_6_2, out n_p_6_2);
            stopWatch.Stop();
            TimeSpan ts_6_2 = stopWatch.Elapsed; 

            //сортировка слиянием
            stopWatch.Restart();
            MergeSort(arr_1_3, ref n_c_1_3, ref n_p_1_3);
            stopWatch.Stop();
            TimeSpan ts_1_3 = stopWatch.Elapsed;
           
            stopWatch.Restart();
            MergeSort(arr_2_3, ref n_c_2_3, ref n_p_2_3);
            stopWatch.Stop();
            TimeSpan ts_2_3 = stopWatch.Elapsed;
            
            stopWatch.Restart();
            MergeSort(arr_3_3, ref n_c_3_3, ref n_p_3_3);
            stopWatch.Stop();
            TimeSpan ts_3_3 = stopWatch.Elapsed;
           
            stopWatch.Restart();
            MergeSort(arr_4_3, ref n_c_4_3, ref n_p_4_3);
            stopWatch.Stop();
            TimeSpan ts_4_3 = stopWatch.Elapsed;
          
            stopWatch.Restart();
            MergeSort(arr_5_3, ref n_c_5_3, ref n_p_5_3);
            stopWatch.Stop();
            TimeSpan ts_5_3 = stopWatch.Elapsed;
           
            stopWatch.Restart();
            MergeSort(arr_6_3, ref n_c_6_3, ref n_p_6_3);
            stopWatch.Stop();
            TimeSpan ts_6_3 = stopWatch.Elapsed; 
          
            TimeSpan Comparison_Min(TimeSpan ts_1, TimeSpan ts_2, TimeSpan ts_3)
            {
                if (TimeSpan.Compare(ts_1,ts_2)==-1 & TimeSpan.Compare(ts_1, ts_3) == -1) return ts_1;
                else if (TimeSpan.Compare(ts_2, ts_1) == -1 & TimeSpan.Compare(ts_2, ts_3) == -1) return ts_2;
                else return ts_3;
            }
            TimeSpan Comparison_Max(TimeSpan ts_1, TimeSpan ts_2, TimeSpan ts_3)
            {
                if (TimeSpan.Compare(ts_1, ts_2) == 1 & TimeSpan.Compare(ts_1, ts_3) == 1) return ts_1;
                else if (TimeSpan.Compare(ts_2, ts_1) == 1 & TimeSpan.Compare(ts_2, ts_3) == 1) return ts_2;
                else return ts_3;
            }
            TimeSpan Average(TimeSpan ts_1, TimeSpan ts_2, TimeSpan ts_3)
            {
                return TimeSpan.FromMilliseconds((ts_1.TotalMilliseconds + ts_2.TotalMilliseconds + ts_3.TotalMilliseconds) / 3);
            }

            Console.WriteLine("{0,28}{1,17}{2,17}{3,17}{4,17}{5,17}", 10, 100, 1000, 10000, 100000, 1000000);
            Console.WriteLine("Алгоритм 1  " + ts_1_1 + " " + ts_2_1 + " " + ts_3_1 + " " + ts_4_1 + " " + ts_5_1 + " " + ts_6_1);
            Console.WriteLine("Алгоритм 2  " + ts_1_2 + " " + ts_2_2 + " " + ts_3_2 + " " + ts_4_2 + " " + ts_5_2 + " " + ts_6_2);
            Console.WriteLine("Алгоритм 3  " + ts_1_3 + " " + ts_2_3 + " " + ts_3_3 + " " + ts_4_3 + " " + ts_5_3 + " " + ts_6_3);
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Мин.знач    " + Comparison_Min(ts_1_1, ts_1_2, ts_1_3) + " " + Comparison_Min(ts_2_1, ts_2_2, ts_2_3) + " " + Comparison_Min(ts_3_1, ts_3_2, ts_3_3) + " " + Comparison_Min(ts_4_1, ts_4_2, ts_4_3) + " " + Comparison_Min(ts_5_1, ts_5_2, ts_5_3) + " " + Comparison_Min(ts_6_1, ts_6_2, ts_6_3) );
            Console.WriteLine("Макс.знач   " + Comparison_Max(ts_1_1, ts_1_2, ts_1_3) + " " + Comparison_Max(ts_2_1, ts_2_2, ts_2_3) + " " + Comparison_Max(ts_3_1, ts_3_2, ts_3_3) + " " + Comparison_Max(ts_4_1, ts_4_2, ts_4_3) + " " + Comparison_Max(ts_5_1, ts_5_2, ts_5_3) + " " + Comparison_Max(ts_6_1, ts_6_2, ts_6_3) );
            Console.WriteLine("Ср.знач     {0,16}{1,17}{2,17}{3,17}{4,17}{5,17}", Average(ts_1_1, ts_1_2, ts_1_3), Average(ts_2_1, ts_2_2, ts_2_3), Average(ts_3_1, ts_3_2, ts_3_3), Average(ts_4_1, ts_4_2, ts_4_3), Average(ts_5_1, ts_5_2, ts_5_3), Average(ts_6_1, ts_6_2, ts_6_3) );





            ulong Comparison_Min_Int(ulong item_1, ulong item_2, ulong item_3)
            {
                if (item_1 < item_2 & item_1 < item_3) return item_1;
                else if (item_2 < item_1 & item_2 < item_3) return item_2;
                else return item_3;
            }
            ulong Comparison_Max_Int(ulong item_1, ulong item_2, ulong item_3)
            {
                if (item_1 > item_2 & item_1 > item_3) return item_1;
                else if (item_2 > item_1 & item_2 > item_3) return item_2;
                else return item_3;
            }
            ulong Average_Int(ulong item_1, ulong item_2, ulong item_3)
            {
                return (item_1 + item_2 + item_3) / 3;
            }

            Console.WriteLine("\n\nЧисло сравнений значений элементов");
            Console.WriteLine("{0,16}{1,10}{2,10}{3,10}{4,20}{5,30}", 10, 100, 1000, 10000, 100000, 1000000);
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Алгоритм 1  {0,4}{1,10}{2,10}{3,10}{4,20}{5,30}", n_c_1_1, n_c_2_1, n_c_3_1, n_c_4_1, n_c_5_1, n_c_6_1 );
            Console.WriteLine("Алгоритм 2  {0,4}{1,10}{2,10}{3,10}{4,20}{5,30}", n_c_1_2, n_c_2_2, n_c_3_2, n_c_4_2, n_c_5_2, n_c_6_2 );
            Console.WriteLine("Алгоритм 3  {0,4}{1,10}{2,10}{3,10}{4,20}{5,30}", n_c_1_3, n_c_2_3, n_c_3_3, n_c_4_3, n_c_5_3, n_c_6_3 );
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Мин.знач    {0,4}{1,10}{2,10}{3,10}{4,20}{5,30}", Comparison_Min_Int(n_c_1_1, n_c_1_2, n_c_1_3), Comparison_Min_Int(n_c_2_1, n_c_2_2, n_c_2_3), Comparison_Min_Int(n_c_3_1, n_c_3_2, n_c_3_3), Comparison_Min_Int(n_c_4_1, n_c_4_2, n_c_4_3), Comparison_Min_Int(n_c_5_1, n_c_5_2, n_c_5_3), Comparison_Min_Int(n_c_6_1, n_c_6_2, n_c_6_3) );
            Console.WriteLine("Макс.знач   {0,4}{1,10}{2,10}{3,10}{4,20}{5,30}", Comparison_Max_Int(n_c_1_1, n_c_1_2, n_c_1_3), Comparison_Max_Int(n_c_2_1, n_c_2_2, n_c_2_3), Comparison_Max_Int(n_c_3_1, n_c_3_2, n_c_3_3), Comparison_Max_Int(n_c_4_1, n_c_4_2, n_c_4_3), Comparison_Max_Int(n_c_5_1, n_c_5_2, n_c_5_3), Comparison_Max_Int(n_c_6_1, n_c_6_2, n_c_6_3) );
            Console.WriteLine("Ср.знач     {0,4}{1,10}{2,10}{3,10}{4,20}{5,30}", Average_Int(n_c_1_1, n_c_1_2, n_c_1_3), Average_Int(n_c_2_1, n_c_2_2, n_c_2_3), Average_Int(n_c_3_1, n_c_3_2, n_c_3_3), Average_Int(n_c_4_1, n_c_4_2, n_c_4_3), Average_Int(n_c_5_1, n_c_5_2, n_c_5_3), Average_Int(n_c_6_1, n_c_6_2, n_c_6_3) );

            Console.WriteLine("\n\nЧисло перестановок элементов");
            Console.WriteLine("{0,16}{1,10}{2,10}{3,10}{4,20}{5,30}", 10, 100, 1000, 10000, 100000, 1000000);
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Алгоритм 1  {0,4}{1,10}{2,10}{3,10}{4,20}{5,30}", n_p_1_1, n_p_2_1, n_p_3_1, n_p_4_1, n_p_5_1, n_p_6_1 );
            Console.WriteLine("Алгоритм 2  {0,4}{1,10}{2,10}{3,10}{4,20}{5,30}", n_p_1_2, n_p_2_2, n_p_3_2, n_p_4_2, n_p_5_2, n_p_6_2 );
            Console.WriteLine("Алгоритм 3  {0,4}{1,10}{2,10}{3,10}{4,20}{5,30}", n_p_1_3, n_p_2_3, n_p_3_3, n_p_4_3, n_p_5_3, n_p_6_3 );
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Мин.знач    {0,4}{1,10}{2,10}{3,10}{4,20}{5,30}", Comparison_Min_Int(n_p_1_1, n_p_1_2, n_p_1_3), Comparison_Min_Int(n_p_2_1, n_p_2_2, n_p_2_3), Comparison_Min_Int(n_p_3_1, n_p_3_2, n_p_3_3), Comparison_Min_Int(n_p_4_1, n_p_4_2, n_p_4_3), Comparison_Min_Int(n_p_5_1, n_p_5_2, n_p_5_3), Comparison_Min_Int(n_p_6_1, n_p_6_2, n_p_6_3) );
            Console.WriteLine("Макс.знач   {0,4}{1,10}{2,10}{3,10}{4,20}{5,30}", Comparison_Max_Int(n_p_1_1, n_p_1_2, n_p_1_3), Comparison_Max_Int(n_p_2_1, n_p_2_2, n_p_2_3), Comparison_Max_Int(n_p_3_1, n_p_3_2, n_p_3_3), Comparison_Max_Int(n_p_4_1, n_p_4_2, n_p_4_3), Comparison_Max_Int(n_p_5_1, n_p_5_2, n_p_5_3), Comparison_Max_Int(n_p_6_1, n_p_6_2, n_p_6_3) );
            Console.WriteLine("Ср.знач     {0,4}{1,10}{2,10}{3,10}{4,20}{5,30}", Average_Int(n_p_1_1, n_p_1_2, n_p_1_3), Average_Int(n_p_2_1, n_p_2_2, n_p_2_3), Average_Int(n_p_3_1, n_p_3_2, n_p_3_3), Average_Int(n_p_4_1, n_p_4_2, n_p_4_3), Average_Int(n_p_5_1, n_p_5_2, n_p_5_3), Average_Int(n_p_6_1, n_p_6_2, n_p_6_3) );

            Console.ReadKey();
        }
    }
}
