using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using WPF_Hero.Models;
using WPF_Hero.ViewModels;

namespace WPF_Hero
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
           
            string jsonData = JsonConvert.SerializeObject((this.DataContext as MainWindowViewModel).Barrack);
            File.WriteAllText("barrack.json", jsonData);

            string jsonData2 = JsonConvert.SerializeObject((this.DataContext as MainWindowViewModel).Army);
            File.WriteAllText("army.json", jsonData);

        }
    }
}
