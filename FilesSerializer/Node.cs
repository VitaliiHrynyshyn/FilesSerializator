using System;
using System.Collections.Generic;
using System.Text;

namespace FilesSerializer
{
    [Serializable]
    abstract class Node
    {
        public string name;

        public abstract void Create(string directory);
    }
}
