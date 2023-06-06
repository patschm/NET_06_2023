namespace Fileren;
class Program
{
    static void Main(string[] args)
    {
        //StaticGroup();
        //InstanceGroup();
        if (!Directory.Exists(@"D:\AIVD"))
            Directory.CreateDirectory(@"D:\AIVD");
        var watcher = new FileSystemWatcher();
        watcher.Path = @"D:\AIVD";
        watcher.Created += (s, a) => System.Console.WriteLine($"{a.Name} is aangemaakt");
        watcher.Deleted += (s, a) => System.Console.WriteLine($"{a.Name} is weggeknikkerd");
        watcher.Changed += (s, a) => System.Console.WriteLine($"{a.Name} is gewijzigd");
        watcher.EnableRaisingEvents = true;
        Console.ReadLine();
    }

    private static void InstanceGroup()
    {
        FileInfo file = new FileInfo(@"D:\bla.txt");
        if (file.Exists)
        {
            file.Delete();
        }
        else
        {
            file.Create().Close();
        }
    }
    private static void StaticGroup()
    {
        if (File.Exists(@"D:\bla.txt"))
        {
            File.Delete(@"D:\bla.txt");
        }
        else
        {
            File.Create(@"D:\bla.txt").Close();
        }
    }
}
