using ContosoRecipe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoRecipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetRecipes([FromQuery] int count)
        {
            Recipe[] recipes = {
                new() {Title="Oxtail" }, 
                new() {Title="Curry chicken" },
                new() { Title = "Dumplings" }
            };

            if (!recipes.Any())
                return NotFound();
            return Ok(recipes.Take(count));
        }

        [HttpPost]
        public ActionResult CreateRecipe([FromBody] Recipe newRecipe)
        {
            bool BadThingHappened = false;

            // validate and save to database
            if (BadThingHappened)
                return BadRequest();

            return Created("", newRecipe);
        }

        [HttpPut]
        public ActionResult UpdateRecipe(int Id)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRecipe(int id) 
        {
            bool badThingHappened = false;

            if(badThingHappened)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
