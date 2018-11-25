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

        public AESCryption(string key) : base(key){ }

        public override bool Encrypt(string fileInput, string fileOutput)
        {
            return true;
        }
        public override bool Decrypt(string fileInput, string fileOutput)
        {
            return true;
        }
        public override string Encrypt(string plainText)
        {
            string cipherText = string.Empty;
            try
            {
                byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(this.CryptionKey, SALT_ARRAY);
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(plainBytes, 0, plainBytes.Length);
                            cs.Close();
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
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(this.CryptionKey, SALT_ARRAY);
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
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
