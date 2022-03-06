using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Hero.Models;
using WPF_Hero.Services;

namespace WPF_Hero.Logic
{
    public class HeroLogic : IHeroLogic
    {
        IList<Hero> barrack;
        IList<Hero> army;
        IMessenger messenger;
        IHeroCreatorViaWindows creatorService;

        public double AVGPower { get { return army.Count == 0 ? 0 : army.Average(h => h.Power); } }
        public double AVGSpeed { get { return army.Count == 0 ? 0 : army.Average(h => h.Speed); } }
        public int AllCost { get { return army.Count == 0 ? 0 : army.Sum(h => h.Cost); } }

        public HeroLogic(IMessenger messenger, IHeroCreatorViaWindows creatorService)
        {
            this.messenger = messenger;
            this.creatorService = creatorService;
        }
        public void SetupCollections(IList<Hero> barrack, IList<Hero> army)
        {
            this.barrack = barrack;
            this.army = army;
        }

        public void AddToArmy(Hero hero)
        {
            army.Add(hero);
            messenger.Send("Added to army!", "HeroInfo");
        }
        public void RemoveFromArmy(Hero hero)
        {
            army.Remove(hero);
            messenger.Send("Removed from army!", "HeroInfo");

        }
        public void CreateHero()
        {
            Hero hero = creatorService.Create();
            if (hero != null)
            {
                barrack.Add(hero);
            }
            
        }


    }
}
