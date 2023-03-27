<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-4" v-for="r in recipes">
        <Recipe :recipe="r" />
      </div>
    </div>
  </div>
  <Modal id="create-recipe">
    <RecipeForm />
  </Modal>
  <Modal id="thisRecipe">
    <ThisRecipe />
  </Modal>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { recipesService } from '../services/RecipesService'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
export default {
  setup() {
    async function getRecipes() {
      try {
        await recipesService.getRecipes()
      } catch (error) {
        Pop.error(error.message)
      }
    }
    onMounted(() => {
      getRecipes()
    })
    return {
      recipes: computed(() => AppState.recipes)

    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
