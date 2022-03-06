using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Hero.Models;

namespace WPF_Hero.Services
{
    public class HeroCreatorViaWindows : IHeroCreatorViaWindows
    {
        public Hero Create()
        {
            var hWindow = new HeroCreatorWindow();
            hWindow.ShowDialog();
            if (hWindow.DialogResult == true)
            {
                return hWindow.newHero;
            }
            else
            {
                return null;
            }
        }

    }
}
