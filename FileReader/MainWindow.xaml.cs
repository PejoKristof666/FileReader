using System;
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

namespace FileReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileManager file;
        int index = -1;
        List<Cars> all;
        public MainWindow()
        {
            InitializeComponent();
            file = new FileManager("data.txt");
            Start();
        }

        void Start()
        {
            
            all = file.ReadFile();
            everything.Children.Clear();
            foreach (Cars item in all)
            {
                Label oneLabel = new Label { Content = item.Model, FontSize = 20, Tag = item };
                oneLabel.MouseLeftButtonDown += CarClick;
                oneLabel.MouseRightButtonDown += EditClick;
                everything.Children.Add(oneLabel); ;
            }
        }
        void CarClick(object s, EventArgs e)
        {
            Label oneLabel = s as Label;
            Cars oneCar = oneLabel.Tag as Cars;
            MessageBox.Show($"Gyártó: {oneCar.Manufacturer}, Modell: {oneCar.Model}, Teljesítmény: {oneCar.Power}, Súly: {oneCar.Weight}");
        }
        void EditClick(object s, EventArgs e)
        {

            Label oneLabel = s as Label;
            Cars oneCar = oneLabel.Tag as Cars;

            index = all.IndexOf(oneCar);

            ManufacturerInput.Text = oneCar.Manufacturer;
            ModellInput.Text = oneCar.Model;
            PowerInput.Text = Convert.ToString(oneCar.Power);
            WeightInput.Text = Convert.ToString(oneCar.Weight);
            EditButton.IsEnabled = true;


        }
        void CreateEvent(object s, EventArgs e)
        {
            if (EditButton.IsEnabled)
            {
                EditButton.IsEnabled = false;
                ManufacturerInput.Text = "";
                ModellInput.Text = "";
                PowerInput.Text = "";
                WeightInput.Text = "";
                return;
            }
            string manufacturer = ManufacturerInput.Text;
            string model = ModellInput.Text;
            int power = -1;
            int weight = -1;
            if (!CheckEverything(manufacturer, model, ref power, ref weight))
            {
                return;
            }
            Cars oneCar = new Cars(manufacturer, model, power, weight);
            file.WriteOneLine(oneCar);
            Start();
        }

        void EditEvent(object s, EventArgs e)
        {
            all[index].Manufacturer = ManufacturerInput.Text;
            all[index].Model = ModellInput.Text;
            all[index].Power = int.Parse(PowerInput.Text);
            all[index].Weight = int.Parse(WeightInput.Text);
            file.WriteEverything(all);
            Start();
        }

        bool CheckEverything(string manufacturer, string model, ref int power, ref int weight)
        {
            string powerString = PowerInput.Text;
            string weightString = WeightInput.Text;

            if (manufacturer.Length < 2)
            {
                MessageBox.Show("Kérlek helyesen add meg a gyártót");
                return false;
            }
            if (model.Length < 2)
            {
                MessageBox.Show("Kérlek helyesen add meg a modellt");
                return false;
            }
            if (powerString.Length < 1)
            {
                MessageBox.Show("Kérlek add meg helyesen a teljesítményt");
                return false;
            }
            if (weightString.Length < 3)
            {
                MessageBox.Show("Add meg helyesen az autó súlyát");
                return false;
            }
            if (!int.TryParse(powerString, out power))
            {
                MessageBox.Show("A teljesítménynek számnak kell lennie!");
                return false;
            }
            if (!int.TryParse(weightString, out weight))
            {
                MessageBox.Show("A súlynak számnak kell lennie!");
                return false;
            }
            return true;
        }
    }
}
