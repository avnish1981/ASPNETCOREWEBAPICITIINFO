using System.Linq;
using System.Web.Http;
using CityInfoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CityInfoAPI.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController :   ControllerBase 
    {
       //[HttpGet("api/cities")]
       [HttpGet]
        public IActionResult  GetCities()
        {
            //return new JsonResult(new List<dynamic>
            //{
            //    new {id=1,cities="Mumbai"},
            //    new {id=2,cities="Delhi"}
            //});
            var model = CityDataStore.Current.Cities;
            return Ok(model); 
        }
        [HttpGet("{id}")]
        public IActionResult GetCityById(int id)
        {
            var result = CityDataStore.Current.Cities.FirstOrDefault(x => x.Id == id);

            if(result==null )
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}