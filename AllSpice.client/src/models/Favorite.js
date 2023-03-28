import { Profile } from "./Account.js"
export class Favorite extends Profile {
    constructor(data) {
        super(data.profile)
        this.id = data.id
        this.recipeId = data.recipeId

    }
}