using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Hero.Models
{
    public enum Side_enum { Good, Evil, Neutral };
    public class Hero : ObservableObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private int power;

        public int Power
        {
            get { return power; }
            set { SetProperty(ref power, value); }
        }

        private int speed;

        public int Speed
        {
            get { return speed; }
            set { SetProperty(ref speed, value); }
        }

        private Side_enum side;

        public Side_enum Side
        {
            get { return side; }
            set { SetProperty(ref side, value); }
        }

        public int Cost { get { return speed * power; } }

        public Hero GetCopy()
        {
            return new Hero()
            {
                Name = this.Name,
                Speed = this.Speed,
                Power = this.Power,
                Side = this.Side
            };
        }





    }
}
