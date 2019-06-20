using System;
using System.Security.Cryptography;
using System.Text;

namespace Instagram_Private_API.src
{
    class Signatures
    {
        public static Encoding UTF8E = Encoding.UTF8;

        public static string generateUUID(bool type)
        {
            if (type)
                return Guid.NewGuid().ToString("D");
            else
                return Guid.NewGuid().ToString("D").Replace("-", "");
        }

        public static string generateDeviceId(string source)
        {
            return "android-" + GetMd5Hash(MD5.Create(), GetMd5Hash(MD5.Create(), source) + "12345").Substring(0, 16);
        }

        public static string HMAC(string String, string Key)
        {
            var keyByte = UTF8E.GetBytes(Key);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                hmacsha256.ComputeHash(UTF8E.GetBytes(String));
                return ByteToString(hmacsha256.Hash).ToLower();
            }
        }

        public static string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
                sbinary += buff[i].ToString("X2");
            return sbinary;
        }

        public static string EncodeUrl(string Url)
        {
            return Uri.EscapeDataString(Url);
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
