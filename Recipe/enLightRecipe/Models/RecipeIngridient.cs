using static enLightRecipe.Models.Enums;

namespace enLightRecipe.Models
{
    public class RecipeIngridient
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public UnitOfMeasurement UnitOfMeasurment { get; set; }

        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        //Navigate
        public virtual Ingredient Ingredient { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}