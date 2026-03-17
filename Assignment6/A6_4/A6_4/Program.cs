using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    // 1. Define a Key and IV (Initialization Vector)
    // In a real app, store these securely, don't hardcode them!
    // Key must be 16, 24, or 32 bytes. IV must be 16 bytes.
    private static readonly byte[] Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012"); // 32 bytes (AES-256)
    private static readonly byte[] IV = Encoding.UTF8.GetBytes("1234567890123456"); // 16 bytes

    static void Main()
    {
        string originalFile = "secret.txt";
        string encryptedFile = "secret.enc";
        string decryptedFile = "restored.txt";

        try
        {
            // Create a test file
            File.WriteAllText(originalFile, "This is top secret information!");

            // Encrypt the file
            EncryptFile(originalFile, encryptedFile);
            Console.WriteLine("File Encrypted successfully.");

            // Decrypt the file
            DecryptFile(encryptedFile, decryptedFile);
            Console.WriteLine("File Decrypted successfully.");

            // Verify
            Console.WriteLine("\nOriginal Content: " + File.ReadAllText(originalFile));
            Console.WriteLine("Decrypted Content: " + File.ReadAllText(decryptedFile));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void EncryptFile(string inputFile, string outputFile)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Key;
            aes.IV = IV;

            using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
            using (ICryptoTransform encryptor = aes.CreateEncryptor())
            using (CryptoStream cs = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write))
            using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
            {
                fsInput.CopyTo(cs);
            }
        }
    }

    static void DecryptFile(string inputFile, string outputFile)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Key;
            aes.IV = IV;

            using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
            using (ICryptoTransform decryptor = aes.CreateDecryptor())
            using (CryptoStream cs = new CryptoStream(fsInput, decryptor, CryptoStreamMode.Read))
            using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
            {
                cs.CopyTo(fsOutput);
            }
        }
    }
}