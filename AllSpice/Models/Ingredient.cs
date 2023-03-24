namespace AllSpice.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int recipeId { get; set; }
        public string name { get; set; }
        public string quantity { get; set; }

        public Profile Creator {get; set;}
    }
}