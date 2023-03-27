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
}
export const recipesService = new RecipesService()