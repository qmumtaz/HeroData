using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.Data.Models;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Repository
{
    public interface IHeroRepository
    {
        void SetupAsync();

        HeroViewModel returnviewModel();



       
    }
}