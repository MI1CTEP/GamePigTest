using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha
{
    class Program
    {
        private static char[,] _array = 
            {{ '_','*','_','_','_','_','_','_','_'},
            { '*','_','_','_','*','_','*','_','_'},
            { '_','*','_','_','*','*','*','_','*'}, 
            { '*','*','_','*','*','*','*','_','*'}};
        private static int _quantity;

        private static void Main(string[] args)
        {
            char[,] newArray = _array;

            for (int i = 0; i < _array.GetLength(0); i++)
            {
                _quantity = 0;
                for (int j = 0; j < _array.GetLength(1); j++)
                {
                    if (_array[i, j] == '*')
                        _quantity++;
                    _array[i, j] = '*';
                }
                int quantity = (_array.GetLength(1) - _quantity) / 2;

                for (int j = 0; j < quantity; j++)
                    newArray[i, j] = '_';
                for (int j = quantity + _quantity; j < _array.GetLength(1); j++)
                    newArray[i, j] = '_';
            }
            ReadArray(newArray);
        }
        private static void ReadArray(char[,] array)
        {
            for (int i = 0; i < _array.GetLength(0); i++)
            {
                for (int j = 0; j < _array.GetLength(1); j++)
                    Console.Write(array[i,j]);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
