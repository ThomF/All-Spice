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

            <div class="elevation-5 ps-3 pe-3">
                <div>
                    <h3>Instructions</h3>
                    <p>
                        {{ recipe.instructions }}
                    </p>
                    <div v-if="account.id == recipe.creatorId">
                        <!-- <button @click="editRecipe(recipe.id)" class="btn btn-success"><i class="mdi mdi-pen"></i></button> -->
                        <button @click="openEditor()" class="btn btn-success"><i class="mdi mdi-pen"></i></button>
                    </div>
                    <div class="p-2">
                        <form @submit.prevent="editRecipe(recipe.id)">
                            <textarea v-model="editable.instructions" class="rounded-pill" type="text"
                                id="instructions"></textarea>
                            <button @click="closeEditor()" type="submit" class="btn btn-success-outline"><i
                                    class="mdi mdi-check-outline"></i></button>
                        </form>
                    </div>
                </div>
                <div>
                    <h3>Ingredients</h3>
                    <div v-if="account.id == recipe.creatorId">
                        <form @submit.prevent="addIngredients()">
                            <input v-model="editable.name" class="p-1 m-1 rounded-pill" type="text"
                                title="Name of Ingredient" placeholder="Name of Ingredient">
                            <input v-model="editable.quantity" class="p-1 m-1 rounded-pill" type="text"
                                title="Quantity of Ingredient" placeholder="Quantity of Ingredient">
                            <button @click="openEditor()" class="btn btn-success p-2 m-1"><i
                                    class="mdi mdi-shaker-outline"></i></button>
                        </form>
                    </div>
                    <div v-for="i in ingredients">
                        <div class="elevation-3 pb-2">
                            <div class="">
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
import { computed, onMounted, ref } from 'vue';
import { AppState } from '../AppState';
import { recipesService } from '../services/RecipesService';
import { ingredientsService } from '../services/IngredientsService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';

export default {
    setup() {
        const editable = ref({})

        onMounted(() => {
            // getIngredients()
        })
        return {
            editable,
            recipe: computed(() => AppState.recipe),
            ingredients: computed(() => AppState.ingredients),
            account: computed(() => AppState.account),
            async favoriteRecipe(recipeId) {
                try {
                    await recipesService.favoriteRecipe(recipeId)
                    Pop.success("Favorited This Recipe")
                } catch (error) {
                    Pop.error(error.message)
                }
            },

            async editRecipe(recipeId) {
                try {
                    const editData = editable.value
                    await recipesService.editRecipe(recipeId, editData)
                    Pop.success('Edited Successfully')
                    editable.value = {}
                } catch (error) {
                    logger.error(error.message)
                }
            },

            openEditor() {
                AppState.editMyRecipe = true
                logger.log(AppState.editMyRecipe)
            },
            closeEditor() {
                AppState.editMyRecipe = false
                logger.log(AppState.editMyRecipe)
            },

            async addIngredients() {
                try {

                } catch (error) {
                    logger.error(error.message)
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