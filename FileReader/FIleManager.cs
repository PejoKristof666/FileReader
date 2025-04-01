using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileReader
{
    public class FileManager
    {
        private string fileName;
        public FileManager(string fileName)
        {
            this.fileName = fileName;
        }

        public List<string> ReadFile()
        {
            List<string> all = new List<string>();
            try
            {
                all = File.ReadAllLines(fileName, Encoding.UTF8).Skip(1).ToList();
                //all.RemoveAt(all.Count-1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return all;
        }
    }
}
