using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DownloadService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DownloadService" in both code and config file together.
    public class DownloadService : IDownloadService
    {
        public MyFile Download()
        {
            MyFile file = new MyFile();
            file.content = System.IO.File.ReadAllBytes(@"C:\PGM\Executables\Download\e-Commerce.pdf");
            file.Name = "myFileE-Commerce.pdf";
            return file;
        }

    }
}
