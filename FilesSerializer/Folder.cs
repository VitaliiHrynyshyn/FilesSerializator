using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilesSerializer
{
    [Serializable]
    class Folder : Node
    {
        public Folder(string fullPath)
        {
            this.name = new DirectoryInfo(fullPath).Name;
        }

        public override void Create(string directory)
        {
            string path = directory + "\\" + name;
            Directory.CreateDirectory(path);
        }
    }
}
