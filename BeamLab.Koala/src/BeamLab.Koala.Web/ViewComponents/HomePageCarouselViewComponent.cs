using BeamLab.Koala.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeamLab.Koala.Web.ViewComponents
{
    public class HomePageCarouselViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int newsCount)
        {
            var items = await GetItemsAsync(newsCount);
            return View(items);
        }

        private Task<List<CarouselItem>> GetItemsAsync(int newsCount)
        {
            var items = new List<CarouselItem>();

            items.Add(new CarouselItem() { ID = 1, Title = "Slide 1", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras a ullamcorper nibh. Vivamus eget rhoncus metus, tempor tristique odio. Nullam nisl turpis, fringilla ut quam sit amet, aliquet venenatis sem.", Image = "http://upload.wikimedia.org/wikipedia/commons/5/55/Brno-Lesna_-_bytovy_dum_komplexu_Majdalenky_I_pri_Okruzni_ulici.jpg" });
            items.Add(new CarouselItem() { ID = 2, Title = "Slide 2", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras a ullamcorper nibh. Vivamus eget rhoncus metus, tempor tristique odio. Nullam nisl turpis, fringilla ut quam sit amet, aliquet venenatis sem.", Image = "https://upload.wikimedia.org/wikipedia/commons/8/8d/Majdalenky_3_%28Brno%29.jpg" });
            items.Add(new CarouselItem() { ID = 3, Title = "Slide 3", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras a ullamcorper nibh. Vivamus eget rhoncus metus, tempor tristique odio. Nullam nisl turpis, fringilla ut quam sit amet, aliquet venenatis sem.", Image = "http://upload.wikimedia.org/wikipedia/commons/3/30/Panel%C3%A1ky_Ko%C5%A1%C3%ADk.jpg" });

            return Task.Run(() => items);
        }
    }
}
