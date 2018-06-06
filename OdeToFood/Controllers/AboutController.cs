using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{

    //[Route("company/[controller]/[action]")] //It can change the route to anything you want.
    [Route("about")]
    public class AboutController
    {
        [Route("")] // Makes the default action.
        public string Phone()
        {
            return "+55 11 456-789-123";
        }

        [Route("address")] //Makes the action when it been called.
        public string Address()
        {
            return "Brasil";
        }
    }
}
