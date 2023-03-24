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

    internal string DeleteIngredient(int recipeId, Account userInfo)
    {
        Ingredient ingredient = _repo.FindByIngredient(recipeId);
        bool result = _repo.DeleteIngredient(recipeId);
        return "deleted";

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
