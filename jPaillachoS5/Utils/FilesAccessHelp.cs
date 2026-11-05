using System;
using System.Collections.Generic;
using System.Text;

namespace jPaillachoS5.Utils
{
    public class FilesAccessHelp
    {
        public static string GetLocalFilePath(string filename)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        }
    }
}
