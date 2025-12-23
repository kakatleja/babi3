using System;
using System.IO;

public static class FileBinaryNumbers
{
    public static void Fill(string path, int n)
    {
        Random rnd = new Random();
        using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            for (int i = 0; i < n; i++)
                bw.Write(rnd.Next(-100, 100));
    }

    public static int DiffMaxMin(string path)
    {
        using (BinaryReader br = new BinaryReader(File.OpenRead(path)))
        {
            int min = int.MaxValue, max = int.MinValue;
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                int x = br.ReadInt32();
                if (x < min) min = x;
                if (x > max) max = x;
            }
            return max - min;
        }
    }
}
