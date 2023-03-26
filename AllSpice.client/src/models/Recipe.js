export class Recipe {
    constructor(data) {
        this.id = data.id
        this.creatorId = data.creatorId
        this.title = data.title
        this.instructions = data.instructions
        this.img = data.img
        this.category = data.category
    }
}

// TODO look into this for favorites

// export class Favorite extends Recipe {
//     construction(data) {
//         super(data.recipe)
//         this.favoriteId = data.id
//     }
// }