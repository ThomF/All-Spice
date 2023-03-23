namespace AllSpice.Services;

    public class RecipesService
    {
        private readonly RecipeRepository _repo;

        public RecipesService(RecipeRepository repo)
        {
            _repo = repo;
        }

    internal List<Recipe> GetAllRecipes(string userId)
    {
        List<Recipe> recipes = _repo.GetAllRecipes();
        recipes = recipes.FindAll(r => r.CreatorId == userId);
        return recipes;
    }

    internal Recipe FindRecipeById(int id)
    {
        Recipe recipe = _repo.GetOne(id);
        if (recipe == null) throw new Exception("No Recipe!");
        return recipe;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _repo.CreateRecipe(recipeData);
        return recipe;
    }

}
