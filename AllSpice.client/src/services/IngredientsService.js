import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import { Ingredient } from "../models/Ingredient"
class IngredientsService {
    async getIngredients(id) {
        AppState.ingredients = []
        const res = await api.get(`api/recipes/${id}/ingredients`)
        logger.log('Getting the ingredients for this recipe', res.data)
        AppState.ingredients = res.data.map(i => new Ingredient(i))
    }
}

export const ingredientsService = new IngredientsService()