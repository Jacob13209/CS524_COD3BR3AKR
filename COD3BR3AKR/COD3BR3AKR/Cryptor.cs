using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COD3BR3AKR
{
    public abstract class Cryptor
    {
        public string CryptionKey { get; set; }

        public Cryptor(string key)
        {
            this.CryptionKey = key;
        }

        public abstract string Encrypt( string textInput);
        public abstract string Decrypt( string textInput);

        public abstract bool Encrypt( string fileInput, string fileOutput);
        public abstract bool Decrypt( string fileInput, string fileOutput);
    }

    public class CryptionHelper
    {
        public static readonly string PUBLIC_KEY_PATH  = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\PublicKey.xml";
        public static readonly string PRIVATE_KEY_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\PrivateKey.xml";

        public string                       CustomizedKey       { get; set; }
        public SupportedAlogrithm           SelectedAlogrithm   { get; set; }

        private Cryptor cryptor;
        public CryptionHelper(string key, SupportedAlogrithm alogrithm)
        {
            this.CustomizedKey      = key;
            this.SelectedAlogrithm  = alogrithm;

            switch(this.SelectedAlogrithm)
            {
                case SupportedAlogrithm.AES:
                    cryptor = new AESCryption(this.CustomizedKey);
                    break;
                case SupportedAlogrithm.RSA:
                    cryptor = new RSACryption(this.CustomizedKey);
                    break;
                case SupportedAlogrithm.TripleDES:
                    cryptor = new TripleDESCryption(this.CustomizedKey);
                    break;
            }
        }

        ~CryptionHelper()
        {
            // destructor
        }

        public string Encrypt(string input)
        {
            return cryptor.Encrypt(input);
        }

        public bool Encrypt(string inputFile, string outputFile)
        {
            return cryptor.Encrypt(inputFile, outputFile);
        }

        public string Decrypt(string input)
        {           
            return cryptor.Decrypt(input);
        }

        public bool Decrypt(string inputFile, string outputFile)
        {
            return cryptor.Decrypt(inputFile, outputFile);
        }
    }
}
