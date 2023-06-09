import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import { Recipe } from "../models/Recipe"
class RecipesService {
    async getRecipes() {
        const res = await api.get('api/recipes')
        logger.log('[Getting All Recipes]', res.data)
        const allTheRecipes = res.data.map(r => new Recipe(r))
        AppState.allRecipes = res.data.map(r => new Recipe(r))
        logger.log(allTheRecipes)
        AppState.recipes = allTheRecipes
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
        // AppState.favorites.push(res.data)
        const recipe = AppState.recipes.find(r => r.id == recipeId)
        recipe.favoriteId = res.data.id

    }

    async getFavoriteRecipes() {
        const res = await api.get('account/favorites')
        logger.log(res.data, '[Account Favorites]')
        AppState.favorites = res.data.map(f => new Recipe(f))

        AppState.recipes.forEach(r => {
            AppState.favorites.forEach(f => {
                if (r.id == f.id) {
                    r.favoriteId = f.favoriteId
                }
            })
        })
    }

    async editRecipe(recipeId, editData) {
        const res = await api.put(`api/recipes/${recipeId}`, editData)
        logger.log('edited the recipe', res.data)
        AppState.recipe = new Recipe(res.data)
    }



}
export const recipesService = new RecipesService()