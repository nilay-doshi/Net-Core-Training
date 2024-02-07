using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo_crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsAPIController : ControllerBase
    {
        public List<string> fruits = new List<string>()
        {
            "Apple",
            "Banana",
            "Mango",
            "Cherry",
            "Grapes"
        };

        [HttpGet]
        public ActionResult<List<string>> Getfruits()
        {
            return fruits;
        }

        [HttpGet("[Action]")]
        public ActionResult<string> GetfruitsByIndex([FromHeader] int id)
        {
            return fruits.ElementAt(id);
        }

        [HttpPut("")]
        public IActionResult UpdateFruit(int id ,[FromQuery] string updatedFruit)
        {
            fruits[id] = updatedFruit;
            return Ok(fruits);
        }

        [HttpPost]
        public IActionResult AddFruit([FromBody] string newFruit) 
        {
            fruits.Add(newFruit);
            return Ok(fruits);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteFruit(int id)
        {
            fruits.RemoveAt(id);
            return Ok(fruits);
        }

    }
}
