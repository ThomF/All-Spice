namespace AllSpice.Repositories;

public class RecipeRepository
    {
        private readonly IDbConnection _db;

    public RecipeRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        string sql = @"
        INSERT INTO recipes
        (creatorId, title, instructions, img, category)
        VALUES
        (@creatorId, @title, @instructions, @img, @category);
        SELECT LAST_INSERT_ID();
        ";
        int id = _db.ExecuteScalar<int>(sql, recipeData);
        recipeData.Id = id;
        return recipeData;
    }

    internal List<Recipe> GetAllRecipes()
    {
        string sql = @"
        SELECT 
        rec.*,
        act.*
        FROM recipes rec
        JOIN accounts act ON rec.creatorId = act.id;
        ";
        List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, prof)=> 
        {
            recipe.Creator = prof;
            return recipe;
        }).ToList();
        return recipes;
    }
}
