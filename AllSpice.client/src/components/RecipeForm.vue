<template>
    <div class="container-fluid">
        <h3 class="my-2 border-bottom border-dark text-danger">Add New Recipe</h3>
        <form class="row" @submit.prevent="createRecipe()">
            <div class="mb-3">
                <label for="" class="form-label">Title</label>
                <input type="text" class="form-control" v-model="editable.title" name="title" id=""
                    aria-describedby="helpId" placeholder="">
            </div>
            <div class="mb-3">
                <label for="" class="form-label">Image</label>
                <input type="text" class="form-control" v-model="editable.img" name="img" id="" aria-describedby="helpId"
                    placeholder="">
            </div>
            <div class="mb-3">
                <label for="" class="form-label">Instructions</label>
                <input type="text" class="form-control" v-model="editable.instructions" name="instructions" id=""
                    aria-describedby="helpId" placeholder="">
            </div>
            <div class="mb-3">
                <label for="" class="form-label">Category</label>
                <!-- <input type="text" class="form-control" v-model="editable.category" name="category" id=""
                    aria-describedby="helpId" placeholder=""> -->
                <select v-model="editable.category" name="category" id="">
                    <option value="Lunch" selected>Lunch</option>
                    <option value="American">American</option>
                    <option value="Mexican">Mexican</option>
                    <option value="Italian">Italian</option>
                    <option value="German">German</option>
                </select>
            </div>

            <button class="btn btn-success" data-bs-dismiss="modal">Get Cooking!</button>
        </form>
    </div>
</template>


<script>
import { ref } from 'vue';
import { recipesService } from '../services/RecipesService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';

export default {
    setup() {
        const editable = ref({})

        return {
            editable,
            async createRecipe() {
                try {
                    logger.log('creating new recipe', editable.value)
                    await recipesService.createRecipe(editable.value)
                    editable.value = {}
                } catch (error) {
                    logger.error(error)
                    Pop.error(error.message)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped></style>