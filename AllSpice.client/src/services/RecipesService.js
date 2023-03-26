import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
class RecipesService {
    async getRecipes() {
        const res = await api.get('api/recipes')
        logger.log('[Getting All Recipes]', res.data)
        // const allRecipes = res.data.map(r => new Recipe(r))
        AppState.recipes = res.data
        // allRecipes
    }
}
export const recipesService = new RecipesService()