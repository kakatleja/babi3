using System;
using System.IO;

public static class TextFiles
{
    // Задание 6
    public static void FillSingle(string path, int n)
    {
        Random rnd = new Random();
        using (StreamWriter sw = new StreamWriter(path))
            for (int i = 0; i < n; i++)
                sw.WriteLine(rnd.Next(0, 10));
    }

    public static int CountMax(string path)
    {
        int max = int.MinValue, count = 0;
        foreach (string s in File.ReadAllLines(path))
        {
            int x = int.Parse(s);
            if (x > max) { max = x; count = 1; }
            else if (x == max) count++;
        }
        return count;
    }

    // Задание 7
    public static void FillMulti(string path, int lines)
    {
        Random rnd = new Random();
        using (StreamWriter sw = new StreamWriter(path))
            for (int i = 0; i < lines; i++)
                sw.WriteLine($"{rnd.Next(10)} {rnd.Next(10)} {rnd.Next(10)}");
    }

    public static int CountEven(string path)
    {
        int count = 0;
        foreach (string line in File.ReadAllLines(path))
            foreach (string s in line.Split(' '))
                if (int.Parse(s) % 2 == 0) count++;
        return count;
    }

    // Задание 8
    public static void CopyLines(string src, string dst, string sub)
    {
        using (StreamWriter sw = new StreamWriter(dst))
            foreach (string line in File.ReadAllLines(src))
                if (line.Contains(sub))
                    sw.WriteLine(line);
    }
}
