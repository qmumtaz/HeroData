using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HeroesController : Controller
    {
        private readonly HeroContext _dbcontext;
        private List<HeroDto> _heroList;

        public HeroesController()
        {
            _dbcontext = new HeroContext();
            _heroList = new List<HeroDto>();
        }

        public async Task<ActionResult> Index()
        {            
            var Dbexist = _dbcontext.Heroes.Any();

            if (!Dbexist)
            {
                for (int i = 1; i <= 24; i++)
                {
                    using (HttpClient client = new HttpClient())
                    using (HttpResponseMessage response = await client.GetAsync($"https://overwatch-api.net/api/v1/hero/{i}"))
                    using (HttpContent content = response.Content)
                    {
                        string json = await content.ReadAsStringAsync();

                        HeroDto hero = JsonConvert.DeserializeObject<HeroDto>(json);

                        _heroList.Add(hero);        
                    }
                }

                var heroDb = _heroList.Select(x => new Data.Models.Hero
                {
                    Name = x.Name,
                    Description = x.Description,
                    Health = x.Health
                }).ToList();
                _dbcontext.Heroes.AddRange(heroDb);
                _dbcontext.SaveChanges();

            }
            else {
                var heroes = _dbcontext.Heroes.ToList();

                foreach (var hero in heroes)
                {
                    _heroList.Add(new HeroDto()
                    {
                        Name = hero.Name,
                        Description = hero.Description,
                        Health = hero.Health
                    });
                }
            }

            var viewModels = _heroList.Select(x => new ViewModels.Hero
            {
                Name = x.Name,
                Description = x.Description,
                Health = x.Health
            }).ToList();

            var viewModel = new HeroViewModel
            {
                HeroList = viewModels
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Data.Models.Hero hero) {
            
                var HeroInDb = _dbcontext.Heroes.Single(c => c.Id == hero.Id);
                HeroInDb.Name = hero.Name;
                HeroInDb.Description = hero.Description;
                HeroInDb.Health = hero.Health;
  
            _dbcontext.SaveChanges();

            return RedirectToAction("Index", "Heroes");
        }
    
        public ActionResult Edit(int id )
        {
            var hero = _dbcontext.Heroes.SingleOrDefault(c => c.Id == id);

            if (hero == null)
                return HttpNotFound();

            var viewModel = new ViewModels.Hero
            {
                Name = hero.Name,
                Health = hero.Health,
                Description = hero.Description

            };

            return View("Edit" , viewModel);
        }

    }
}