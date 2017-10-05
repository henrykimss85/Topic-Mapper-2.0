using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic_Mapper_2._0.keywords

{
    class Keywords
    {
        private int ID;
        private string keyword;
        private int category;

        public Keywords()
        {

        }

        public Keywords(int ID, string keyword, int category)
        {
            this.ID = ID;
            this.keyword = keyword;
            this.category = category;
        }

        public void setID(int ID)
        {
            this.ID = ID;
        }

        public int getID()
        {
            return this.ID; 
        }

        public void setKeyword(string keyword)
        {
            this.keyword = keyword;
        }

        public string getKeyword()
        {
            return this.keyword;
        }

        public void setCategory(int category)
        {
            this.category = category;
        }

        public int getCategorye()
        {
            return this.category;
        }
    }
}
