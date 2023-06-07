using System.Reflection;

namespace ReflectioOf;
class Program
{
    static void Main(string[] args)
    {
        var asm = Assembly.LoadFrom(@"D:\.NET Essentials\NET_06_2023\live\Dist\SomeLib.dll");
        Console.WriteLine(asm.FullName);
        //Onderzoek(asm);
        Hacken(asm);

        //Person p1 = new () {Name = "Henk", Age = 15};
        //p1.Introduce();
    }

    private static void Hacken(Assembly asm)
    {
        Type ptype = asm?.GetType("SomeLib.Person")!;
        object? p2 = Activator.CreateInstance(ptype!, new object[] { });

        PropertyInfo? prName = ptype.GetProperty("Name");
        PropertyInfo? prAge = ptype.GetProperty("Age");

        prName?.SetValue(p2, "Suzanne");
        prAge?.SetValue(p2, 18);

        FieldInfo? fAge = ptype.GetField("_age", BindingFlags.Instance | BindingFlags.NonPublic);
        fAge.SetValue(p2, -18);

        MethodInfo? mIntro = ptype.GetMethod("Introduce");
        mIntro?.Invoke(p2, new object[] { });

        dynamic? p3 = Activator.CreateInstance(ptype!, new object[] { });

        p3.Name = "Patrick";
        p3.Age = 18;
        p3.Introduce();

    }

    private static void Onderzoek(Assembly asm)
    {
        // foreach(var t in asm.GetTypes())
        // {
        //     Console.WriteLine(t.Name);
        // }
        var ptype = asm.GetType("SomeLib.Person");
        foreach (var mem in ptype.GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
            Console.WriteLine($"{mem.MemberType}: {mem.Name}");
        }
    }
}
