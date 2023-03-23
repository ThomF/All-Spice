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


    internal Recipe GetOne(int id)
    {
        string sql = @"
        SELECT
        rec.*,
        act.*
        FROM recipes rec
        JOIN accounts act ON rec.creatorId = act.id
        WHERE rec.id = @id;
        ";
        Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, prof) =>
        {
            recipe.Creator = prof;
            return recipe;
        }, new { id }).FirstOrDefault();
        return recipe;
    }

    internal int UpdateRecipe(Recipe update)
    {
        string sql = @"
        UPDATE recipes
        SET
        title = @title,
        instructions = @instructions,
        img = @img,
        category = @category
        WHERE id = @id;
        ";
        int rows = _db.Execute(sql, update);
        return rows;
    }

    internal bool DeleteRecipe(int id)
    {
        string sql = @"
        DELETE FROM recipes WHERE id = @id;
        ";
        int rows = _db.Execute(sql, new {id});
        return rows == 1;
    }
}
