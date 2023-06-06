using Microsoft.Extensions.DependencyInjection;

namespace DI;
class Program
{

    static void Main(string[] args)
    {
        //OldSkool();
        //TheInjector();
        WithWrapper();
    }

    private static void WithWrapper()
    {
        var factory = new DefaultServiceProviderFactory();
        var services = new ServiceCollection();
        factory.CreateBuilder(services);

        services.AddTransient<ICalculator, Calculator>();
        services.AddTransient<CalculatorUI>();

        var provider = services.BuildServiceProvider();

        provider.GetRequiredService<CalculatorUI>().Run();
    }

    private static void TheInjector()
    {
        var factory = new DefaultServiceProviderFactory();
        var services = new ServiceCollection();
        factory.CreateBuilder(services);

        services.AddTransient<Calculator>();

        var provider = services.BuildServiceProvider();

        var sc1 = provider.CreateScope();
        for (int i = 0; i < 10; i++)
        {
            var c = sc1.ServiceProvider.GetRequiredService<Calculator>();

            int result = c.Add(i, 200);
            System.Console.WriteLine(result);
        }
         var sc2 = provider.CreateScope();
        for (int i = 0; i < 10; i++)
        {
            var c = sc2.ServiceProvider.GetRequiredService<Calculator>();

            int result = c.Add(i, 200);
            System.Console.WriteLine(result);
        }
    }

    private static void OldSkool()
    {
        Calculator c = new Calculator();
        int result = c.Add(1, 2);
        System.Console.WriteLine(result);
    }
}
