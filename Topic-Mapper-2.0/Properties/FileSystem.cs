using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic_Mapper_2._0.files;
using Topic_Mapper_2._0.DB;

namespace Topic_Mapper_2._0.FS
{
    class FileSystem
    {
        private string rootDirectory;
        Stack fileStack = new Stack();// create a stack to hold file objects as they are pulled from filesystem. 
        // store a list of acceptalbe file types that can be added to the system. 
        //We want to ignore useless files such as .dll, .swp. etc.
        private String[] fileTypes = { ".jpg", ".png", ".xls", ".xlxs", ".pdf", ".doc", ".txt" };

        public FileSystem(String directory)
        {
            //take in directory location and assign it to rootDirectory
            rootDirectory = directory;
        }

        public void listFileSystem()
        {
            //this is a wrapper for passing the root directory to traverseFIleSystem for first ru
            this.traverseFileSystem(rootDirectory);
        }

        public void traverseFileSystem(string localDirectory)
        {
            //traverse file system starting in root directory
            //for every file add it to a file object then add that file object to a stack

            try
            {
                foreach (string dir in Directory.GetDirectories(localDirectory))
                {
                    foreach (string f in Directory.GetFiles(dir))
                    {
                        string filename = f.Substring(dir.Length + 1);

                        //Create a file object to add to stack.
                        Files file = new Files(filename, dir, Path.GetExtension(f), File.GetCreationTime(f).ToString());

                        fileStack.Push(file);
                    }
                    traverseFileSystem(dir);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }

        }

        public void printStack()
        {
            foreach (Files item in fileStack)
            {
                Console.WriteLine("File Name: " + item.fileName + "\nFile Path: " + item.filePath + "\nFile Type: " + item.fileType + "\nCreation Date: " + item.creationDate + "\n\n");
            }
        }
    }
}
