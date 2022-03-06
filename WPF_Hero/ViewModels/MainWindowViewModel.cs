using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_Hero.Logic;
using WPF_Hero.Models;

namespace WPF_Hero.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public ObservableCollection<Hero> Barrack { get; set; }
        public ObservableCollection<Hero> Army { get; set; }

        IHeroLogic logic;

        private Hero selectedFromBarrack;

        public Hero SelectedFromBarrack
        {
            get { return selectedFromBarrack; }
            set
            {
                SetProperty(ref selectedFromBarrack, value);
                (AddToArmyCommand as RelayCommand).NotifyCanExecuteChanged();
                (CreateHeroCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Hero selectedFromArmy;

        public Hero SelectedFromArmy
        {
            get { return selectedFromArmy; }
            set
            {
                SetProperty(ref selectedFromArmy, value);
                (RemoveFromArmyCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public double AVGPower { get { return logic.AVGPower; } }
        public double AVGSpeed { get { return logic.AVGSpeed; } }
        public int AllCost { get { return logic.AllCost; } }

        public ICommand AddToArmyCommand { get; set; }
        public ICommand RemoveFromArmyCommand { get; set; }
        public ICommand CreateHeroCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel() :
            this(IsInDesignMode ? null : Ioc.Default.GetService<IHeroLogic>())
        {

        }

        public MainWindowViewModel(IHeroLogic heroLogic)
        {
            logic = heroLogic;

            Barrack = new ObservableCollection<Hero>();
            Army = new ObservableCollection<Hero>();

            logic.SetupCollections(Barrack, Army);


            if (File.Exists("barrack.json"))
            {
                var barrack = JsonConvert.DeserializeObject<ObservableCollection<Hero>>(File.ReadAllText("barrack.json"));
                barrack.ToList().ForEach(x => Barrack.Add(x));
            }
            if (File.Exists("army.json"))
            {
                var army = JsonConvert.DeserializeObject<ObservableCollection<Hero>>(File.ReadAllText("army.json"));
                army.ToList().ForEach(x => Army.Add(x));
            }

            //Barrack.Add(new Hero()
            //{
            //    Name = "Emanuel",
            //    Side = Models.Side_enum.Neutral,
            //    Power = 8,
            //    Speed = 5
            //});

            //Barrack.Add(new Hero()
            //{
            //    Name = "Heszusz",
            //    Side = Models.Side_enum.Good,
            //    Power = 10,
            //    Speed = 1
            //});

            //Barrack.Add(new Hero()
            //{
            //    Name = "Devil",
            //    Side = Models.Side_enum.Evil,
            //    Power = 3,
            //    Speed = 2
            //});

            //Army.Add(Barrack[0].GetCopy());

            AddToArmyCommand = new RelayCommand(
                () => logic.AddToArmy(selectedFromBarrack),
                () => selectedFromBarrack != null
                );

            RemoveFromArmyCommand = new RelayCommand(
                () => logic.RemoveFromArmy(selectedFromArmy),
                () => selectedFromArmy != null
                );

            CreateHeroCommand = new RelayCommand(
                () => logic.CreateHero()
                );

            Messenger.Register<MainWindowViewModel, string, string>(this, "HeroInfo", (recipient, msg) =>
            {
                OnPropertyChanged("AVGPower");
                OnPropertyChanged("AVGSpeed");
                OnPropertyChanged("AllCost");
            });
        }

    }
}
