using System.Collections.Generic;
using System.Data.Entity;

namespace enLightRecipe.Models
{
    public class enLightRecipeContextInitializer : DropCreateDatabaseAlways<enLightRecipeContext>
    {
        protected override void Seed(enLightRecipeContext context)
        {
            var ingredients = new List<Ingredient>
            {
                new Ingredient() { Name = "Brasno" },
                new Ingredient() { Name = "Kvasac" },
                new Ingredient() { Name = "Mleko" },
                new Ingredient() { Name = "Mast" },
                new Ingredient() { Name = "Slanina" },
                new Ingredient() { Name = "Krompir" },
                new Ingredient() { Name = "Meso" },
                new Ingredient() { Name = "Secer" }
            };

            ingredients.ForEach(i => context.Ingredients.Add(i));
            context.SaveChanges();

            //  recipe 01

            var recipe = new Recipe() { Name = "Pasulj", Category = Enums.Category.Main, Tag = "Masno i ukusno", Description = "sve u veliki kotlic i kuvati zajdeno 2h" };
            var ingredientsForRecipe = new List<RecipeIngridient>()
            {
                new RecipeIngridient() { Ingredient= ingredients[4], Amount = 2, UnitOfMeasurment= Enums.UnitOfMeasurement.Kg, Recipe = recipe  },
                 new RecipeIngridient() { Ingredient= ingredients[5], Amount = 100, UnitOfMeasurment= Enums.UnitOfMeasurement.g, Recipe = recipe  },
                  new RecipeIngridient() { Ingredient= ingredients[6], Amount = 4, UnitOfMeasurment= Enums.UnitOfMeasurement.Cup, Recipe = recipe  },
                   new RecipeIngridient() { Ingredient= ingredients[3], Amount = 6, UnitOfMeasurment= Enums.UnitOfMeasurement.Cup, Recipe = recipe  }
            };
            context.Recipes.Add(recipe);
            ingredientsForRecipe.ForEach(ir => context.RecipeIngridients.Add(ir));
            context.SaveChanges();

            //  recipe 02

            recipe = new Recipe() { Name = "Torta", Category = Enums.Category.Desert, Tag = "Slatko za rodjendane", Description = "fil, voce, fil i onda slag" };
            ingredientsForRecipe = new List<RecipeIngridient>()
            {
                new RecipeIngridient() { Ingredient= ingredients[0], Amount = 2, UnitOfMeasurment= Enums.UnitOfMeasurement.Kg, Recipe = recipe  },
                 new RecipeIngridient() { Ingredient= ingredients[1], Amount = 100, UnitOfMeasurment= Enums.UnitOfMeasurement.g, Recipe = recipe  },
                  new RecipeIngridient() { Ingredient= ingredients[3], Amount = 4, UnitOfMeasurment= Enums.UnitOfMeasurement.Cup, Recipe = recipe  }
            };
            context.Recipes.Add(recipe);
            ingredientsForRecipe.ForEach(ir => context.RecipeIngridients.Add(ir));
            context.SaveChanges();

            //  recipe 03
            recipe = new Recipe() { Name = "Gibanica", Category = Enums.Category.Starter, Tag = "Slano nedeljno testo", Description = "brsno mesati sa mlekom i dodati kvasac, sir i peci u rerni" };
            ingredientsForRecipe = new List<RecipeIngridient>()
            {
                new RecipeIngridient() { Ingredient= ingredients[0], Amount = 1, UnitOfMeasurment= Enums.UnitOfMeasurement.Kg, Recipe = recipe  },
                 new RecipeIngridient() { Ingredient= ingredients[1], Amount = 100, UnitOfMeasurment= Enums.UnitOfMeasurement.g, Recipe = recipe  },
                  new RecipeIngridient() { Ingredient= ingredients[3], Amount = 4, UnitOfMeasurment= Enums.UnitOfMeasurement.Cup, Recipe = recipe  },
                   new RecipeIngridient() { Ingredient= ingredients[6], Amount = 10, UnitOfMeasurment= Enums.UnitOfMeasurement.g, Recipe = recipe  }
            };
            context.Recipes.Add(recipe);
            ingredientsForRecipe.ForEach(ir => context.RecipeIngridients.Add(ir));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}