using Microsoft.Extensions.Configuration;

namespace Envronment;
class Program
{
    static void Main(string[] args)
    {
        var env = Environment.GetEnvironmentVariable("NETCORE_BLAH");
        System.Console.WriteLine(env);

        IConfigurationBuilder bld = new ConfigurationBuilder();
        bld.SetBasePath(Environment.CurrentDirectory);
        bld.AddJsonFile("appsettings.json", optional:true, reloadOnChange:false);
        // bld.AddXmlFile("config.xml");
        // bld.AddIniFile("startup.ini");
        bld.AddUserSecrets<Program>();
        IConfiguration config = bld.Build();

        var val = config["Test"];
        System.Console.WriteLine(val);

        var val2 = config["Iemand:Name"];
        System.Console.WriteLine(val2);


        var sec1 = config.GetSection("Iemand");
        var p1 = new Person();
        sec1.Bind(p1);
        System.Console.WriteLine(p1);
        var p2 = sec1.Get<Person>();
        System.Console.WriteLine(p2);
    }
}
