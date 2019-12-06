using System;

namespace Helpers
{
    public class ReadFile
    {
        public string[] ReturnStringArray(string fileLocation)
        {
            string path = System.IO.Path.GetFullPath(@"data");
            return System.IO.File.ReadAllLines($"{path}/{fileLocation}");
        }
    }
}
