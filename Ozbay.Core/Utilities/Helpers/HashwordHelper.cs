﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace OZBAY.Core.Utilities.Helpers
{
    public class HashwordHelper : IDisposable
    {
        public static string GenerateSHA256String(string inputString)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes("/*!é'^+%&/()=?_" + inputString + "/*!é'^+%&/()=?_");
            byte[] hash = sha256.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        public static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes("/*!é'^+%&/()=?_" + inputString + "/*!é'^+%&/()=?_");
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
