using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace COD3BR3AKR
{
    /// <summary> 
    /// Being used for RSA Text string Encryption and Decryption
    /// </summary> 
    public class RSACryption : Cryptor
    {
        /*****************************************************************************************************
         * The max number of bytes which can be encrypted with a particular key size with the following:
         *        ((KeySize - 384) / 8) + 37
         *  However, if the optimal asymmetric encryption padding (OAEP) parameter is true, as it is in the original post, the following can be used to calculate the max bytes:
         *        ((KeySize - 384) / 8) + 7
         *  Note:The legal key sizes are 384 thru 16384 with a skip size of 8.
         *
         ****************************************************************************************************/
        private static readonly int KEY_SIZE_FOR_MAX_TEXT_INPUT = 5120;

        public RSACryption(string key) : base(key) {}

        /// <summary>
        /// Override function for Encryting file
        /// </summary>
        /// <param name="fileInput">input file path</param>
        /// <param name="fileOutput">output file path</param>
        /// <returns></returns>
        public override bool Encrypt(string fileInput, string fileOutput)
        {
            // Not supported for File handle due to various file size
            return true;
        }

        /// <summary>
        /// Override function for decrypting a file
        /// </summary>
        /// <param name="fileInput">input file path</param>
        /// <param name="fileOutput">output file path</param>
        /// <returns></returns>
        public override bool Decrypt(string fileInput, string fileOutput)
        {
            // Not supported for File handle due to various file size
            return true;
        }     

        /// <summary>
        /// Public and Private key generation 
        /// </summary>
        /// <param name="privatePath">File path for saving Private Key</param>
        /// <param name="publicPath">File path for saving Public Key</param>
        public static void GenerateRSAKeys(string privatePath, string publicPath)
        {
            string privateKey = string.Empty;
            string publicKey  = string.Empty;

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(KEY_SIZE_FOR_MAX_TEXT_INPUT);
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

        /// <summary>
        /// Encrypt Text String
        /// </summary>
        /// <param name="plainText">plain text string input</param>
        /// <returns>encrypted string</returns>
        public override string Encrypt(string plainText)
        {
            byte[] plainTextBArray;
            byte[] cipherTextBArray;
            string cipherText = string.Empty;
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(KEY_SIZE_FOR_MAX_TEXT_INPUT);
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

        /// <summary>
        /// Decrypt the encrypted text input
        /// </summary>
        /// <param name="cipherText">encrypted text string input</param>
        /// <returns>decrypted string</returns>
        public override string Decrypt(string cipherText)
        {
            byte[] encryptedTextArray;
            byte[] decryptedTextBArray;
            string plainText = string.Empty;
            try
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(KEY_SIZE_FOR_MAX_TEXT_INPUT);
                rsa.FromXmlString(this.CryptionKey);
                encryptedTextArray = Convert.FromBase64String(cipherText);
                decryptedTextBArray = rsa.Decrypt(encryptedTextArray, false);
                plainText = (new UnicodeEncoding()).GetString(decryptedTextBArray);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return plainText;
        }
    }
}


