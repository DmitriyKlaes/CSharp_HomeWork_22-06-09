/*
Задача 73: Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, 
так чтобы в одной группе все числа были взаимно просты (все числа в группе друг на друга не делятся)? 
Найдите M при заданном N и получите одно из разбиений на группы N ≤ 10²⁰.

Например, для N = 50, M получается 6
Группа 1: 1
Группа 2: 2 3 11 13 17 19 23 29 31 37 41 43 47
Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
Группа 4: 8 12 18 20 27 28 30 42 44 45 50
Группа 5: 7 16 24 36 40
Группа 6: 5 32 48

Группа 1: 1
Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
Группа 4: 8 12 18 20 27 28 30 42 44 45 50
Группа 5: 16 24 36 40
Группа 6: 32 48
*/


int[] GetArray(int length)
{
    int[] result = new int[length];
    for (int i = 0; i < result.Length; i++)
    {
        result[i] = i + 1;
    }
    return result;
}

void PrintGroup(int[] arrayToPrint)
{
    for (int i = 0; i < arrayToPrint.Length; i++)
    {
        if (arrayToPrint[i] > 0)
        {
            Console.Write(arrayToPrint[i] + " ");
        }
    }
    Console.WriteLine();
}

int ChangeArrayElseStop(int[] arrayForChange)
{
    int result = -1;
    for (int i = 0; i < arrayForChange.Length; i++)
    {
        if (arrayForChange[i] != 0)
        {
            arrayForChange[i] = -1;
        }
        else if (arrayForChange[i] == 0)
        {
            arrayForChange[i] = i + 1;
            result = i;
        }
    }
    return result;
}

int GroupsFindAndPrint(int range)
{
    int count = 0;
    int stopSignal = 0;
    int[] numbers = GetArray(range);
    for (int i = 0; i < numbers.Length; i++)
    {
        for (int j = i; j < numbers.Length; j++)
        {
            if (numbers[j] > 0)
            {
                int number = numbers[j];
                for (int k = j + 1; k < numbers.Length; k++)
                {
                    if (numbers[k] > 0 && numbers[k] % number == 0)
                    {
                        numbers[k] = 0;
                    }
                }
            }
        }
        count++;
        Console.Write($"Группа {count}: ");
        PrintGroup(numbers);
        stopSignal = ChangeArrayElseStop(numbers);
        if (stopSignal < 0)
        {
            break;
        }
    }
    return count;
}

int range = 50;
Console.WriteLine($"\nЗаданное число: {range}\n");
int groups = GroupsFindAndPrint(range);
Console.WriteLine($"\nКоличество групп: {groups}");