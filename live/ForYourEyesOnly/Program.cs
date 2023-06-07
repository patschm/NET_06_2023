using System.Security.Cryptography;
using System.Text;

namespace ForYourEyesOnly;
class Program
{
    static void Main(string[] args)
    {
        //Asymmetrisch();
        Symmetrisch();
    }

    static void Asymmetrisch()
    {
        // Ontvanger
        RSA rsaReceiver = new RSACryptoServiceProvider();
        string pubKey = rsaReceiver.ToXmlString(false);

        // Sender
        string text = "Hello World";
        RSA rsa = new RSACryptoServiceProvider();
        rsa.FromXmlString(pubKey);
        byte[] cipher = rsa.Encrypt(Encoding.UTF8.GetBytes(text), RSAEncryptionPadding.Pkcs1);

        // Ontvanger
        byte[] data = rsaReceiver.Decrypt(cipher, RSAEncryptionPadding.Pkcs1);
        Console.WriteLine(Encoding.UTF8.GetString(data));

    }
     static void Symmetrisch()
    {
        // Sender
        string text = "Hello World";
        var tdes = TripleDES.Create();
        tdes.Mode = CipherMode.CBC;
        byte[] key = tdes.Key;
        byte[] iv = tdes.IV;
        
        byte[] cipher;
        using (var memStream = new MemoryStream())
        {
            using (var crypto = new CryptoStream(memStream, tdes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                using (var writer = new StreamWriter(crypto))
                {
                    writer.WriteLine(text);
                }
            }
            cipher = memStream.ToArray();
        }

        //Console.WriteLine(Encoding.UTF8.GetString(cipher));

        // Ontvanger
         var deso = TripleDES.Create();
         deso.Mode = CipherMode.CBC;
         deso.Key = key;
         deso.IV = iv;

         using (var memStream = new MemoryStream(cipher))
         {
             using (var crypto = new CryptoStream(memStream, deso.CreateDecryptor(), CryptoStreamMode.Read))
            {
                using (var rdr = new StreamReader(crypto))
                {
                    string data = rdr.ReadToEnd();
                    Console.WriteLine(data);
                }
            }
         }
    }
}
