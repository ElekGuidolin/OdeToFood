using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Restaurant
            {
                Id = 1,
                Name = "Elaine's Place"
            };

            //return new ObjectResult(model);

            // I knew it ! LOL !
            // Basically I'll ever return a view from here, sending to it the brand new value of the model as a parameter.

            return View(model);
        }
    }
}
