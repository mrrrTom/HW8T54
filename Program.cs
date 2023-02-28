// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

namespace HW54
{
    class ConsoleApp
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the array row orderer!");
            var arr = new ArrayBuilder(3, 4);
            Console.WriteLine("Here is you array:");
            Console.WriteLine(arr.ToString());
            arr.SortRows();
            Console.WriteLine($"Here is sorted array:");
            Console.WriteLine(arr.ToString());
        }
    }

    public class ArrayBuilder
    {
        private double[,] _arr;
        private double[][] _rows;

        public ArrayBuilder(int row, int col)
        {
            _rows = new double[row][];
            for (int i = 0; i < row; i++)
            {
                _rows[i] = new double[col];
            }

            _arr = InitializeRadomArray(row, col);
        }

        public override string ToString()
        {
            return _arr.ToArrString();
        }

        public void SortRows()
        {
            if (_arr == null)
            {
                return;
            }
            
            for (int i = 0; i < _arr.GetLength(0); i++)
            {
                var row = _rows[i];
                row = row.OrderDescending().ToArray();
                _rows[i] = row;
                for (var j = 0; j < row.Length; j++)
                {
                    _arr[i, j] = row[j];
                }
            }
        }

        double[,] InitializeRadomArray(int row, int col)
        {
            var result = new double[row, col];
            var rnd = new Random();
            for (int i = 0; i < col; i++)
            {
                var colSumm = default(double);
                for (int j = 0; j < row; j++)
                {
                    var signPow = rnd.Next(1, 3);
                    var tenPow = rnd.Next(0, 3);
                    var doubleValue = rnd.NextDouble();
                    var sign = ((double)Math.Pow(-1, signPow));
                    var tens = ((double)Math.Pow(10, tenPow));
                    var roundCount = rnd.Next(0, 3);
                    var arrInput =  Math.Round(doubleValue * sign * tens, roundCount);
                    colSumm += arrInput;
                    AddValue(arrInput, j, i);
                    result[j, i] = arrInput;
                }
            }


            return result;
        }

        void AddValue(double value, int row, int col)
        {
            _rows[row][col] = value;
        }
    }

    public static class ArrExtension
    {
        public static string ToArrString(this double[,] arr)
        {
            var result = string.Empty;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    result += arr[i, j] + "\t";
                }

                result += "\n";
            }

            return result;
        }
    }
}