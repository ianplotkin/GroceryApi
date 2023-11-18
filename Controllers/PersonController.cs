using Microsoft.AspNetCore.Mvc;

namespace GroceryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly List<Person> people = new List<Person>();

        public PersonController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            people.Add(new Person { FirstName = "Ian" });
            people.Add(new Person { FirstName = "Annaleigh" });
        }

        [HttpGet(Name = "GetPerson")]
        public IEnumerable<Person> Get()
        {
            return people.ToArray();
        }
    }
}
