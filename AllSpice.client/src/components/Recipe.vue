<template>
    <div @click="setActiveRecipe(), getIngredients()" class="card" data-bs-toggle="modal" data-bs-target="#thisRecipe">
        <img class="img-fluid" :src="recipe.img" alt="{{ recipe.title }}">
        <div class="card-body">
            <div>
                <h2>{{ recipe.title }}</h2>
            </div>
        </div>
    </div>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
import { Account } from '../models/Account';
import { Recipe } from '../models/Recipe.js'
import { ingredientsService } from '../services/IngredientsService';
import { recipesService } from '../services/RecipesService';
import { logger } from '../utils/Logger';

export default {
    props: {
        recipe: { type: Recipe, required: true }
    },
    setup(props) {
        return {
            account: computed(() => AppState.account),
            recipes: computed(() => AppState.recipe),
            setActiveRecipe() {
                recipesService.setActiveRecipe(props.recipe)
            },
            async getIngredients() {
                const id = this.recipes.id
                logger.log(id)
                await ingredientsService.getIngredients(id)
            }

        }
    }
}
</script>


<style lang="scss" scoped></style>