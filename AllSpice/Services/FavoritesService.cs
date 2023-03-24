namespace AllSpice.Services
{
    public class FavoritesService
    {
        private readonly FavoritesRepository _repo;

        public FavoritesService(FavoritesRepository repo)
        {
            _repo = repo;
        }

        internal Favorite CreateFavorite(Favorite favoriteData)
        {
            Favorite favorite = _repo.CreateFavorite(favoriteData);
            return favorite;
        }

        internal List<FavoriteRecipe> GetMyFavorites(string accountId)
        {
            List<FavoriteRecipe> favoriteRecipes = _repo.GetMyFavorites(accountId);
            return favoriteRecipes;
        }
    }
}