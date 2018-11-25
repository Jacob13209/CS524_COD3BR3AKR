using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace COD3BR3AKR
{
    /// <summary> 
    /// RSA Encryption and Decryption
    /// </summary> 
    public class RSACryption : Cryptor
    {
        public RSACryption(string key) : base(key) {}

        public override bool Encrypt(string fileInput, string fileOutput)
        {
            return true;
        }
        public override bool Decrypt(string fileInput, string fileOutput)
        {
            return true;
        }     

        #region RSA Key Generation 
        /// <summary>
        /// Public and Private key generation 
        /// </summary>
        /// <param name="privatePath">File path for saving Private Key</param>
        /// <param name="publicPath">File path for saving Public Key</param>
        public static void GenerateRSAKeys(string privatePath, string publicPath)
        {
            string privateKey = string.Empty;
            string publicKey  = string.Empty;

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            privateKey = rsa.ToXmlString(true);
            using (StreamWriter sw = File.CreateText(privatePath))
            {
                sw.Write(privateKey);
            }

            publicKey  = rsa.ToXmlString(false);
            using (StreamWriter sw = File.CreateText(publicPath))
            {
                sw.Write(publicKey);
            }
        }
        #endregion

        #region RSA string Encryption
        public override string Encrypt(string plainText)
        {
            byte[] plainTextBArray;
            byte[] cipherTextBArray;
            string cipherText = string.Empty;
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(this.CryptionKey);
                plainTextBArray = (new UnicodeEncoding()).GetBytes(plainText);
                cipherTextBArray = rsa.Encrypt(plainTextBArray, false);
                cipherText = Convert.ToBase64String(cipherTextBArray);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }            

            return cipherText;
        }
        //RSA byte[] encryption
        public string RSAEncrypt(string xmlPublicKey, byte[] EncryptString)
        {
            byte[] CypherTextBArray;
            string Result;
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPublicKey);
            CypherTextBArray = rsa.Encrypt(EncryptString, false);
            Result = Convert.ToBase64String(CypherTextBArray);
            return Result;

        }
        #endregion

        #region RSA string Decryption
        public override string Decrypt(string cipherText)
        {
            byte[] plainTextBArray;
            byte[] decryptedTextBArray;
            string plainText = string.Empty;
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(this.CryptionKey);
                plainTextBArray = Convert.FromBase64String(cipherText);
                decryptedTextBArray = rsa.Decrypt(plainTextBArray, false);
                plainText = (new UnicodeEncoding()).GetString(decryptedTextBArray);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return plainText;
        }

        //RSA byte[] decryption
        public string RSADecrypt(string xmlPrivateKey, byte[] DecryptString)
        {
            byte[] DypherTextBArray;
            string Result;
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlPrivateKey);
            DypherTextBArray = rsa.Decrypt(DecryptString, false);
            Result = (new UnicodeEncoding()).GetString(DypherTextBArray);
            return Result;

        }
        #endregion
    }
}


