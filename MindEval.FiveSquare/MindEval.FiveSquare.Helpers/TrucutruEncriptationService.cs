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
                byte[] data = Encoding.UTF8.GetBytes(text);

                result = Convert.ToBase64String(data);
            }
            return result;
        }
    }
}