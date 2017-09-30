using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic_Mapper_2._0.Navigation_Files
{
    class Files
    {
        //create a file object to store file information 
        public string fileName;
        public string filePath;
        public string fileType; // essentially file extension, is it a PDF doc, word doc, image etc. 
        public string creationDate;
        public string summary; // create summary from outside python program

        public Files()
        {
            //do nothing
        }
        public Files(string fName, string fPath, string fType, string cDate)
        {
            this.fileName = fName;
            this.filePath = fPath;
            this.fileType = fType;
            this.creationDate = cDate;
        }
    }
}
