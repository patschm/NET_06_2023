namespace Vullis;
class Program
{
    static UnmanagedResource? ur_1;
    static UnmanagedResource? ur_2;

    static void Main(string[] args)
    {
        ur_1 = new UnmanagedResource();
        try
        {
            ur_1.Open();
        }
        finally
        {
            //ur_1.Dispose();
            ur_1 = null;
        }

        GC.Collect();
        GC.WaitForPendingFinalizers();


        ur_2 = new UnmanagedResource();
        //using (ur_2)
        {
            ur_2.Open();
        }

        using (var ur_3 = new UnmanagedResource())
        {
            ur_3.Open();
        }

        using var ur_4 = new UnmanagedResource();
        ur_4.Open();
        ur_4.Open();
        Console.ReadLine();
    }
}
