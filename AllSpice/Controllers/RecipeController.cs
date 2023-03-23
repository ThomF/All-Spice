namespace AllSpice.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;
        private readonly Auth0Provider _auth;

        public RecipesController(RecipesService recipesService, Auth0Provider auth)
        {
            _recipesService = recipesService;
            _auth = auth;
        }

        [HttpGet]
        async public Task<ActionResult<List<Recipe>>> FindRecipe()
        {
            try 
            {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            List<Recipe> recipes = _recipesService.GetAllRecipes(userInfo?.Id);
            return Ok(recipes);
            }
            catch (Exception e)
            {
            return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> FindRecipeById(int id)
        {
            try 
            {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            Recipe recipe = _recipesService.FindRecipeById(id, userInfo.Id);
            return Ok(recipe);
            }
            catch (Exception e)
            {
            return BadRequest(e.Message);
            }
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

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Recipe>> UpdateRecipe(int id, [FromBody] Recipe updateData)
        {
            try 
            {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            
            Recipe recipe = _recipesService.UpdateRecipe(id, updateData, userInfo);
            return Ok(recipe);
            }
            catch (Exception e)
            {
            return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        // NOTE note recipe but string because we are not returning object ut a string of confirmation
        public async Task<ActionResult<string>> DeleteRecipe(int id)
        {
            try 
            {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            String message = _recipesService.DeleteRecipe(id, userInfo);
            return Ok(message);
            }
            catch (Exception e)
            {
            return BadRequest(e.Message);
            }
        }
    }
