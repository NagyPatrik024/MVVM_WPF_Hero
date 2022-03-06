using System.Collections.Generic;
using WPF_Hero.Models;

namespace WPF_Hero.Logic
{
    public interface IHeroLogic
    {
        int AllCost { get; }
        double AVGPower { get; }
        double AVGSpeed { get; }

        void AddToArmy(Hero hero);
        void CreateHero();
        void RemoveFromArmy(Hero hero);
        void SetupCollections(IList<Hero> barrack, IList<Hero> army);
    }
}