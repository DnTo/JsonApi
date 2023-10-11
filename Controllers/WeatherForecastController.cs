using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

namespace jsonApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }


    [HttpGet("json")]
    public ActionResult<ComplexFilters> GetWithJson([FromQuery]string filters)
    {
        var decoded = HttpUtility.UrlDecode(filters);
        var myFilters = JsonSerializer.Deserialize<ComplexFilters>(decoded);
        return (myFilters);
    }


    //data de ejemplo

    /*
     data:

    [
  {"idCategoria": 1, "idSubcategoria": 10},
  {"idCategoria": 2, "idSubcategoria": 11},
  {"idCategoria": 3, "idSubcategoria": 12},
  {"idCategoria": 4, "idSubcategoria": 13},
  {"idCategoria": 5, "idSubcategoria": 14},
  {"idCategoria": 6, "idSubcategoria": 15},
  {"idCategoria": 7, "idSubcategoria": 16},
  {"idCategoria": 8, "idSubcategoria": 17},
  {"idCategoria": 9, "idSubcategoria": 18},
  {"idCategoria": 10, "idSubcategoria": 19},
  {"idCategoria": 11, "idSubcategoria": 20},
  {"idCategoria": 12, "idSubcategoria": 21},
  {"idCategoria": 13, "idSubcategoria": 22},
  {"idCategoria": 14, "idSubcategoria": 23},
  {"idCategoria": 15, "idSubcategoria": 24},
  {"idCategoria": 16, "idSubcategoria": 25},
  {"idCategoria": 17, "idSubcategoria": 26},
  {"idCategoria": 18, "idSubcategoria": 27},
  {"idCategoria": 19, "idSubcategoria": 28},
  {"idCategoria": 20, "idSubcategoria": 29}
]

    encoded
     
     %5B%0A%20%20%7B%22idCategoria%22%3A%201%2C%20%22idSubcategoria%22%3A%2010%7D%2C%0A%20%20%7B%22idCategoria%22%3A%202%2C%20%22idSubcategoria%22%3A%2011%7D%2C%0A%20%20%7B%22idCategoria%22%3A%203%2C%20%22idSubcategoria%22%3A%2012%7D%2C%0A%20%20%7B%22idCategoria%22%3A%204%2C%20%22idSubcategoria%22%3A%2013%7D%2C%0A%20%20%7B%22idCategoria%22%3A%205%2C%20%22idSubcategoria%22%3A%2014%7D%2C%0A%20%20%7B%22idCategoria%22%3A%206%2C%20%22idSubcategoria%22%3A%2015%7D%2C%0A%20%20%7B%22idCategoria%22%3A%207%2C%20%22idSubcategoria%22%3A%2016%7D%2C%0A%20%20%7B%22idCategoria%22%3A%208%2C%20%22idSubcategoria%22%3A%2017%7D%2C%0A%20%20%7B%22idCategoria%22%3A%209%2C%20%22idSubcategoria%22%3A%2018%7D%2C%0A%20%20%7B%22idCategoria%22%3A%2010%2C%20%22idSubcategoria%22%3A%2019%7D%2C%0A%20%20%7B%22idCategoria%22%3A%2011%2C%20%22idSubcategoria%22%3A%2020%7D%2C%0A%20%20%7B%22idCategoria%22%3A%2012%2C%20%22idSubcategoria%22%3A%2021%7D%2C%0A%20%20%7B%22idCategoria%22%3A%2013%2C%20%22idSubcategoria%22%3A%2022%7D%2C%0A%20%20%7B%22idCategoria%22%3A%2014%2C%20%22idSubcategoria%22%3A%2023%7D%2C%0A%20%20%7B%22idCategoria%22%3A%2015%2C%20%22idSubcategoria%22%3A%2024%7D%2C%0A%20%20%7B%22idCategoria%22%3A%2016%2C%20%22idSubcategoria%22%3A%2025%7D%2C%0A%20%20%7B%22idCategoria%22%3A%2017%2C%20%22idSubcategoria%22%3A%2026%7D%2C%0A%20%20%7B%22idCategoria%22%3A%2018%2C%20%22idSubcategoria%22%3A%2027%7D%2C%0A%20%20%7B%22idCategoria%22%3A%2019%2C%20%22idSubcategoria%22%3A%2028%7D%2C%0A%20%20%7B%22idCategoria%22%3A%2020%2C%20%22idSubcategoria%22%3A%2029%7D%0A%5D
     
     */

}
