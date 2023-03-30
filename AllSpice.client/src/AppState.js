import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  /** @type {import('./models/Recipe.js').Recipe[]} */
  recipes: {},
  allRecipes: null,
  /** @type {import('./models/Recipe.js').Recipe | Null} */
  recipe: null,
  editMyRecipe: false,
  /** @type {import('./models/Recipe.js').Recipe[]} */
  myRecipes: {},
  /** @type {import('./models/Favorite.js').Favorite[]} */
  favorites: [],
  filter: 0,
  /** @type {import('./models/Ingredient.js').Ingredient[]} */
  ingredients: []
})
