namespace SomeLib;

[Obsolete("Beter niet gebruiken", false)]
[My(MyAge = 23)]
public class Person
{
    private int _age;
    public int Age
    {
        get { return _age; }
        set 
        { 
            if (value > 0 && value < 125)
                _age = value; 
        }
    }
    
    public string? Name { get; set; }

    public void Introduce()
    {
        Console.WriteLine($"{Name} ({Age})");
    }
    
}
