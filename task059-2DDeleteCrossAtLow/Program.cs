/*
Задача 59: Задайте двумерный массив из целых чисел. 
Напишите программу, которая удалит строку и столбец, 
на пересечении которых расположен наименьший элемент массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Наименьший элемент - 1, на выходе получим следующий массив:
9 4 2
2 2 6
3 4 7
*/

// Если минимальных элементов несколько, то все они будут исключены.

int[,] GetNewArray(int row, int column)
{
    int[,] result = new int[row, column];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            result[i, j] = new Random().Next(1, 100);
        }
    }
    return result;
}

int CountLowerIndex(int[] arrayForCount)
{
    int result = 0;
    for (int i = 0; i < arrayForCount.Length; i++)
    {
        if (arrayForCount[i] != 0)
        {
            result++;
        }
    }
    return result;
}

(int, int[], int[]) FindLowerElementAndAllIndices(int[,] arrayForFind)
{
    int lowerElement = arrayForFind[0, 0];
    int[] lowerIndexRow = new int[arrayForFind.GetLength(0)];
    int[] lowerIndexColumn = new int[arrayForFind.GetLength(1)];
    for (int i = 0; i < arrayForFind.GetLength(0); i++)
    {
        for (int j = 0; j < arrayForFind.GetLength(1); j++)
        {
            if (arrayForFind[i, j] == lowerElement)
            {
                lowerIndexRow[i] = i + 1;
                lowerIndexColumn[j] = j + 1;
            }
            if (arrayForFind[i, j] < lowerElement)
            {
                lowerElement = arrayForFind[i, j];
                Array.Clear(lowerIndexRow);
                Array.Clear(lowerIndexColumn);
                lowerIndexRow[i] = i + 1;
                lowerIndexColumn[j] = j + 1;
            }
        }
    }
    return (lowerElement, lowerIndexRow, lowerIndexColumn);
}

int[,] DeleteRowsAndColumns(int[,] arrayForDelete, int[] arrayIndexRow, int[] arrayIndexColumn)
{
    int countLowerRow = CountLowerIndex(arrayIndexRow);
    int countLowerColumn = CountLowerIndex(arrayIndexColumn);
    int resultArrayRow = arrayIndexRow.Length;
    int resultArrayColumn = arrayIndexColumn.Length;
    if (resultArrayRow - countLowerRow > 1 && resultArrayColumn - countLowerColumn > 1)
    {
        resultArrayRow -= countLowerRow;
        resultArrayColumn -= countLowerColumn;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Удаление строк невозможно... ничего не останется!");
        Console.ResetColor();
        return arrayForDelete;
    }
    int[,] result = new int[resultArrayRow, resultArrayColumn];
    for (int i = 0, tempRow = 0; i < result.GetLength(0); i++, tempRow++)
    {
        for (int j = 0, tempColumn = 0; j < result.GetLength(1); j++, tempColumn++)
        {
            while (arrayIndexRow[tempRow] != 0)
            {
                tempRow++;
            }
            while (arrayIndexColumn[tempColumn] != 0)
            {
                tempColumn++;
            }
            result[i, j] = arrayForDelete[tempRow, tempColumn];
        }
    }
    return result;
}

void Print2DArrayColor(int[,] arrayToPrint, int[] arrayIndexRow, int[] arrayIndexColumn)
{
    Console.Write($"\n[X]\t");
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
            if (arrayToPrint.GetLength(0) == arrayIndexRow.Length)
            {
                if (arrayIndexRow[i] != 0 || arrayIndexColumn[j] != 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
            }
            Console.Write(arrayToPrint[i, j] + "\t");
            Console.ResetColor();
        }
        Console.WriteLine();
    }
}

int arrayRow = 7;
int arrayColumn = 7;

int[,] baseArray = GetNewArray(arrayRow, arrayColumn);
(int lowerElement, int[] rowIndices, int[] columnIndices) = FindLowerElementAndAllIndices(baseArray);
Print2DArrayColor(baseArray, rowIndices, columnIndices);
Console.WriteLine($"\nНаименьший элемент в массиве = {lowerElement}");
int[,] resultArray = DeleteRowsAndColumns(baseArray, rowIndices, columnIndices);
Print2DArrayColor(resultArray, rowIndices, columnIndices);