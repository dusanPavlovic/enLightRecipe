using System.Collections.Generic;
using System.Linq;
using static enLightRecipe.Models.Enums;

namespace enLightRecipe.Models
{
    public interface IRepository
    {
        IQueryable<Recipe> GetAllRecipes();

        Recipe GetRecipe(int id);

        List<Recipe> GetRecipeByCategory(Category category);

        IQueryable<Recipe> GetRecipeByIngredient(int IngredientId);

        RepositoryActionResult<Recipe> InsertRecipe(Recipe recipe);

        RepositoryActionResult<Recipe> UpdateRecipe(Recipe recipe);

        RepositoryActionResult<Recipe> DeleteRecipe(int id);

        void Save();

        bool RecipeExist(int id);
    }
}