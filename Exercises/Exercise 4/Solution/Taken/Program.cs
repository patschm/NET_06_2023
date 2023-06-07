namespace Taken;

internal class Program
{
    static void Main(string[] args)
    {
        //Synchroon();
        //Asynchroon();
        //HetWordtBeterAsync();
        //Bommelding();
        //Synchronizing();
        FoutenAsync();

        Console.WriteLine("En we gaan door");
        Console.ReadLine();
    }

    private static void FoutenAsync()
    {
        Task.Run(() =>
        {
            Console.WriteLine("Starting something");
            Task.Delay(1000).Wait();
            throw new Exception("Ooops!");
        }).ContinueWith(pTask =>
        {
            Console.WriteLine(pTask.Status);
            if (pTask.Exception != null)
            {
                Console.WriteLine(pTask.Exception);
            }
        });
    }

    private static async void Synchronizing()
    {
        Task[] tasks = new Task[10];
        for (int i = 0; i < 10; i++)
        {
            tasks[i] = Task.Run(async () =>
            {

                await Task.Delay(1000 + i * 200);
                Console.WriteLine($"Starting {i}");
            });
        }

        await Task.WhenAny(tasks);
        Console.WriteLine("Allemaal klaar");
    }

    private static void Bommelding()
    {
        var nikko = new CancellationTokenSource();
        var bom = nikko.Token;
        LangLopendAsync(bom);

        Console.WriteLine("Press Enter to exxplode...");
        Console.ReadLine();
        nikko.Cancel();
    }

    private static async void LangLopendAsync(CancellationToken? bommetje = null)
    {
        for (int i = 0; true; i++)
        {
            if (bommetje?.IsCancellationRequested == true)
            {
                Console.WriteLine("Zwaaaaai");
                return;
            }
            await Task.Delay(1000);
            Console.WriteLine($"Run {i}");
        }
    }

    private static async void HetWordtBeterAsync()
    {
        var t1 = Task.Run<int>(() => LongAdd(20, 30));

        int result = await t1;
        Console.WriteLine(result);
        Console.WriteLine("Einde");

        var t2 = Task.Run<int>(() => LongAdd(20, 30));
        result = await t2;
        Console.WriteLine(result);
        Console.WriteLine("Einde");
    }

    private static void Asynchroon()
    {
        //Task<int> t1 = new Task<int>(() => LongAdd(10,20));
        var t1 = Task.Run<int>(() => LongAdd(20, 30));
        t1.ContinueWith(pTask => Console.WriteLine(pTask.Result));
        t1.ContinueWith(pTask => Console.WriteLine(pTask.Status));
        //t1.Start();

        //Console.WriteLine(t1.Result); 
    }

    private static void Synchroon()
    {
        int result = LongAdd(10, 20);
        Console.WriteLine(result);
    }

    static int LongAdd(int a, int b)
    {
        Task.Delay(10000).Wait();
        return a + b;
    }
}