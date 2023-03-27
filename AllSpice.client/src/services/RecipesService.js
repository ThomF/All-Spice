import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import { Recipe } from "../models/Recipe"
import { applyStyles } from "@popperjs/core"
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
}
export const recipesService = new RecipesService()