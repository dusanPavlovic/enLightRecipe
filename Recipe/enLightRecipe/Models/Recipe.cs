using System.Collections.Generic;
using static enLightRecipe.Models.Enums;

namespace enLightRecipe.Models
{
    public class Recipe
    {
        public Recipe()
        {
            RecipeIngridients = new List<RecipeIngridient>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public Category Category { get; set; }

        public string Tag { get; set; }

        // Navigation
        public virtual ICollection<RecipeIngridient> RecipeIngridients { get; set; }
    }
}