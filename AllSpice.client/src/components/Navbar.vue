<template>
  <nav class="navbar navbar-expand-lg px-3 banner-img elevation-4">
    <!-- <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
    <div class="d-flex flex-column align-items-center">
      <img alt="logo" src="../assets/img/cw-logo.png" height="45" />
    </div>
  </router-link> -->
    <div class="text-light text-center">
      <h2 class="">ALL SPICE</h2>
    </div>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <!-- Modal trigger button -->
    <!-- <img class="banner-img"
    src="https://i0.wp.com/www.faithanddoubt.com/wp-content/uploads/hossein-farahani-pqJ21tErTgI-unsplash.jpg?ssl=1"
    alt=""> -->

    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">

      </ul>

      <!-- LOGIN COMPONENT HERE -->
      <div class="upitty">
        <Login />
      </div>
    </div>
  </nav>
  <div class="container">
    <div class="row">
      <div class="col-4"></div>
      <!-- <div class="col-4 buttons">
        <button @click="changeFilter(0)" class="btn btn-warning btnHeight">ALL Recipes</button>
        <button @click="changeFilter(1)" class="btn btn-warning btnHeight">My Recipes</button>
        <button @click="changeFilter(2)" class="btn btn-warning btnHeight">Favorites</button>
      </div> -->
      <div class="col-4 buttons">
        <div class="btn-group btn-group-toggle" data-toggle="buttons">
          <label class="btn btn-secondary active">
            <input type="radio" class="input-btn" @click="changeFilter(0)" name="options" id="option1" autocomplete="off"
              checked> Home Page
          </label>
          <label class="btn btn-primary">
            <input type="radio" class="input-btn" @click="changeFilter(1)" name="options" id="option2" autocomplete="off">
            My Recipes
          </label>
          <label class="btn btn-secondary">
            <input type="radio" class="input-btn" @click="changeFilter(2)" name="options" id="option3" autocomplete="off">
            My Favorites
          </label>
        </div>
      </div>
      <div class="col-4">
        <div>
          <label for="search">Search</label>
          <input v-model="editable.search" @input="searchCategories()" type="text" id="search" class="form-control"
            aria-describedby="search" name="body">
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { ref, computed } from 'vue';
import { AppState } from '../AppState';
import { logger } from '../utils/Logger';
import Login from './Login.vue'
export default {
  setup() {
    // const filterRecipe = ref(0)
    const editable = ref({
      search: ""
    })
    function searchCategories() {
      setTimeout(() => {
        AppState.recipes = AppState.allRecipes.filter(r => r.category.toLowerCase().includes(editable.value.search.toLowerCase()))
      }, 300)
      if (editable.value.search == '') { AppState.recipes == AppState.allRecipes, logger.log("filtering") }
    }
    return {
      recipes: computed(() => AppState.allRecipes),
      editable,
      searchCategories,
      changeFilter(category) {
        // filterRecipe.value = category
        AppState.filter = category
        logger.log(AppState.filter)
      }
    }
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 300px;
    margin: 2em;

  }
}

.buttons {
  transform: translateY(-50px);
}

.btnHeight {
  height: 4em;
  margin-left: 1em;
}

.banner-img {
  background-image: url(https://i0.wp.com/www.faithanddoubt.com/wp-content/uploads/hossein-farahani-pqJ21tErTgI-unsplash-scaled.jpg?ssl=1);
}

.input-btn {
  display: none;
}

.upitty {
  transform: translateY(-100px);
}
</style>
