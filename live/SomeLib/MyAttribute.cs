namespace SomeLib;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class MyAttribute : Attribute
{
    public int MyAge { get; set; }
}
