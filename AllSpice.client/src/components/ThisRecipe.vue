<template>
    <div v-if="recipe">
        <div class="d-flex justify-content-around">
            <h1>{{ recipe.title }}</h1>
            <div class="pt-2 pb-2">
                <button @click="favoriteRecipe(recipe.id)" class="btn btn-outline-warning">
                    <i class="mdi mdi-star fs-4"></i></button>
            </div>
            <!-- <div>
                <button @click="favoriteRecipe(recipe.id)" class="btn btn-success"><i class="mdi mdi-star"></i></button>
            </div> -->
        </div>
        <div class="d-flex ps-3 pb-2">

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
                    <div v-for="i in ingredients">
                        <div class="card">
                            <div class="card-body">
                                <div class="d-flex">
                                    <p>{{ i.name }}</p>
                                    <p>{{ i.quantity }}</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>
</template>


<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import { recipesService } from '../services/RecipesService';
import { ingredientsService } from '../services/IngredientsService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';

export default {
    setup() {

        onMounted(() => {
            // getIngredients()
        })
        return {
            recipe: computed(() => AppState.recipe),
            ingredients: computed(() => AppState.ingredients),
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