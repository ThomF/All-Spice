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
      <Login />
    </div>
  </nav>
  <div class="container">
    <div class="row">
      <div class="col-4"></div>
      <div class="col-4 buttons">
        <button class="btn btn-success btn-outline btnHeight">ALL Recipes</button>
        <button class="btn btn-success btn-outline btnHeight">My Recipes</button>
        <button class="btn btn-success btn-outline btnHeight">Favorites</button>
      </div>
      <div class="col-4"></div>
    </div>
  </div>
</template>

<script>
import Login from './Login.vue'
export default {
  setup() {
    return {}
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
</style>
