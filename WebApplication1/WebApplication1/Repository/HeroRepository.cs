using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Repository
{
    public class HeroRepository 
    {/*
        public void Setup()
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
            else
            {
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
        }*/
    }
}