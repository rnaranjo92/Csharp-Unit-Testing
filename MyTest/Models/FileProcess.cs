using System;
using System.IO;

namespace MyClass.Models
{
    public class FileProcess
    {
        public bool FileExists(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");

            return File.Exists(fileName);
        }
    }
}