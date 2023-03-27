<template>
    <div v-if="recipe">
        <div class="card">
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

export default {
    setup() {
        return {
            recipe: computed(() => AppState.recipe)
        }
    }
}
</script>


<style lang="scss" scoped></style>