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

    

        internal string DeleteFavorite(int favoriteId, string userId)
        {
            Favorite favorite = _repo.getFav(favoriteId);
            if (favorite == null)throw new Exception ($"No favorite with the id:{favoriteId}");
            if (favorite.AccountId != userId)throw new Exception ($"The favorite with id:{favoriteId} doesnt belong to you bro. leave. the door is behind you...");
            _repo.DeleteFavorite(favoriteId);
            return $"removed the favorite....";
        }

        internal List<FavoriteRecipe> GetMyFavorites(string accountId)
        {
            List<FavoriteRecipe> favoriteRecipes = _repo.GetMyFavorites(accountId);
            return favoriteRecipes;
        }
    }
}