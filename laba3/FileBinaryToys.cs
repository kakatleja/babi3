using System;
using System.IO;
using System.Xml.Serialization;

public struct Toy
{
    public string Name;
    public double Price;
    public int AgeFrom;
    public int AgeTo;
}

public static class FileBinaryToys
{
    public static void Save(string path, Toy[] toys)
    {
        XmlSerializer xs = new XmlSerializer(typeof(Toy[]));
        using (FileStream fs = new FileStream(path, FileMode.Create))
            xs.Serialize(fs, toys);
    }

    public static Toy[] Load(string path)
    {
        XmlSerializer xs = new XmlSerializer(typeof(Toy[]));
        using (FileStream fs = new FileStream(path, FileMode.Open))
            return (Toy[])xs.Deserialize(fs);
    }
}
