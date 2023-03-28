<template>
    <div v-if="recipe">
        <h1>{{ recipe.title }}</h1>
        <div class="card">
            <button @click="favoriteRecipe(recipe.id)"><i class="mdi mdi-star"></i></button>

            <img class="img-fluid" :src="recipe.img" alt="">
            <div class="card-body">

                <div>
                    <p>
                        {{ recipe.instructions }}
                    </p>
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


<style lang="scss" scoped></style>