using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace COD3BR3AKR
{
    public class AESCryption : Cryptor
    {
        private readonly byte[] SALT_ARRAY = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };

        private const int SizeOfBuffer = 1024 * 8;

        public AESCryption(string key) : base(key){ }

        private static void CopyStream(Stream input, Stream output)
        {
            using (output)
            using (input)
            {
                byte[] buffer = new byte[SizeOfBuffer];
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    output.Write(buffer, 0, read);
                }
            }
        }

        public override bool Encrypt(string inputPath, string outputPath)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(this.CryptionKey, SALT_ARRAY);
                    aes.Key = pdb.GetBytes(32);
                    aes.IV = pdb.GetBytes(16);

                    ICryptoTransform encryptor = aes.CreateEncryptor();

                    using (FileStream inputStream = File.Open(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (FileStream outputStream = File.Open(outputPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                        {
                            using (CryptoStream cs = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                            {
                                inputStream.CopyTo(cs);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return true;
        }

        public override bool Decrypt(string inputPath, string outputPath)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(this.CryptionKey, SALT_ARRAY);
                    aes.Key = pdb.GetBytes(32);
                    aes.IV = pdb.GetBytes(16);

                    ICryptoTransform decryptor = aes.CreateDecryptor();

                    using (FileStream inputStream = File.Open(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (FileStream outputStream = File.Open(outputPath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                        {
                            using (CryptoStream cs = new CryptoStream(outputStream, decryptor, CryptoStreamMode.Write))
                            {
                                inputStream.CopyTo(cs);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return true;
        }

        public override string Encrypt(string plainText)
        {
            string cipherText = string.Empty;
            try
            {
                byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);
                using (Aes aes = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(this.CryptionKey, SALT_ARRAY);
                    aes.Key = pdb.GetBytes(32);
                    aes.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(plainBytes, 0, plainBytes.Length);                            
                        }
                        cipherText = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return cipherText;
        }

        public override string Decrypt( string cipherText)
        {
            string plainText = string.Empty;
            try
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes aes = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(this.CryptionKey, SALT_ARRAY);
                    aes.Key = pdb.GetBytes(32);
                    aes.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                        }
                        plainText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return plainText;
        }
    }
}
