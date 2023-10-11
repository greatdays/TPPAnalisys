using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Models.IDM
{
    public static class CryptoHelper
    {
        private static string passPhrase = "Pas5pr@se"; // can be any string
        private static string saltValue = "{3Di-Inc-USA}";        // can be any string
        private static string hashAlgorithm = "SHA1";             // can be "MD5"
        private static int passwordIterations = 2;                // can be any number
        private static string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
        private static int keySize = 256;                // can be 192 or 128

        public static string Encrypt(string plainText)
        {
            string cipherText = RijndaelSymmetricKey.Encrypt
           (
               plainText,
               passPhrase,
               saltValue,
               hashAlgorithm,
               passwordIterations,
               initVector,
               keySize
           );
            return cipherText;
        }
        public static string Decrypt(string cipherText)
        {
            string plainText = RijndaelSymmetricKey.Decrypt
            (
                cipherText,
                passPhrase,
                saltValue,
                hashAlgorithm,
                passwordIterations,
                initVector,
                keySize
            );
            return plainText;
        }
    }
}
