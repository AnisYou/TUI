using System;
using System.IO;

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
    }
}
