namespace AllSpice.Services;

    public class RecipesService
    {
        private readonly RecipeRepository _repo;

        public RecipesService(RecipeRepository repo)
        {
            _repo = repo;
        }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _repo.CreateRecipe(recipeData);
        return recipe;
    }
}
