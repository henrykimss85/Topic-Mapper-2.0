using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic_Mapper_2._0.files
{
    class Files
    {
        //create a file object to store file information 
        public int fileID;
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

        public void setFileID(int fileID)
        {
            this.fileID = fileID; 
        }

        public int getFileID()
        {
            return this.fileID;
        }
        public void setFileName(string fileName)
        {
            this.fileName = fileName;
        }

        public string getFileName()
        {
            return this.fileName;
        }

        public void setFilePath(string filePath)
        {
            this.filePath = filePath;
        }

        public string getFilePath()
        {
            return this.filePath;
        }

        public void setFileType(string fileType)
        {
            this.fileType = fileType;
        }

        public string getFileType()
        {
            return this.fileType;
        }

        public void setCreationDate(string creationDate)
        {
            this.creationDate = creationDate;
        }

        public string getCreationDate()
        {
            return this.creationDate;
        }
        public void setSummary(string summary)
        {
            this.summary = summary;
        }

        public string getSummary()
        {
            return this.summary;
        }

    }
}
