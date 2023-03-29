import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import { Ingredient } from "../models/Ingredient"
import Pop from "../utils/Pop"
class IngredientsService {
    async getIngredients(id) {
        AppState.ingredients = []
        const res = await api.get(`api/recipes/${id}/ingredients`)
        logger.log('Getting the ingredients for this recipe', res.data)
        AppState.ingredients = res.data.map(i => new Ingredient(i))
    }

    async addIngredients(ingData) {
        const res = await api.post('api/ingredients', ingData)
        logger.log('[added new ingredient]', res.data)
        AppState.ingredients.push(res.data)
    }

    async deleteIngredient(ingId) {
        const res = await api.delete(`api/ingredients/${ingId}`)
        logger.log('[Deleted The Ingredient]', res.data)
        let i = AppState.ingredients.findIndex(i => i.id == ingId)
        if (i != -1) {
            AppState.ingredients.splice(i, 1)
        }
    }
}

export const ingredientsService = new IngredientsService()