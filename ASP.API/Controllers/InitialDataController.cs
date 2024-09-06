using ASP.DataAccess;
using ASP.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace ASP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post()
        {
            TheContext context = new TheContext();


            /*

            User user1 = new User { FirstName = "Petar", LastName = "Peric", Username = "Pera", Password = "Lozinka1", Email = "pera@gmail.com" };
            User user2 = new User { FirstName = "Milan", LastName = "Milic", Username = "Miki", Password = "Lozinka1", Email = "miki@gmail.com" };
            User user3 = new User { FirstName = "Marko", LastName = "Markov", Username = "Mare", Password = "Lozinka1", Email = "mare@gmail.com" };
            User user4 = new User { FirstName = "Ana", LastName = "Anic", Username = "Ana", Password = "Lozinka1", Email = "ana@gmail.com" };



            Food food1 = new Food { NameFood = "Apple", KcalPer100gr = 50 };
            Food food2 = new Food { NameFood = "Bread", KcalPer100gr = 200 };
            Food food3 = new Food { NameFood = "Beef", KcalPer100gr = 250 };
            Food food4 = new Food { NameFood = "Carrot", KcalPer100gr = 50 };
            Food food5 = new Food { NameFood = "Chicken", KcalPer100gr = 200 };
            Food food6 = new Food { NameFood = "Chickpeas", KcalPer100gr = 250 };

            Recipe recipe1 = new Recipe { TitleRecipe = "Beef with carrots and bread", Description = "Grate the carrots and add to the roast beef.", TotalKcal = 550 };
            Recipe recipe2 = new Recipe { TitleRecipe = "Chickpeas with carrots and apple", Description = "Chop the apple and grate the carrots.Add boiled chickpeas.", TotalKcal = 650 };
            Recipe recipe3 = new Recipe { TitleRecipe = "Chicken with carrots 100", Description = "Grate the carrots and add to the roast beef.", TotalKcal = 550 };


            RecipeFood recipeFood1 = new RecipeFood { Recipe = recipe1, Food = food3, Gram = 200 };
            RecipeFood recipeFood2 = new RecipeFood { Recipe = recipe1, Food = food4, Gram = 100 };
            RecipeFood recipeFood3 = new RecipeFood { Recipe = recipe1, Food = food2, Gram = 50 };
            RecipeFood recipeFood4 = new RecipeFood { Recipe = recipe2, Food = food6, Gram = 200 };
            RecipeFood recipeFood5 = new RecipeFood { Recipe = recipe2, Food = food4, Gram = 50 };
            RecipeFood recipeFood6 = new RecipeFood { Recipe = recipe2, Food = food1, Gram = 100 };
            RecipeFood recipeFood7 = new RecipeFood { Recipe = recipe3, Food = food5, Gram = 200 };
            RecipeFood recipeFood8 = new RecipeFood { Recipe = recipe3, Food = food4, Gram = 100 };



            Comment comment1 = new Comment { Text = "Great", Recipe = recipe2, User = user2 };
            Comment comment2 = new Comment { Text = "I like it", Recipe = recipe1, User = user1 };
            Comment comment3 = new Comment { Text = "I do not like it", Recipe = recipe1, User = user2, ParentComment = comment2 };

           

            RecipeCategory recipeCategory1 = new RecipeCategory { Recipe = recipe1, Category = category3 };
            RecipeCategory recipeCategory2 = new RecipeCategory { Recipe = recipe2, Category = category2 };
            RecipeCategory recipeCategory3 = new RecipeCategory { Recipe = recipe2, Category = category4 };
            RecipeCategory recipeCategory4 = new RecipeCategory { Recipe = recipe2, Category = category1 };
            RecipeCategory recipeCategory5 = new RecipeCategory { Recipe = recipe3, Category = category1 };
            RecipeCategory recipeCategory6 = new RecipeCategory { Recipe = recipe3, Category = category3 };





            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Users.Add(user4);

            context.Categories.Add(category1);
            context.Categories.Add(category2);
            context.Categories.Add(category3);
            context.Categories.Add(category4);

            context.Foods.Add(food1);
            context.Foods.Add(food2);
            context.Foods.Add(food3);
            context.Foods.Add(food4);
            context.Foods.Add(food5);
            context.Foods.Add(food6);

            context.Images.Add(image1);
            context.Images.Add(image2);

            context.RecipeCategories.Add(recipeCategory1);
            context.RecipeCategories.Add(recipeCategory2);
            context.RecipeCategories.Add(recipeCategory3);
            context.RecipeCategories.Add(recipeCategory4);
            context.RecipeCategories.Add(recipeCategory5);
            context.RecipeCategories.Add(recipeCategory6);

            context.RecipeFoods.Add(recipeFood1);
            context.RecipeFoods.Add(recipeFood2);
            context.RecipeFoods.Add(recipeFood3);
            context.RecipeFoods.Add(recipeFood4);
            context.RecipeFoods.Add(recipeFood5);
            context.RecipeFoods.Add(recipeFood6);
            context.RecipeFoods.Add(recipeFood7);
            context.RecipeFoods.Add(recipeFood8);

            context.Recipes.Add(recipe1);
            context.Recipes.Add(recipe2);
            context.Recipes.Add(recipe3);

            context.Comments.Add(comment1);
            context.Comments.Add(comment2);
            context.Comments.Add(comment3);

            context.FavoriteUserRecipes.Add(favoriteUserRecipe1);
            context.FavoriteUserRecipes.Add(favoriteUserRecipe2);
            context.FavoriteUserRecipes.Add(favoriteUserRecipe3);

            */

            context.SaveChanges();
            return StatusCode(201);



        }
    }
}
