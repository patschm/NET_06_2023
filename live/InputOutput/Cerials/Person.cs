
using System.Xml.Serialization;

namespace Cerials;

[XmlRoot("person")]
public class Person
{
    [XmlAttribute("id")]
    public int Id { get; set; }
    [XmlElement("name")]
    public string? Name { get; set; }
    [XmlElement("age")]
    public int Age { get; set; }
}
