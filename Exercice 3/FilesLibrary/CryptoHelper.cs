using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FilesLibrary
{
    public class CryptoHelper
    {
        public static string Decrypt(string encryptedText, string initialVector, string key)
        {
            byte[] keyByteArray = Encoding.UTF8.GetBytes(key);
            byte[] IV = Encoding.UTF8.GetBytes(initialVector);
            byte[] inputByteArray = new byte[encryptedText.Length];

            try
            {
                //key = Encoding.UTF8.GetBytes(strKey);
                DESCryptoServiceProvider ObjDES = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(encryptedText);

                MemoryStream Objmst = new MemoryStream();
                CryptoStream Objcs = new CryptoStream(Objmst, ObjDES.CreateDecryptor(keyByteArray, IV), CryptoStreamMode.Write);
                Objcs.Write(inputByteArray, 0, inputByteArray.Length);
                Objcs.FlushFinalBlock();

                Encoding encoding = Encoding.UTF8;
                return encoding.GetString(Objmst.ToArray());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
    }
}
