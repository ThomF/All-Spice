<template>
  <!-- <div class="container-fluid">
    <div class="row">
      <div class="col-12">
        <div class="card elevation-5  banner-height">

          <img class="banner-img"
            src="https://i0.wp.com/www.faithanddoubt.com/wp-content/uploads/hossein-farahani-pqJ21tErTgI-unsplash-scaled.jpg?ssl=1"
            alt="">
        </div>
      </div>
    </div>
  </div> -->
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
import { computed, onMounted, watchEffect } from 'vue'
import { AppState } from '../AppState'
import { recipesService } from '../services/RecipesService'
import { logger } from '../utils/Logger'
// import Login from '../Login.vue'
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
    async function getFavoriteRecipes() {
      try {
        await recipesService.getFavoriteRecipes()
      } catch (error) {
        Pop.error(error.message)
      }
    }
    onMounted(() => {
      getRecipes()
    })
    watchEffect(() => {
      if (AppState.account.id) {
        getFavoriteRecipes()
      }
    })
    return {
      recipes: computed(() => AppState.recipes)
    }
  },
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

.banner-img {
  background-image: url(https://i0.wp.com/www.faithanddoubt.com/wp-content/uploads/hossein-farahani-pqJ21tErTgI-unsplash-scaled.jpg?ssl=1);
  object-fit: cover;
  height: 25em;
}

.banner-height {
  margin: 20px;
}
</style>
