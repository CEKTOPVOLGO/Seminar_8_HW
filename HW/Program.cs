Console.Clear();
int num = TaskNumber("Введите номер задачи: 54 или 56 или 58 или 60 или 62: ", "Ошибка ввода!");
if (num == 54) FirstTask();
else if (num == 56) SecondTask();
else if (num == 58) ThirdTask();
else if (num == 60) FourthTask();
else FifthTask();

void FirstTask()
{
    int[,] array = GetRandomArray();
    PrintArray(array);
    FromMaxToMin(array);
    Console.WriteLine("Отсортированный по уменьшению значений в строках массив:");
    PrintArray(array);
}

void SecondTask()
{
    Console.WriteLine("Имеется массив из случайных цифр: ");
    int[,] array = GetRandomArray();   
    PrintArray(array);
    int[] MinSum = new int[3];
    MinSum = FindMinSum(array);
    Console.WriteLine($"Строка {MinSum[0] + 1} имеет наименьшую сумму элементов, равную: {MinSum[2]}");    
}

void ThirdTask()
{
    int a = UserNumber("Введите количество строк первого массива: ", "Ошибка ввода!");
    int b = UserNumber("Введите количество столбцов первого и строк второго массива: ", "Ошибка ввода!");
    int c = UserNumber("Введите количество столбцов второго массива: ", "Ошибка ввода!");
    int[,] arrayA = GetHalfRandomArray(a, b);
    int[,] arrayB = GetHalfRandomArray(b, c);
    int[,] arrayC = MullArray(arrayA, arrayB);
    Console.WriteLine("Первый массив: ");
    PrintArray(arrayA);
    Console.WriteLine("Второй массив: ");
    PrintArray(arrayB);
    Console.WriteLine("Произведение массивов: ");
    PrintArray(arrayC);
}

void FourthTask()
{
    Console.WriteLine("Имеется трехмерный массив из случайных цифр: ");
    int[,,] array = GetRandom();
    PrintNumbers(array);
}

void FifthTask()
{
    int columns = UserNumber("Введите количество строк: ", "Ошибка ввода!");
    int rows = UserNumber("Введите количество столбцов: ", "Ошибка ввода!");
    int[,] array = new int[columns, rows];
    FillArray(array, columns, rows);
    Console.WriteLine();
    PrintArray(array);
}

int[,] MullArray(int[,] arrayA, int[,] arrayB)
{
    int[,] resultArray = new int[arrayA.GetLength(0), arrayB.GetLength(1)];
    for (int i = 0; i < arrayA.GetLength(0); i++)
    {
        for(int j = 0; j < arrayB.GetLength(1); j++)
        {
            for(int k = 0; k < arrayA.GetLength(1); k++)
            {
                resultArray[i, j] += arrayA[i, k] * arrayB[k, j];

            }
        }
    }
    return resultArray;
}

int[,] GetHalfRandomArray(int a, int b)
{
    Random rnd = new Random();
    int[,] array = new int[a, b];
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(0, 10);
        }
    }
    return array;
}

void PrintNumbers(int[,,] array)
{
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            for(int k = 0; k < array.GetLength(2); k++)
            {
                Console.WriteLine($"({i}, {j}, {k}) : {array[i, j , k]}");
            }
        }
    }
}

int[,,] GetRandom()
{
    Random rnd = new Random();
    int[,,] array = new int[rnd.Next(1, 5), rnd.Next(1, 5), rnd.Next(1, 5)];
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            for(int k = 0; k < array.GetLength(2); k++)
            {
                array[i, j , k] = rnd.Next(1, 10);
            }
        }
    }
    return array;
}

int[] FindMinSum(int[,] array)
{
    int[] result = new int[3];
    result[2] = int.MaxValue;
    for(int i = 0; i < array.GetLength(0); i++)
    {        
        int sum = 0;
        for(int j = 0; j < array.GetLength(1); j++)
        {
            sum += array[i, j];
        }
        if (sum < result[2])
        {
            result[2] = sum;
            result[0] = i;
        }
    }        
    return result;
}

void FromMaxToMin(int[,] array)
{
    int temp;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 1; j < array.GetLength(1); j++)
        {
            for(int k = 1; k < array.GetLength(1); k++)
            {
                if(array[i, k] > array[i, k - 1])
                {
                    temp = array[i, k];
                    array[i, k] = array[i, k - 1];
                    array[i, k - 1] = temp;
                }
            }
        }

    }

}

void FillArray(int[,] array, int columns, int rows)
{
    int colRow = columns * rows;
    int temp = 0;
    int cnt = 1;
    while(cnt <= colRow)
    {
        for(int i = 0; i < rows; i++)
        {
            if(array[temp, i] == 0)
            {
                array[temp, i] = cnt;
                cnt++;
            }
        }
        for(int i = 0; i < columns; i++)
        {
            if(array[i, rows - temp - 1] == 0)
            {
                array[i, rows - temp - 1] = cnt;
                cnt++;
            }
        }
        for(int i = rows - 1; i >= 0; i--)
        {
            if(array[columns - temp - 1, i] == 0)
            {
                array[columns - temp - 1, i] = cnt;
                cnt++;
            }
        }
        for(int i = columns - 1; i >= 0; i--)
        {
            if(array[i, temp] == 0)
            {
                array[i, temp] = cnt;
                cnt++;
            }
        }
        temp++;
    }
}

int TaskNumber(string message, string errorMessage)
{
    while(true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
        if(isCorrect && (userNumber == 54 || userNumber == 56 || userNumber == 58 || userNumber == 60 || userNumber == 62))
            return userNumber;
        Console.WriteLine(errorMessage);
    }
}

int UserNumber(string message, string errorMessage)
{
    while(true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
        if(isCorrect)
            return userNumber;
        Console.WriteLine(errorMessage);
    }
}

void PrintArray(int[,] array)
{
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}  ");
        }
        Console.WriteLine();
    }
}

int[,] GetRandomArray()
{
    Random rnd = new Random();
    int[,] array = new int[rnd.Next(1, 10), rnd.Next(1, 10)];
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(0, 100);
        }
    }
    return array;
}

