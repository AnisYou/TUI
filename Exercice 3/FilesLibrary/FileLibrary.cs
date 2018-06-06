using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading;
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

        public static XmlDocument ReadXmlFileInRole(string path, string role)
        {
            try
            {
                if (Thread.CurrentPrincipal.IsInRole(role))
                {
                    return ReadXmlFile(path);
                }
                throw new UnauthorizedAccessException();
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public static XmlDocument ReadEncryptedXmlFile(string path, string initialVector, string key)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(CryptoHelper.Decrypt(ReadTextFile(path), initialVector, key));
                return xmlDocument;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ReadTextFileInRole(string path, string role)
        {
            try
            {
                if (Thread.CurrentPrincipal.IsInRole(role))
                {
                    return ReadTextFile(path);
                }
                throw new UnauthorizedAccessException();
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public static JObject ReadJsonFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    return JObject.Parse(File.ReadAllText(path));

                }
                throw new FileNotFoundException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
