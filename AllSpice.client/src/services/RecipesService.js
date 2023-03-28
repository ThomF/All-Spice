import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import { Recipe } from "../models/Recipe"
class RecipesService {
    async getRecipes() {
        const res = await api.get('api/recipes')
        logger.log('[Getting All Recipes]', res.data)
        const allRecipes = res.data.map(r => new Recipe(r))
        logger.log(allRecipes)
        AppState.recipes = allRecipes
        // allRecipes
    }

    setActiveRecipe(recipe) {
        AppState.recipe = recipe
    }

    async createRecipe(recipeData) {
        const res = await api.post('api/recipes', recipeData)
        logger.log(res.data)
        AppState.recipes.push(res.data)
    }


    async favoriteRecipe(recipeId) {
        const res = await api.post('api/favorites', { recipeId })
        logger.log("[Favorite the recipe]", res.data)
        // AppState.favorites.push
    }

    async getFavoriteRecipes() {
        const res = await api.get('account/favorites')
        logger.log(res.data, '[Account Favorites]')
        AppState.favorites = res.data.map(f => new Recipe(f))
    }

}
export const recipesService = new RecipesService()