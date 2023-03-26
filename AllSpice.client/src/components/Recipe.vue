<template>
    <div class="card">
        <div class="card-body">
            <div class="img-fluid">
                <img :src="recipe.img" alt="{{ recipe.title }}">
            </div>
            <div>
                <h2>{{ recipe.title }}</h2>
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
import { Recipe } from '../models/Recipe.js'

export default {
    props: {
        recipe: { type: Recipe, required: true }
    },
    setup() {
        return {}
    }
}
</script>


<style lang="scss" scoped></style>