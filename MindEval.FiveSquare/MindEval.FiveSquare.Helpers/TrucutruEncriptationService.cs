using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MindEval.FiveSquare.Helpers
{
    public static class TrucutruEncriptationService
    {
        public static string Crypt(this string text)
        {
            string result = null;
            if (!String.IsNullOrEmpty(text))
            {
                byte[] plaintextBytes = Encoding.Unicode.GetBytes(text);

                SymmetricAlgorithm symmetricAlgorithm = DES.Create();
                symmetricAlgorithm.Key = new byte[8] { 1, 3, 3, 7, 4, 9, 0, 5 };
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plaintextBytes, 0, plaintextBytes.Length);
                    }
                    result = Encoding.Unicode.GetString(memoryStream.ToArray());
                }
            }
            return result;
        }
    }
}