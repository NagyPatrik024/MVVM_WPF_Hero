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
using System.Windows.Shapes;
using WPF_Hero.Models;
using WPF_Hero.ViewModels;

namespace WPF_Hero
{
    /// <summary>
    /// Interaction logic for HeroCreatorWindow.xaml
    /// </summary>
    public partial class HeroCreatorWindow : Window
    {
        public Hero newHero { get; set; }
        public HeroCreatorWindow()
        {
            InitializeComponent(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            newHero = new Hero()
            {
                Name = name.Text,
                Power = int.Parse(power.Text),
                Speed = int.Parse(speed.Text),
                Side = (Side_enum)Enum.Parse(typeof(Side_enum), side.Text, true)
            };
            this.DialogResult = true;
        }
    }
}
