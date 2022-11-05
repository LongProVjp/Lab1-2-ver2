using System;
using System.Drawing;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Lab1
{
    internal class bai1
    {
        static void Main(string[] args)
        {
            OddEven();
            SNT();
            Sum();
            QS();
        }


        //Chẵn lẻ
        static void OddEven()
        {
            string[] Number = File.ReadAllLines("number.dat");
            using (var odd = File.CreateText("odd.txt"))
            using (var even = File.CreateText("even.txt"))
            {
                foreach (string line in Number)
                {
                    int lines = Convert.ToInt32(line);
                    if (lines % 2 == 0)
                    {
                        even.WriteLine(lines);
                    }
                    else
                    {
                        odd.WriteLine(lines);
                    }

                }
            }
        }


        //hàm kiểm tra số nguyên tố
        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;

        }

        //ghi số nguyên tố ra file
        static void SNT()
        {
            using (var Prime = File.CreateText("Prime.txt"))
            {
                string[] Number = File.ReadAllLines("number.dat");
                foreach (string line in Number)
                {
                    int lines = Convert.ToInt32(line);
                    if (IsPrime(lines))
                    {
                        Prime.WriteLine(lines);
                    }
                }
            }
        }

        //hàm tính tổng
        static void Sum()
        {
            using (var Sum = File.CreateText("Sum.txt"))
            {
                string[] Number = File.ReadAllLines("number.dat");
                long sum = Number.Sum(x => Convert.ToInt64(x));
                Sum.WriteLine(sum);
            }
        }
        //Hàm ghi Quicksort ra file
        static void QS()
        {
            using (var Quicksort = File.CreateText("Quicksort.txt"))
            {

                string[] lines = File.ReadLines("number.dat").ToArray();
                GenericQuickSort<string>.QuickSort(lines, 0, lines.Length - 1);
                Quicksort.WriteLine(String.Join(',', lines));


            }
        }
        //Class Quicksort
        class GenericQuickSort<T> where T : IComparable
        {

            public static void QuickSort(T[] ar, int lBound, int uBound)
            {
                if (lBound < uBound)
                {
                    var loc = Partition(ar, lBound, uBound);
                    QuickSort(ar, lBound, loc - 1);
                    QuickSort(ar, loc + 1, uBound);
                }
            }

            private static int Partition(T[] ar, int lBound, int uBound)
            {
                var start = lBound;
                var end = uBound;
                var pivot = ar[uBound];
                // switch to first value as pivot
                // var pivot = ar[lBound];
                while (start < end)
                {
                    while (ar[start].CompareTo(pivot) < 0)
                    {
                        start++;
                    }
                    while (ar[end].CompareTo(pivot) > 0)
                    {
                        end--;
                    }
                    if (start < end)
                    {
                        if (ar[start].CompareTo(ar[end]) == 0)
                        {
                            start++;
                        }
                        else
                        {
                            swap(ar, start, end);
                        }
                    }
                }
                return end;
            }
            private static void swap(T[] ar, int i, int j)
            {
                var temp = ar[i];
                ar[i] = ar[j];
                ar[j] = temp;
            }
            static bool IsPrime(int number)
            {
                if (number <= 1) return false;
                if (number == 2) return true;
                if (number % 2 == 0) return false;

                var boundary = (int)Math.Floor(Math.Sqrt(number));

                for (int i = 3; i <= boundary; i += 2)
                    if (number % i == 0)
                        return false;

                return true;
            }
        }
    }
}
