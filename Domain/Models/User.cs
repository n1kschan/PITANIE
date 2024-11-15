using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class User
    {
        public User()
        {
            Activities = new HashSet<Activity>();
            FavoriteRecipes = new HashSet<FavoriteRecipe>();
            MealPlans = new HashSet<MealPlan>();
            NutritionalGoals = new HashSet<NutritionalGoal>();
            Profiles = new HashSet<Profile>();
            Records = new HashSet<Record>();
            ShoppingLists = new HashSet<ShoppingList>();
            Tips = new HashSet<Tip>();
            UserPreferences = new HashSet<UserPreference>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<FavoriteRecipe> FavoriteRecipes { get; set; }
        public virtual ICollection<MealPlan> MealPlans { get; set; }
        public virtual ICollection<NutritionalGoal> NutritionalGoals { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
        public virtual ICollection<Record> Records { get; set; }
        public virtual ICollection<ShoppingList> ShoppingLists { get; set; }
        public virtual ICollection<Tip> Tips { get; set; }
        public virtual ICollection<UserPreference> UserPreferences { get; set; }
    }
}
