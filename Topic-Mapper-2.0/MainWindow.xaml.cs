using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Topic_Mapper_2._0.FS;
using Topic_Mapper_2._0.DB;
using Topic_Mapper_2._0.keywords;
using Topic_Mapper_2._0.files;
// MAKE SURE TO MYSQL.DATA IS IN REFERENCE 

namespace Topic_Mapper_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Enter MySql Database Information 
            Database db = new Database("Data Source", "Port", "Database", "Username", "Password");
            FileSystem fs = new FileSystem(Directory.GetCurrentDirectory());

            //Testing 
            Stack keywords = new Stack();
            Stack Files = new Stack();
            keywords = db.retrieveKeywords(2);
            Files = db.retrieveFiles(4);

        }
    }
}
