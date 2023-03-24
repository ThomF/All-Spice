namespace AllSpice.Services;

public class IngredientsService
    {
        private readonly IngredientRepository _repo;

    public IngredientsService(IngredientRepository repo)
    {
        _repo = repo;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        Ingredient ingredient = _repo.CreateIngredient(ingredientData);
        return ingredient;
    }

    internal List<Ingredient> FindIngredient(int recipeId)
        {
            List<Ingredient> ingredients = _repo.FindIngredient(recipeId);
            return ingredients;
        }

    // internal List<Ingredient> FindByRecipe(int recipeId)
    // {
    //     List<Ingredient> ingredients = _repo.FindByRecipe(recipeId);
    //     return ingredients;
    // }

    }
