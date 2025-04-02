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

        public List<Cars> ReadFile()
        {
            List<Cars> all = new List<Cars>();
            try
            {
                foreach(string line in File.ReadAllLines(fileName, Encoding.UTF8).Skip(1))
                {
                    all.Add(new Cars(line));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return all;
        }

        public void WriteOneLine(Cars oneCar)
        {
            using (StreamWriter write = new StreamWriter(fileName,true , Encoding.UTF8))
            {
                write.Write($"\n{oneCar.Manufacturer};{oneCar.Model};{oneCar.Power};{oneCar.Weight}");
            }
        }

        public void WriteEverything(List<Cars> all)
        {
            using (StreamWriter write = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                write.WriteLine("Random első sor");
                for (int i = 0; i < all.Count-1; i++)
                {
                    write.WriteLine($"{all[i].Manufacturer};{all[i].Model};{all[i].Power};{all[i].Weight}");
                }
                write.WriteLine($"{all.Last().Manufacturer};{all.Last().Model};{all.Last().Power};{all.Last().Weight}");
            }
        }
    }
}
