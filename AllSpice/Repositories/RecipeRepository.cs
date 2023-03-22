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
        INSERT INTO albums
        (creatorId, title, instructions, img, category)
        VALUES
        (@creatorId, @title, @instructions, @img, @category)
        SELECT LAST_INSERT_ID();
        ";
        int id = _db.ExecuteScalar<int>(sql, recipeData);
        recipeData.Id = id;
        return recipeData;
    }
}
