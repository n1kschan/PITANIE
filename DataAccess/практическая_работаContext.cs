using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DateAccess
{
    public partial class практическая_работаContext : DbContext
    {
        public практическая_работаContext()
        {
        }

        public практическая_работаContext(DbContextOptions<практическая_работаContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; } = null!;
        public virtual DbSet<Allergen> Allergens { get; set; } = null!;
        public virtual DbSet<FavoriteRecipe> FavoriteRecipes { get; set; } = null!;
        public virtual DbSet<FoodAllergen> FoodAllergens { get; set; } = null!;
        public virtual DbSet<FoodCategory> FoodCategories { get; set; } = null!;
        public virtual DbSet<FoodItem> FoodItems { get; set; } = null!;
        public virtual DbSet<FoodItemCategory> FoodItemCategories { get; set; } = null!;
        public virtual DbSet<Meal> Meals { get; set; } = null!;
        public virtual DbSet<MealFoodItem> MealFoodItems { get; set; } = null!;
        public virtual DbSet<MealPlan> MealPlans { get; set; } = null!;
        public virtual DbSet<NutritionalGoal> NutritionalGoals { get; set; } = null!;
        public virtual DbSet<Profile> Profiles { get; set; } = null!;
        public virtual DbSet<Recipe> Recipes { get; set; } = null!;
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;
        public virtual DbSet<Record> Records { get; set; } = null!;
        public virtual DbSet<ShoppingList> ShoppingLists { get; set; } = null!;
        public virtual DbSet<ShoppingListItem> ShoppingListItems { get; set; } = null!;
        public virtual DbSet<Tip> Tips { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserPreference> UserPreferences { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.ActivityName).HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Activitie__UserI__756D6ECB");
            });

            modelBuilder.Entity<Allergen>(entity =>
            {
                entity.Property(e => e.AllergenId).HasColumnName("AllergenID");

                entity.Property(e => e.AllergenName).HasMaxLength(100);
            });

            modelBuilder.Entity<FavoriteRecipe>(entity =>
            {
                entity.Property(e => e.FavoriteRecipeId).HasColumnName("FavoriteRecipeID");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.FavoriteRecipes)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK__FavoriteR__Recip__0880433F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavoriteRecipes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__FavoriteR__UserI__078C1F06");
            });

            modelBuilder.Entity<FoodAllergen>(entity =>
            {
                entity.Property(e => e.FoodAllergenId).HasColumnName("FoodAllergenID");

                entity.Property(e => e.AllergenId).HasColumnName("AllergenID");

                entity.Property(e => e.FoodItemId).HasColumnName("FoodItemID");

                entity.HasOne(d => d.Allergen)
                    .WithMany(p => p.FoodAllergens)
                    .HasForeignKey(d => d.AllergenId)
                    .HasConstraintName("FK__FoodAller__Aller__1B9317B3");

                entity.HasOne(d => d.FoodItem)
                    .WithMany(p => p.FoodAllergens)
                    .HasForeignKey(d => d.FoodItemId)
                    .HasConstraintName("FK__FoodAller__FoodI__1A9EF37A");
            });

            modelBuilder.Entity<FoodCategory>(entity =>
            {
                entity.Property(e => e.FoodCategoryId).HasColumnName("FoodCategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(100);
            });

            modelBuilder.Entity<FoodItem>(entity =>
            {
                entity.Property(e => e.FoodItemId).HasColumnName("FoodItemID");

                entity.Property(e => e.Carbohydrates).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Fats).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.FoodName).HasMaxLength(100);

                entity.Property(e => e.Protein).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<FoodItemCategory>(entity =>
            {
                entity.Property(e => e.FoodItemCategoryId).HasColumnName("FoodItemCategoryID");

                entity.Property(e => e.FoodCategoryId).HasColumnName("FoodCategoryID");

                entity.Property(e => e.FoodItemId).HasColumnName("FoodItemID");

                entity.HasOne(d => d.FoodCategory)
                    .WithMany(p => p.FoodItemCategories)
                    .HasForeignKey(d => d.FoodCategoryId)
                    .HasConstraintName("FK__FoodItemC__FoodC__04AFB25B");

                entity.HasOne(d => d.FoodItem)
                    .WithMany(p => p.FoodItemCategories)
                    .HasForeignKey(d => d.FoodItemId)
                    .HasConstraintName("FK__FoodItemC__FoodI__03BB8E22");
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.Property(e => e.MealId).HasColumnName("MealID");

                entity.Property(e => e.MealDate).HasColumnType("date");

                entity.Property(e => e.MealPlanId).HasColumnName("MealPlanID");

                entity.Property(e => e.MealType).HasMaxLength(10);

                entity.HasOne(d => d.MealPlan)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.MealPlanId)
                    .HasConstraintName("FK__Meals__MealPlanI__69FBBC1F");
            });

            modelBuilder.Entity<MealFoodItem>(entity =>
            {
                entity.Property(e => e.MealFoodItemId).HasColumnName("MealFoodItemID");

                entity.Property(e => e.FoodItemId).HasColumnName("FoodItemID");

                entity.Property(e => e.MealId).HasColumnName("MealID");

                entity.Property(e => e.ServingSize).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.FoodItem)
                    .WithMany(p => p.MealFoodItems)
                    .HasForeignKey(d => d.FoodItemId)
                    .HasConstraintName("FK__MealFoodI__FoodI__6FB49575");

                entity.HasOne(d => d.Meal)
                    .WithMany(p => p.MealFoodItems)
                    .HasForeignKey(d => d.MealId)
                    .HasConstraintName("FK__MealFoodI__MealI__6EC0713C");
            });

            modelBuilder.Entity<MealPlan>(entity =>
            {
                entity.Property(e => e.MealPlanId).HasColumnName("MealPlanID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.PlanName).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MealPlans)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__MealPlans__UserI__662B2B3B");
            });

            modelBuilder.Entity<NutritionalGoal>(entity =>
            {
                entity.HasKey(e => e.GoalId)
                    .HasName("PK__Nutritio__8A4FFF31ADAF2519");

                entity.Property(e => e.GoalId).HasColumnName("GoalID");

                entity.Property(e => e.CarbohydrateGoal).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.FatGoal).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ProteinGoal).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.NutritionalGoals)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Nutrition__UserI__72910220");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Height).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Profiles__UserID__634EBE90");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.RecipeName).HasMaxLength(100);
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.Property(e => e.RecipeIngredientId).HasColumnName("RecipeIngredientID");

                entity.Property(e => e.FoodItemId).HasColumnName("FoodItemID");

                entity.Property(e => e.Quantity).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.HasOne(d => d.FoodItem)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.FoodItemId)
                    .HasConstraintName("FK__RecipeIng__FoodI__7EF6D905");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK__RecipeIng__Recip__7E02B4CC");
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.RecordDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK__Records__Activit__793DFFAF");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Records__UserID__7849DB76");
            });

            modelBuilder.Entity<ShoppingList>(entity =>
            {
                entity.Property(e => e.ShoppingListId).HasColumnName("ShoppingListID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ListName).HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShoppingLists)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ShoppingL__UserI__0C50D423");
            });

            modelBuilder.Entity<ShoppingListItem>(entity =>
            {
                entity.Property(e => e.ShoppingListItemId).HasColumnName("ShoppingListItemID");

                entity.Property(e => e.FoodItemId).HasColumnName("FoodItemID");

                entity.Property(e => e.Quantity).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ShoppingListId).HasColumnName("ShoppingListID");

                entity.HasOne(d => d.FoodItem)
                    .WithMany(p => p.ShoppingListItems)
                    .HasForeignKey(d => d.FoodItemId)
                    .HasConstraintName("FK__ShoppingL__FoodI__10216507");

                entity.HasOne(d => d.ShoppingList)
                    .WithMany(p => p.ShoppingListItems)
                    .HasForeignKey(d => d.ShoppingListId)
                    .HasConstraintName("FK__ShoppingL__Shopp__0F2D40CE");
            });

            modelBuilder.Entity<Tip>(entity =>
            {
                entity.Property(e => e.TipId).HasColumnName("TipID");

                entity.Property(e => e.Category).HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tips)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Tips__UserID__12FDD1B2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.PasswordHash).HasMaxLength(255);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<UserPreference>(entity =>
            {
                entity.Property(e => e.UserPreferenceId).HasColumnName("UserPreferenceID");

                entity.Property(e => e.PreferenceName).HasMaxLength(100);

                entity.Property(e => e.PreferenceValue).HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserPrefe__UserI__15DA3E5D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
