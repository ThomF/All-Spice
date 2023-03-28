<template>
    <div @click="setActiveRecipe()" class="card" data-bs-toggle="modal" data-bs-target="#thisRecipe">
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
import { Account } from '../models/Account';
import { Recipe } from '../models/Recipe.js'
import { recipesService } from '../services/RecipesService';

export default {
    props: {
        recipe: { type: Recipe, required: true }
    },
    setup(props) {
        return {
            account: computed(() => AppState.account),
            setActiveRecipe() {
                recipesService.setActiveRecipe(props.recipe)
            },

        }
    }
}
</script>


<style lang="scss" scoped></style>