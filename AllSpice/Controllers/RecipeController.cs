namespace AllSpice.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly RecipesService _recipesService;
        private readonly Auth0Provider _auth;

        public RecipeController(RecipesService recipesService, Auth0Provider auth)
        {
            _recipesService = recipesService;
            _auth = auth;
        }

        [HttpPost]
        [Authorize]
        async public Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
        {
            try 
            {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            recipeData.CreatorId = userInfo.Id;
            Recipe recipe = _recipesService.CreateRecipe(recipeData);
            recipe.Creator = userInfo;
            return Ok(recipe);
            }
            catch (Exception e)
            {
            return BadRequest(e.Message);
            }
        }
    }
