using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FilesSerializer
{
    public class FilesSerializer
    {
        private TreeNode<Node> tree { set; get; }

        public void Serialize(string folder, string file)
        {
            tree = new TreeNode<Node>(new Folder(folder));
            BinaryFormatter formatter = new BinaryFormatter();
            BuildTree(folder, tree);
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, tree);
            }
        }

        public void Deserialize(string folder, string file)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                tree = (TreeNode<Node>)formatter.Deserialize(fs);
                ReadTree(tree, folder);
            }
        }

        private void BuildTree(string sourceFolder, TreeNode<Node> root)
        {
            DirectoryInfo sourceDirectoryInfo = new DirectoryInfo(sourceFolder);
            foreach (var file in sourceDirectoryInfo.GetFiles())
            {
                root.AddChild(new File(sourceDirectoryInfo.FullName + "\\" + file.Name));
            }
            var directories = sourceDirectoryInfo.GetDirectories();
            foreach (var subdirectory in directories)
            {
                BuildTree(subdirectory.Name,
                    root.AddChild(new Folder(sourceDirectoryInfo.FullName + "\\" + subdirectory.Name)));
            }
        }

        private void ReadTree(TreeNode<Node> root, string destinationFolder)
        {
            root.GetNode().Create(destinationFolder);
            foreach (var file in root.GetChildren())
            {
                ReadTree(file, destinationFolder + $"\\{root.GetNode().name}");
            }
        }
    }
}
