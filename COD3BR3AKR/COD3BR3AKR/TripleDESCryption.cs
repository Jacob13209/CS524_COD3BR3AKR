using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace COD3BR3AKR
{
    /// <summary>
    /// The Triple Data Encryption Standard (DES) is a symmetric key encryption algorithm for computerized cryptography. 
    /// As per the algorithm, the same key is used for encryption and decryption. 
    /// Also, the same block cipher algorithms are applied three times to each data block. 
    /// </summary>
    public class TripleDESCryption : Cryptor
    {
        public TripleDESCryption(string key) : base(key){ }

        public override string Encrypt(string plainText)
        {
            string cipherText = string.Empty;

            MD5CryptoServiceProvider myMD5CryptoService = new MD5CryptoServiceProvider();
            byte[] securityKeyArray = myMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(this.CryptionKey));

            try
            {
                byte[] encryptedArray = UTF8Encoding.UTF8.GetBytes(plainText);
                using (var tripleDESCryptoService = new TripleDESCryptoServiceProvider())
                {
                    tripleDESCryptoService.Key = securityKeyArray;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    tripleDESCryptoService.Padding = PaddingMode.PKCS7;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, tripleDESCryptoService.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(encryptedArray, 0, encryptedArray.Length);
                        }
                        tripleDESCryptoService.Clear();
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

        public override string Decrypt(string cipherText)
        {
            string plainText = string.Empty;

            MD5CryptoServiceProvider myMD5CryptoService = new MD5CryptoServiceProvider();
            byte[] securityKeyArray = myMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(this.CryptionKey));
            try
            {
                byte[] decryptedArray = Convert.FromBase64String(cipherText);
                using (var tripleDESCryptoService = new TripleDESCryptoServiceProvider())
                {
                    tripleDESCryptoService.Key = securityKeyArray;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    tripleDESCryptoService.Padding = PaddingMode.PKCS7;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, tripleDESCryptoService.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(decryptedArray, 0, decryptedArray.Length);
                        }
                        tripleDESCryptoService.Clear();
                        plainText = UTF8Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return plainText;
        }

        public override bool Encrypt(string fileInput, string fileOutput)
        {
            MD5CryptoServiceProvider myMD5CryptoService = new MD5CryptoServiceProvider();
            byte[] securityKeyArray = myMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(this.CryptionKey));
            try
            {
                using (var tripleDESCryptoService = new TripleDESCryptoServiceProvider())
                {
                    tripleDESCryptoService.Key = securityKeyArray;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    tripleDESCryptoService.Padding = PaddingMode.PKCS7;

                    ICryptoTransform encryptor = tripleDESCryptoService.CreateEncryptor();

                    using (FileStream inputStream = File.Open(fileInput, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (FileStream outputStream = File.Open(fileOutput, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
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
        public override bool Decrypt(string fileInput, string fileOutput)
        {
            MD5CryptoServiceProvider myMD5CryptoService = new MD5CryptoServiceProvider();
            byte[] securityKeyArray = myMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(this.CryptionKey));
            try
            {
                using (var tripleDESCryptoService = new TripleDESCryptoServiceProvider())
                {
                    tripleDESCryptoService.Key = securityKeyArray;
                    tripleDESCryptoService.Mode = CipherMode.ECB;
                    tripleDESCryptoService.Padding = PaddingMode.PKCS7;

                    ICryptoTransform decryptor = tripleDESCryptoService.CreateDecryptor();

                    using (FileStream inputStream = File.Open(fileInput, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (FileStream outputStream = File.Open(fileOutput, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
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
    }
}
