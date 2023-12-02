using GroceryApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroceryController : ControllerBase
    {
        private readonly ILogger<GroceryController> _logger;

        public GroceryController(ILogger<GroceryController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetGrocery")]
        public IEnumerable<Grocery> Get()
        {
            return null;
        }

    }
}
