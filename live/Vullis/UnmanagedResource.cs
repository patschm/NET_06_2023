namespace Vullis;

public class UnmanagedResource : IDisposable
{
    private static bool _isOpen = false;
    private FileStream? _file;

    public void Open()
    {
        Console.WriteLine("Opening...");
        if (_isOpen)
        {
            Console.WriteLine("Kennie. Is al in gebruik");
            return;
        }
        _isOpen = true;
        _file = File.Open(@"D:\AIVD\bla.txt", FileMode.OpenOrCreate);
        Console.WriteLine("Resource is open!");
    }
    public void Close()
    {
        Console.WriteLine("Closing...");    
        _isOpen = false;
        Console.WriteLine("Resource is closed!");
    }

    // Don't repeat yourself (DRY)
    protected virtual void RuimOp(bool ikKomUitDispose)
    {
        Close();
        if (ikKomUitDispose)
        {
            _file.Dispose();
        }
    }
    public void Dispose()
    {
        RuimOp(true);
        GC.SuppressFinalize(this);
    }

    ~UnmanagedResource()
    {
        RuimOp(false);
    }
}
