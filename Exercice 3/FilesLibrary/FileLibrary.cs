using System;
using System.IO;
using System.Xml;

namespace FilesLibrary
{
    public class FileLibrary
    {
        public static string ReadTextFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    return File.ReadAllText(path);
                }
                throw new FileNotFoundException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static XmlDocument ReadXmlFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    return doc;
                }
                throw new FileNotFoundException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ReadEncryptedTextFile(string path, string initialVector, string key)
        {
            try
            {
                return CryptoHelper.Decrypt(ReadTextFile(path), initialVector, key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
