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
        return recipes;
    }

    internal Recipe FindRecipeById(int id, string userId)
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

    internal Recipe UpdateRecipe(int id, Recipe updateData, Account userInfo)
    {
        Recipe original = this.FindRecipeById(id, userInfo.Id);
        if(original.CreatorId != userInfo.Id) throw new Exception("You cant be here!");
        original.Title = updateData.Title != null ? updateData.Title : original.Title;
        original.Instructions = updateData.Instructions != null ? updateData.Instructions : original.Instructions;
        original.Img = updateData.Img != null ? updateData.Img : original.Img;
        original.Category = updateData.Category != null ? updateData.Category : original.Category;
        int rowsAffected = _repo.UpdateRecipe(original);
        if(rowsAffected == 0) throw new Exception($"Couldnt update the recipe with id: {updateData.Id}");
        if(rowsAffected > 1) throw new Exception($"something just broke, what did you do?? You made at least {rowsAffected} of recipes. Check the DB NOW!!! OOPS!");
        return original;
    }

    internal String DeleteRecipe(int id, Account userInfo)
    {
        Recipe recipe = this.FindRecipeById(id, userInfo.Id);
        bool result = _repo.DeleteRecipe(id);
        if(recipe.CreatorId != userInfo.Id) throw new Exception($"Something went really really wrong.");
        return $"deleted the recipe: {recipe.Title}";
    }
}
