/*
Задача 57: Составить частотный словарь элементов двумерного массива. 
Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.
Набор данных
Частотный массив
{ 1, 9, 9, 0, 2, 8, 0, 9 }
0 встречается 2 раза 
1 встречается 1 раз 
2 встречается 1 раз 
8 встречается 1 раз 
9 встречается 3 раза
1, 2, 3 
4, 6, 1 
2, 1, 6
1 встречается 3 раза 
2 встречается 2 раз 
3 встречается 1 раз 
4 встречается 1 раз 
6 встречается 2 раза
*/

int[,] GetNewArray(int row, int column)
{
    int[,] result = new int[row, column];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            result[i, j] = new Random().Next(0, 10);
        }
    }
    return result;
}

void FrequencyWords(int[,] arrayTo)
{
    int result = 0;
    for (int k = 0; k < 10; k++)
    {
        for (int i = 0; i < arrayTo.GetLength(0); i++)
        {
            for (int j = 0; j < arrayTo.GetLength(1); j++)
            {
                if (arrayTo[i, j] == k)
                {
                    result++;
                }
            }
        }
        if (result != 0)
        {
            string count = "раз";
            if (result > 1 && result < 5)
            {
                count = "раза";
            }
            System.Console.WriteLine($"{k} встречается {result} {count}.");
        }
        result = 0;
    }
}

void Print2DArray(int[,] arrayToPrint)
{
    Console.Write($"[X]\t");
    for (int i = 0; i < arrayToPrint.GetLength(1); i++)
    {
        Console.Write($"[{i}]\t");
    }
    Console.WriteLine("");
    for (int i = 0; i < arrayToPrint.GetLength(0); i++)
    {
        Console.Write($"[{i}]\t");
        for (int j = 0; j < arrayToPrint.GetLength(1); j++)
        {
            Console.Write(arrayToPrint[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

int arrayRow = 3;
int arrayColumn = 3;
int[,] array = GetNewArray(arrayRow, arrayColumn);
Print2DArray(array);
FrequencyWords(array);