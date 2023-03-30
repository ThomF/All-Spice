<template>
    <div @click="setActiveRecipe(), getIngredients()" class="" data-bs-toggle="modal" data-bs-target="#thisRecipe">
        <!-- <img class="img-fluid" :src="recipe.img" alt="{{ recipe.title }}"> -->
        <div class="bg-rimg">
            <div class="pt-2 pb-2 d-flex">
                <div class="">
                    <h2>{{ recipe.title }}</h2>
                </div>
                <div class="flyHigh">
                    <button @click="favoriteRecipe(recipe.id)" class="btn btn-outline-warning">
                        <i class="mdi mdi-star fs-4"></i></button>
                </div>
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
            recipeImg: computed(() => `url("${props.recipe?.img}")`),
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


<style lang="scss" scoped>
// .flyHigh {
//     transform: translateY();
// }

.frosted-card-title {
    width: 15em;
    transform: translateY(-300%);
    box-shadow: 0 0 5px 0;
    background: inherit;
    backdrop-filter: blur(50px);
    text-shadow: 1px 1px 2px black;
}

.frosted-card-cat {
    width: 8em;
    content: object-fit;
    transform: translateY(-22em);
    box-shadow: 0 0 5px 0;
    background: inherit;
    backdrop-filter: blur(50px);
    text-shadow: 1px 1px 2px black;
}

.bg-rimg {
    background-image: v-bind(recipeImg);
    background-size: cover;
    position: center;
    height: 50vh;
}
</style>