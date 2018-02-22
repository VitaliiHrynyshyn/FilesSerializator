using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilesSerializer
{
    [Serializable]
    class File : Node
    {
        private byte[] content;

        public File(string fullPath)
        {
            this.name = new FileInfo(fullPath).Name;
            content = System.IO.File.ReadAllBytes(fullPath);
        }

        public override void Create(string directory)
        {
            string path = directory + "\\" + name;
            System.IO.File.WriteAllBytes(path, this.content);
        }
    }
}
