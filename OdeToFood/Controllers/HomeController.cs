using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            var model = _restaurantData.GetAll();
            
            //var model = new Restaurant
            //{
            //    Id = 1,
            //    Name = "Elaine's Place"
            //};

            //return new ObjectResult(model);

            // I knew it ! LOL !
            // Basically I'll ever return a view from here, sending to it the brand new value of the model as a parameter.

            return View(model);
        }
    }
}
