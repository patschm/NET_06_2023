using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cerials;
class Program
{
    static void Main(string[] args)
    {
        Person p1 = new Person { Id = 1, Name = "Pieter", Age = 63 };
        //Xmllen(p1);
        Jsonnen(p1);
    }

    private static void Jsonnen(Person p)
    {
        var file = new FileInfo(@"D:\AIVD\people.json");
        var fs = file.Create();

        var ser = new JsonSerializer();
        ser.ContractResolver =  new CamelCasePropertyNamesContractResolver();
        var wrt = new StreamWriter(fs);
        ser.Serialize(wrt, p);
        wrt.Flush();
        wrt.Close();

        fs = file.OpenRead();
        
        var rdr = new JsonTextReader(new StreamReader(fs));
        var px = ser.Deserialize<Person>(rdr);
        System.Console.WriteLine(px?.Name);
    }

    private static void Xmllen(Person p)
    {
        var file = new FileInfo(@"D:\AIVD\people.xml");
        var fs = file.Create();
        XmlSerializer ser = new XmlSerializer(typeof(Person));
        ser.Serialize(fs, p);
        fs.Flush();
        fs.Close();

        fs = file.OpenRead();

        var rdr = XmlReader.Create(fs);
        var px = ser.Deserialize(rdr) as Person;
        System.Console.WriteLine(px?.Name);
    }
}
