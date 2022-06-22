/*
Задача: Заполните спирально массив 4 на 4.

1  2  3  4
12 13 14 5
11 16 15 6
10  9  8 7
*/

// Данное решение подходит для любого размера массива... не только 4х4 и не только квадраты.

int[,] SpiralFill2DArray(int row, int column)
{
    int[,] result = new int[row, column];
    int element = 1;
    int indexLastRow = 0;
    int indexLastColumn = 0;
    int maxElement = result.GetLength(0) * result.GetLength(1) + 1;
    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = i; j < result.GetLength(1) - i; j++) // заполнение слева направо
        {
            if (element == maxElement)
            {
                break;
            }
            result[i, j] = element;
            element++;
            indexLastColumn = j;
        }
        for (int k = i + 1; k < result.GetLength(0) - i; k++) // заполнение сверху вниз
        {
            if (element == maxElement)
            {
                break;
            }
            result[k, indexLastColumn] = element;
            element++;
            indexLastRow = k;
        }
        for (int l = indexLastColumn - 1; l >= i; l--) // заполнение справа налево
        {
            if (element == maxElement)
            {
                break;
            }
            result[indexLastRow, l] = element;
            element++;
        }
        for (int m = indexLastRow - 1; m > i; m--) // заполнение снизу вверх
        {
            if (element == maxElement)
            {
                break;
            }
            result[m, i] = element;
            element++;
        }
        if (element == maxElement)
        {
            break;
        }
    }
    return result;
}

void Print2DArray(int[,] arrayToPrint)
{
    Console.Write("[ ]\t");
    for (int i = 0; i < arrayToPrint.GetLength(1); i++)
    {
        Console.Write($"[" + i + "]\t");
    }
    Console.WriteLine();
    for (int i = 0; i < arrayToPrint.GetLength(0); i++)
    {
        Console.Write($"[" + i + "]\t");
        for (int j = 0; j < arrayToPrint.GetLength(1); j++)
        {
            Console.Write(arrayToPrint[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

int arrayRow = 4;
int arrayColumn = 4;
int[,] arrayResult = SpiralFill2DArray(arrayRow, arrayColumn);
Print2DArray(arrayResult);