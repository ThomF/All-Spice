namespace AllSpice.Repositories;

public class IngredientRepository
    {
        private readonly IDbConnection _db;

    public IngredientRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        string sql = @"
        INSERT INTO ingredients
        (name, quantity, recipeId)
        VALUES
        (@name, @quantity, @recipeId);
        SELECT LAST_INSERT_ID();
        ";
        int id = _db.ExecuteScalar<int>(sql, ingredientData);
        ingredientData.Id = id;
        return ingredientData;
    }

    internal bool DeleteIngredient(int recipeId)
    {
        string sql = @"
        DELETE FROM ingredients WHERE id = @recipeId;
        ";
        int rows = _db.Execute(sql, new { recipeId });
        return rows == 1;
    }

    internal Ingredient FindByIngredient(int recipeId)
    {
        string sql = @"
        SELECT 
        ing.*
        FROM ingredients ing
        WHERE ing.id = @recipeId;
        ";
        Ingredient ingredient = _db.Query<Ingredient>(sql, new {recipeId}).FirstOrDefault();
        return ingredient;
    }

    internal List<Ingredient> FindIngredient(int recipeId)
        {
            string sql = @"
            SELECT 
            ing.*
            FROM ingredients ing
            WHERE ing.recipeId = @recipeId;
            ";
            List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new {recipeId}).ToList();
            return ingredients;
        }

    
    
}
