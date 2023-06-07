using System.Security.Cryptography;
using System.Text;

namespace Hasj;
class Program
{
    static void Main(string[] args)
    {
        //Simple();
        //Symmetrisch();
        ASymmetrisch();
    }

static void ASymmetrisch()
    {
        var result = ASymmetrischeSender();

        ASymmetrischeReceiver(result);
    }

    static void ASymmetrischeReceiver((string text, byte[] sign, string publicKey) tuple)
    {
        var alg = SHA1.Create();
        byte[] hash = alg.ComputeHash(Encoding.UTF8.GetBytes(tuple.text));
         DSA enc = new DSACryptoServiceProvider();
         enc.FromXmlString(tuple.publicKey);
         bool isOk = enc.VerifySignature(hash, tuple.sign);
         Console.WriteLine(isOk ? "Hij is fijn" : "Hij is helemaal niet fijn");
    }

    static (string text, byte[] sign, string publicKey) ASymmetrischeSender()
    {
        string text = "Hello World";
        var alg = SHA1.Create();
        byte[] hash = alg.ComputeHash(Encoding.UTF8.GetBytes(text));
        DSA enc = new DSACryptoServiceProvider();
        string privateKey = enc.ToXmlString(true);
        string publicKey = enc.ToXmlString(false);
        byte[] signature = enc.CreateSignature(hash);

        return (text, signature, publicKey);
    }

    static void Symmetrisch()
    {
        var result = SymmetrischeSender();

        SymmetrischeReceiver(result);
    }

    static void SymmetrischeReceiver((string text, byte[] hash) tuple)
    {
        var alg =new HMACSHA256();
        alg.Key = Encoding.UTF8.GetBytes("Pa$$w0rd");
         byte[] hash = alg.ComputeHash(Encoding.UTF8.GetBytes(tuple.text));
        Console.WriteLine(Convert.ToBase64String(hash));
        Console.WriteLine(Convert.ToBase64String(tuple.hash));
    }

    static (string text, byte[] hash) SymmetrischeSender()
    {
        string text = "Hello World";
        var alg = new HMACSHA256();
        alg.Key = Encoding.UTF8.GetBytes("Pa$$w0rd");
        byte[] hash = alg.ComputeHash(Encoding.UTF8.GetBytes(text));
        return (text, hash);
    }

    private static void Simple()
    {
        var result = Sender();
        result.text += ".";
        Receiver(result);
    }

    static (string text, byte[] hash) Sender()
    {
        string text = "Hello World";
        SHA256 alg = SHA256.Create();
        byte[] hash = alg.ComputeHash(Encoding.UTF8.GetBytes(text));
        return (text, hash);
    }
    static void Receiver((string text, byte[] hash) tuple)
    {
        SHA256 alg = SHA256.Create();
        byte[] hash = alg.ComputeHash(Encoding.UTF8.GetBytes(tuple.text));
        Console.WriteLine(Convert.ToBase64String(hash));
        Console.WriteLine(Convert.ToBase64String(tuple.hash));
    }
}
