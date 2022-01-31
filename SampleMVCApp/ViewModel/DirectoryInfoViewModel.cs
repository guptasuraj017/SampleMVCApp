using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SampleMVCApp.ViewModel
{
    public class DirectoryInfoViewModel
    {
        public List<FileInfo> FileList{ get; set; }
        public List<DirectoryInfo> DierecotoryList { get; set; }
    }
}