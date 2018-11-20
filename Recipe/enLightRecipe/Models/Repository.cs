using System.Collections.Generic;
using System.Linq;
using static enLightRecipe.Models.Enums;

namespace enLightRecipe.Models
{
    public class Repository : IRepository
    {
        private enLightRecipeContext db;

        public Repository(enLightRecipeContext db)
        {
            this.db = db;
        }

        public IQueryable<Recipe> GetAllRecipes()
        {
            return db.Recipes;
        }

        public Recipe GetRecipe(int id)
        {
            return db.Recipes.Include("RecipeIngridients.Ingredient")
                .FirstOrDefault(r => r.Id == id);
        }

        public List<Recipe> GetRecipeByCategory(Category category)
        {
            List<Recipe> recipeList;
            recipeList = db.Recipes.Where(x => x.Category == category).ToList();
            return recipeList;
        }

        public IQueryable<Recipe> GetRecipeByIngredient(int IngredientId)
        {
            var query = from r in db.Recipes
                        join o in db.RecipeIngridients on r.Id equals o.RecipeId
                        where o.IngredientId == IngredientId
                        select r;
            return query;
        }

        public RepositoryActionResult<Recipe> InsertRecipe(Recipe recipe)
        {
            try
            {
                db.Recipes.Add(recipe);
                var result = db.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Recipe>(recipe, RepositoryActionStatus.Created);
                }
                else
                {
                    return new RepositoryActionResult<Recipe>(recipe, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (System.Exception ex)
            {
                return new RepositoryActionResult<Recipe>(null, RepositoryActionStatus.Error, ex);
            }
        }

        public RepositoryActionResult<Recipe> UpdateRecipe(Recipe recipe)
        {
            try
            {
                // you can only update when an expense already exists for this id
                var existingRecipe = db.Recipes.FirstOrDefault(r => r.Id == recipe.Id);
                if (existingRecipe == null)
                {
                    return new RepositoryActionResult<Recipe>(recipe, RepositoryActionStatus.NotFound);
                }

                // change the original entity status to detached; otherwise, we get an error on attach
                // as the entity is already in the dbSet

                // set original entity state to detached
                db.Entry(existingRecipe).State = System.Data.Entity.EntityState.Detached;

                db.Recipes.Attach(recipe);

                // set the updated entity state to modified, so it gets updated.
                db.Entry(recipe).State = System.Data.Entity.EntityState.Modified;

                var result = db.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Recipe>(recipe, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<Recipe>(recipe, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (System.Exception ex)
            {
                return new RepositoryActionResult<Recipe>(null, RepositoryActionStatus.Error, ex);
            }
        }

        public RepositoryActionResult<Recipe> DeleteRecipe(int id)
        {
            try
            {
                var recipe = db.Recipes.Where(r => r.Id == id).FirstOrDefault();
                if (recipe != null)
                {
                    db.Recipes.Remove(recipe);
                    db.SaveChanges();
                    return new RepositoryActionResult<Recipe>(null, RepositoryActionStatus.Deleted);
                }

                return new RepositoryActionResult<Recipe>(null, RepositoryActionStatus.NotFound);
            }
            catch (System.Exception ex)
            {
                return new RepositoryActionResult<Recipe>(null, RepositoryActionStatus.Error, ex);
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public bool RecipeExist(int id)
        {
            return db.Recipes.Count(e => e.Id == id) > 0;
        }
    }
}