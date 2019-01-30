using System.Collections.Generic;

namespace WebApplication1.ViewModels
{
    public class HeroViewModel
    {
        public List<Hero> HeroList { get; set; }
    }

    public class Hero
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Health { get; set; }
    }
}