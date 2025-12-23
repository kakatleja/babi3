using System;

public class Matrix
{
    private long[,] data;
    public int Rows { get; }
    public int Cols { get; }

    // Квадратная матрица
    public Matrix(int n) : this(n, n) { }

    // Прямоугольная матрица
    public Matrix(int n, int m)
    {
        Rows = n;
        Cols = m;
        data = new long[n, m];
        Random rnd = new Random();
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                data[i, j] = rnd.Next(1, 10000);
    }

    // Конструктор с вводом с клавиатуры
    public Matrix(int n, int m, bool fromConsole) : this(n, m)
    {
        if (fromConsole)
        {
            Console.WriteLine($"Введите {n * m} элементов массива A:");
            for (int j = 0; j < m; j++)
                for (int i = n - 1; i >= 0; i--)
                {
                    while (!long.TryParse(Console.ReadLine(), out data[i, j]))
                        Console.WriteLine("Ошибка ввода. Введите число заново:");
                }
        }
    }

    // Индексатор
    public long this[int i, int j]
    {
        get => data[i, j];
        set => data[i, j] = value;
    }

    // Транспонирование
    public Matrix Transpose()
    {
        Matrix t = new Matrix(Cols, Rows);
        for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Cols; j++)
                t[j, i] = data[i, j];
        return t;
    }

    public override string ToString()
    {
        string s = "";
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
                s += $"{data[i, j],10}";
            s += "\n";
        }
        return s;
    }

    // Перегрузка операторов
    public static Matrix operator *(int scalar, Matrix m)
    {
        Matrix res = new Matrix(m.Rows, m.Cols);
        for (int i = 0; i < m.Rows; i++)
            for (int j = 0; j < m.Cols; j++)
                res[i, j] = scalar * m[i, j];
        return res;
    }

    public static Matrix operator -(Matrix a, Matrix b)
    {
        Matrix res = new Matrix(a.Rows, a.Cols);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                res[i, j] = a[i, j] - b[i, j];
        return res;
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.Cols != b.Rows) throw new Exception("Несовпадение размеров для умножения");
        Matrix res = new Matrix(a.Rows, b.Cols);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < b.Cols; j++)
            {
                res[i, j] = 0;
                for (int k = 0; k < a.Cols; k++)
                    res[i, j] += a[i, k] * b[k, j];
            }
        return res;
    }
}
