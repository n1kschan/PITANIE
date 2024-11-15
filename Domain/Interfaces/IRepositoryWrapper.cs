using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Wrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository User {  get; }
        IActivityRepository Activity { get; }
        IAllergenRepository Allergen { get; }
        IFavoriteRecipeRepository FavoriteRecipe { get; }
        IFoodAllergenRepository FoodAllergen { get; }
        IFoodCategoryRepository FoodCategory { get; }
        IFoodItemRepository FoodItem { get; }
        IFoodItemCategoryRepository FoodItemCategory { get; }
        IMealRepository Meal { get; }
        IMealFoodItemRepository MealFoodItem { get; }
        INutritionalGoalRepository NutritionalGoal { get; }
        IProfileRepository Profile { get; }
        IRecipeRepository Recipe { get; }
        IRecipeIngredientRepository RecipeIngredient { get; }
        IRecordRepository Record { get; }
        IShoppingListItemRepository ShoppingListItem { get; }
        IShoppingListRepository ShoppingList { get; }
        ITipRepository Tip { get; }
        IMealPlanRepository MealPlan { get; }
        IUserPreferenceRepository UserPreference { get; }
        Task Save();
    }
}
