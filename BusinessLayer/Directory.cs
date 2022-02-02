using System.IO;
using System;

namespace BusinessLayer
{
    public class Directory
    {
        public DirectoryInfo  GetDirectoryDetails(string path)
        {
            try
            {
                var pathConfigure = @path;
                var directory = new DirectoryInfo(pathConfigure);
                return directory;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
