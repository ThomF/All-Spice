<template>
    <div class="container-fluid">
        <h3 class="my-2 border-bottom border-dark text-danger">Add New Recipe</h3>
        <form class="row" @submit.prevent="">
            <div class="mb-3">
                <label for="" class="form-label">Title</label>
                <input type="text" class="form-control" v-model="editable.title" name="title" id=""
                    aria-describedby="helpId" placeholder="">
            </div>
            <div class="mb-3">
                <label for="" class="form-label">Instructions</label>
                <input type="text" class="form-control" v-model="editable.instructions" name="instructions" id=""
                    aria-describedby="helpId" placeholder="">
            </div>
            <!-- <div class="mb-3">
                <label for="" class="form-label">Category</label>
                <input type="text" class="form-control" v-model="editable.category" name="category" id=""
                    aria-describedby="helpId" placeholder="">
            </div> -->

            <button class="btn btn-success">Get Cooking!</button>
        </form>
    </div>
</template>


<script>
import { ref } from 'vue';

export default {
    setup() {
        const editable = ref({})

        return {
            editable
        }
    }
}
</script>


<style lang="scss" scoped></style>