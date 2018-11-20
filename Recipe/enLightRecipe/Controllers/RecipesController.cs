using enLightRecipe.Models;
using System;
using System.Linq;
using System.Web.Http;
using static enLightRecipe.Models.Enums;

namespace enLightRecipe.Controllers
{
    public class RecipesController : ApiController
    {
        private IRepository _repo;

        public RecipesController(IRepository repo)
        {
            _repo = repo;
        }

        // return all recipes

        // GET api/Recipes
        public IHttpActionResult Get()
        {
            try
            {
                var recipes = _repo.GetAllRecipes();
                return Ok(recipes.ToList());
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // return recipe by id

        // GET api/Recipes/{id}
        public IHttpActionResult Get(int id)
        {
            try
            {
                var recipe = _repo.GetRecipe(id);
                if (recipe == null)
                {
                    return NotFound();

                }
                else
                {
                    return Ok(recipe);
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // return recepies by Category
        public IHttpActionResult GetRecipeByCategory(Category category)
        {
            try
            {
                var recipes = _repo.GetRecipeByCategory(category);
                if (recipes == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(recipes);
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // return all recipes which contain given Ingredient id
        public IHttpActionResult GetRecipeByIngridient(int IngredientId)
        {
            try
            {
                var recipes = _repo.GetRecipeByIngredient(IngredientId);
                if (recipes == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(recipes);
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // insert recipe

        // api/Recipes
        [HttpPost]
        public IHttpActionResult Post([FromBody]Recipe recipe)
        {
            try
            {
                if (recipe == null)
                {
                    return BadRequest();
                }

                var result = _repo.InsertRecipe(recipe);
                if (result.Status == RepositoryActionStatus.Created)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // update recipe
        public IHttpActionResult Put(Recipe recipe)
        {
            try
            {
                if (recipe == null)
                {
                    return BadRequest();
                }

                var result = _repo.UpdateRecipe(recipe);
                if (result.Status == RepositoryActionStatus.Updated)
                {
                    return Ok();
                }
                else if (result.Status == RepositoryActionStatus.NotFound)
                {
                    return NotFound();
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // delete recipe
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var result = _repo.DeleteRecipe(id);
                if (result.Status == RepositoryActionStatus.Deleted)
                {
                    return StatusCode(System.Net.HttpStatusCode.NoContent);
                }
                else if (result.Status == RepositoryActionStatus.NotFound)
                {
                    return NotFound();
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}