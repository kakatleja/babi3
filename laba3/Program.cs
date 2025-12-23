using System;
using System.IO;

class Program
{
    static void Main()
    {
        Matrix A = new Matrix(2, 2, true); // ввод с клавиатуры
        Matrix B = new Matrix(2, 2);
        Matrix C = new Matrix(2, 2);

        Console.WriteLine("Матрица A:");
        Console.WriteLine(A);
        Console.WriteLine("Матрица B:");
        Console.WriteLine(B);
        Console.WriteLine("Матрица C:");
        Console.WriteLine(C);

        Matrix result = 7 * A * (B.Transpose() - C);
        Console.WriteLine("Результат 7*A*(Bᵀ - C):");
        Console.WriteLine(result);

        Console.WriteLine("Элементы результата по индексам:");
        Console.WriteLine($"[0,0] = {result[0, 0]}");
        Console.WriteLine($"[0,1] = {result[0, 1]}");
        Console.WriteLine($"[1,0] = {result[1, 0]}");
        Console.WriteLine($"[1,1] = {result[1, 1]}");

        // Пример бинарного файла с числами
        string fileNums = "nums.bin";
        FileBinaryNumbers.Fill(fileNums, 10);
        Console.WriteLine("Разность max и min элементов бинарного файла:");
        Console.WriteLine(FileBinaryNumbers.DiffMaxMin(fileNums));

        // Пример игрушек
        Toy[] toys =
        {
            new Toy{ Name="Мяч", Price=500, AgeFrom=3, AgeTo=7 },
            new Toy{ Name="Робот", Price=520, AgeFrom=5, AgeTo=10 },
            new Toy{ Name="Кубик", Price=515, AgeFrom=2, AgeTo=5 }
        };
        string fileToys = "toys.xml";
        FileBinaryToys.Save(fileToys, toys);
        Toy[] loadedToys = FileBinaryToys.Load(fileToys);
        Console.WriteLine("Игрушки из файла:");
        foreach (var t in loadedToys)
            Console.WriteLine($"{t.Name} - {t.Price} руб.");

        // Примеры текстовых файлов
        string fileA = "a.txt";
        string fileB = "b.txt";
        string fileText = "text.txt";
        string fileOut = "out.txt";

        TextFiles.FillSingle(fileA, 20);
        Console.WriteLine($"Количество max элементов в {fileA}: {TextFiles.CountMax(fileA)}");

        TextFiles.FillMulti(fileB, 5);
        Console.WriteLine($"Количество чётных чисел в {fileB}: {TextFiles.CountEven(fileB)}");

        File.WriteAllLines(fileText, new string[]
        {
            "Сегодня старшеклассники выполняли ЕГЭ по информатике и ИКТ",
            "Форма работы была стандартная",
            "Ничего особенного"
        });
        TextFiles.CopyLines(fileText, fileOut, "форма");
        Console.WriteLine($"Строки с 'форма' скопированы в {fileOut}");
    }
}
