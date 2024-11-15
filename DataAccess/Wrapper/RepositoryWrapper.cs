using Domain.Interfaces;
using Domain.Models;
using DateAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Wrapper;

namespace DateAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private практическая_работаContext _repoContext;

        public IUserRepository _user;
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        public IAllergenRepository _allergen;
        public IAllergenRepository Allergen
        {
            get
            {
                if (_allergen == null)
                {
                    _allergen = new AllergenRepository(_repoContext);
                }
                return _allergen;
            }
        }

        public IFavoriteRecipeRepository _favoriteRecipe;
        public IFavoriteRecipeRepository FavoriteRecipe
        {
            get
            {
                if (_favoriteRecipe == null)
                {
                    _favoriteRecipe = new FavoriteRecipeRepository(_repoContext);
                }
                return _favoriteRecipe;
            }
        }

        public IActivityRepository _activit;
        public IActivityRepository Activity
        {
            get
            {
                if (_activit == null)
                {
                    _activit = new ActivityRepository(_repoContext);
                }
                return _activit;
            }
        }

        public IFoodAllergenRepository _foodAllergen;
        public IFoodAllergenRepository FoodAllergen
        {
            get
            {
                if (_foodAllergen == null)
                {
                    _foodAllergen = new FoodAllergenRepository(_repoContext);
                }
                return _foodAllergen;
            }
        }

        public IFoodCategoryRepository _foodCategory;
        public IFoodCategoryRepository FoodCategory
        {
            get
            {
                if (_foodCategory == null)
                {
                    _foodCategory = new FoodCategoryRepository(_repoContext);
                }
                return _foodCategory;
            }
        }

        public IFoodItemRepository _foodItem;
        public IFoodItemRepository FoodItem
        {
            get
            {
                if (_foodItem == null)
                {
                    _foodItem = new FoodItemRepository(_repoContext);
                }
                return _foodItem;
            }
        }

        public IFoodItemCategoryRepository _foodItemCategory;
        public IFoodItemCategoryRepository FoodItemCategory
        {
            get
            {
                if (_foodItemCategory == null)
                {
                    _foodItemCategory = new FoodItemCategoryRepository(_repoContext);
                }
                return _foodItemCategory;
            }
        }

        public IMealRepository _meal;
        public IMealRepository Meal
        {
            get
            {
                if (_meal == null)
                {
                    _meal = new MealRepository(_repoContext);
                }
                return _meal;
            }
        }

        public IMealFoodItemRepository _mealFoodItem;
        public IMealFoodItemRepository MealFoodItem
        {
            get
            {
                if (_mealFoodItem == null)
                {
                    _mealFoodItem = new MealFoodItemRepository(_repoContext);
                }
                return _mealFoodItem;
            }
        }

        public IMealPlanRepository _mealPlan;
        public IMealPlanRepository MealPlan
        {
            get
            {
                if (_mealPlan == null)
                {
                    _mealPlan = new MealPlanRepository(_repoContext);
                }
                return _mealPlan;
            }
        }

        public INutritionalGoalRepository _nutritionalGoal;
        public INutritionalGoalRepository NutritionalGoal
        {
            get
            {
                if (_nutritionalGoal == null)
                {
                    _nutritionalGoal = new NutritionalGoalRepository(_repoContext);
                }
                return _nutritionalGoal;
            }
        }

        public IProfileRepository _profile;
        public IProfileRepository Profile
        {
            get
            {
                if (_profile == null)
                {
                    _profile = new ProfileRepository(_repoContext);
                }
                return _profile;
            }
        }

        public IRecipeRepository _recipe;
        public IRecipeRepository Recipe
        {
            get
            {
                if (_recipe == null)
                {
                    _recipe = new RecipeRepository(_repoContext);
                }
                return _recipe;
            }
        }

        public IRecipeIngredientRepository _recipeIngredient;
        public IRecipeIngredientRepository RecipeIngredient
        {
            get
            {
                if (_recipeIngredient == null)
                {
                    _recipeIngredient = new RecipeIngredientRepository(_repoContext);
                }
                return _recipeIngredient;
            }
        }

        public IRecordRepository _record;
        public IRecordRepository Record
        {
            get
            {
                if (_record == null)
                {
                    _record = new RecordRepository(_repoContext);
                }
                return _record;
            }
        }

        public IShoppingListRepository _shoppingList;
        public IShoppingListRepository ShoppingList
        {
            get
            {
                if (_shoppingList == null)
                {
                    _shoppingList = new ShoppingListRepository(_repoContext);
                }
                return _shoppingList;
            }
        }

        public IShoppingListItemRepository _shoppingListItem;
        public IShoppingListItemRepository ShoppingListItem
        {
            get
            {
                if (_shoppingListItem == null)
                {
                    _shoppingListItem = new ShoppingListItemRepository(_repoContext);
                }
                return _shoppingListItem;
            }
        }

        public ITipRepository _tip;
        public ITipRepository Tip
        {
            get
            {
                if (_tip == null)
                {
                    _tip = new TipRepository(_repoContext);
                }
                return _tip;
            }
        }

        public IUserPreferenceRepository _userPreference;
        public IUserPreferenceRepository UserPreference
        {
            get
            {
                if (_userPreference == null)
                {
                    _userPreference = new UserPreferenceRepository(_repoContext);
                }
                return _userPreference;
            }
        }

        public RepositoryWrapper(практическая_работаContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
