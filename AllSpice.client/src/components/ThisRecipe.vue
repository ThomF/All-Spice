<template>
    <div v-if="recipe">
        <div class="d-flex justify-content-around">
            <h1>{{ recipe.title }}</h1>
            <button @click="favoriteRecipe(recipe.id)" class="btn btn-success"><i class="mdi mdi-star"></i></button>
        </div>
        <div class="d-flex ps-5">

            <div class=" elevation-5">
                <img class="img-fluid tinyIMG" :src="recipe.img" alt="">
            </div>

            <div class="elevation-5 ps-2">
                <div>
                    <h3>Instructions</h3>
                    <p>
                        {{ recipe.instructions }}
                    </p>
                </div>
                <div>
                    <h3>Ingredients</h3>
                    ingredients here
                </div>

            </div>

        </div>

    </div>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
import { recipesService } from '../services/RecipesService';
import Pop from '../utils/Pop';

export default {
    setup() {
        return {
            recipe: computed(() => AppState.recipe),
            async favoriteRecipe(recipeId) {
                try {
                    await recipesService.favoriteRecipe(recipeId)
                    Pop.success("Favorited This Recipe")
                } catch (error) {
                    Pop.error(error.message)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.tinyIMG {
    width: 500px;
    height: 750px;
    margin: 2em;
}
</style>