using System.IO.Compression;
using System.Text;
using System.Xml;

namespace Stromingsleer;
class Program
{
    static void Main(string[] args)
    {
        //WritingForNerds();
        //ReadingForNerds();
        //WritingForNormals();
        //ReadForNormals();
        DemoXml();
    }

    private static void DemoXml()
    {
        FileInfo file = new FileInfo(@"D:\AIVD\normal.xml");
        //FileStream fs = file.Create();
        //var writer = XmlWriter.Create(fs);
        // writer.WriteStartDocument();
        // writer.WriteStartElement("people");
        // writer.WriteStartElement("person");
        // writer.WriteAttributeString("Id", "1");
        // writer.WriteStartElement("name");
        // writer.WriteValue("Pieter");
        // writer.WriteEndElement();
        // writer.WriteEndElement();
        // writer.WriteEndElement();
        // writer.WriteEndDocument();
        // writer.Flush();
        //writer.Close();

        var fs = file.OpenRead();
        var rdr = XmlReader.Create(fs);
        while (rdr.ReadToFollowing("person"))
        {
            rdr.ReadToDescendant("name");
            string data = rdr.ReadInnerXml();
            System.Console.WriteLine(data);
        }
    }

    private static void ReadForNormals()
    {
        var file = new FileInfo(@"D:\AIVD\normal.zip");
        var fs = file.OpenRead();
        var zip = new GZipStream(fs, CompressionMode.Decompress);
        var rdr = new StreamReader(zip);
        string? line = null;
        while ((line = rdr.ReadLine()) != null)
        {
            System.Console.WriteLine(line);
        }

    }

    private static void WritingForNormals()
    {
        FileInfo file = new FileInfo(@"D:\AIVD\normal.zip");
        FileStream fs = file.Create();
        GZipStream zip = new GZipStream(fs, CompressionMode.Compress);
        StreamWriter streamWriter = new StreamWriter(zip);
        StreamWriter wrt = streamWriter;
        for (int i = 0; i < 1000; i++)
        {
            wrt.WriteLine($"Hello World {i}");
        }
        wrt.Flush();
        wrt.Close();
    }

    private static void ReadingForNerds()
    {
        FileStream fs = File.OpenRead(@"D:\AIVD\nerdy.txt");
        byte[] buffer = new byte[8];

        int nrRead = 10;
        while ((nrRead = fs.Read(buffer, 0, buffer.Length)) > 0)
        {
            var line = Encoding.UTF8.GetString(buffer);
            System.Console.Write(line);
            Array.Clear(buffer);
        }
    }

    private static void WritingForNerds()
    {
        var line = "Hello World";
        FileStream fs;
        if (!File.Exists(@"D:\AIVD\nerdy.txt"))
            fs = File.Create(@"D:\AIVD\nerdy.txt");
        else
            fs = File.OpenWrite(@"D:\AIVD\nerdy.txt");
        for (int i = 0; i < 1000; i++)
        {
            byte[] buffer = Encoding.UTF8.GetBytes($"{line} {i}\r\n");
            fs.Write(buffer, 0, buffer.Length);
        }
        fs.Flush();
        fs.Close();
    }
}
