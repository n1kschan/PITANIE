using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class MigratonName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergens",
                columns: table => new
                {
                    AllergenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergenName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergens", x => x.AllergenID);
                });

            migrationBuilder.CreateTable(
                name: "FoodCategories",
                columns: table => new
                {
                    FoodCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategories", x => x.FoodCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    FoodItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: true),
                    Protein = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Carbohydrates = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Fats = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.FoodItemID);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PreparationTime = table.Column<int>(type: "int", nullable: true),
                    CookingTime = table.Column<int>(type: "int", nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "FoodAllergens",
                columns: table => new
                {
                    FoodAllergenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodItemID = table.Column<int>(type: "int", nullable: false),
                    AllergenID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodAllergens", x => x.FoodAllergenID);
                    table.ForeignKey(
                        name: "FK__FoodAller__Aller__1B9317B3",
                        column: x => x.AllergenID,
                        principalTable: "Allergens",
                        principalColumn: "AllergenID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__FoodAller__FoodI__1A9EF37A",
                        column: x => x.FoodItemID,
                        principalTable: "FoodItems",
                        principalColumn: "FoodItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodItemCategories",
                columns: table => new
                {
                    FoodItemCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodItemID = table.Column<int>(type: "int", nullable: false),
                    FoodCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItemCategories", x => x.FoodItemCategoryID);
                    table.ForeignKey(
                        name: "FK__FoodItemC__FoodC__04AFB25B",
                        column: x => x.FoodCategoryID,
                        principalTable: "FoodCategories",
                        principalColumn: "FoodCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__FoodItemC__FoodI__03BB8E22",
                        column: x => x.FoodItemID,
                        principalTable: "FoodItems",
                        principalColumn: "FoodItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    RecipeIngredientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeID = table.Column<int>(type: "int", nullable: true),
                    FoodItemID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => x.RecipeIngredientID);
                    table.ForeignKey(
                        name: "FK__RecipeIng__FoodI__7EF6D905",
                        column: x => x.FoodItemID,
                        principalTable: "FoodItems",
                        principalColumn: "FoodItemID");
                    table.ForeignKey(
                        name: "FK__RecipeIng__Recip__7E02B4CC",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "RecipeID");
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ActivityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CaloriesBurned = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityID);
                    table.ForeignKey(
                        name: "FK__Activitie__UserI__756D6ECB",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteRecipes",
                columns: table => new
                {
                    FavoriteRecipeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    RecipeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteRecipes", x => x.FavoriteRecipeID);
                    table.ForeignKey(
                        name: "FK__FavoriteR__Recip__0880433F",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "RecipeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__FavoriteR__UserI__078C1F06",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealPlans",
                columns: table => new
                {
                    MealPlanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    PlanName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlans", x => x.MealPlanID);
                    table.ForeignKey(
                        name: "FK__MealPlans__UserI__662B2B3B",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "NutritionalGoals",
                columns: table => new
                {
                    GoalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    DailyCaloricIntake = table.Column<int>(type: "int", nullable: true),
                    ProteinGoal = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    CarbohydrateGoal = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    FatGoal = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Nutritio__8A4FFF31ADAF2519", x => x.GoalID);
                    table.ForeignKey(
                        name: "FK__Nutrition__UserI__72910220",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileID);
                    table.ForeignKey(
                        name: "FK__Profiles__UserID__634EBE90",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingLists",
                columns: table => new
                {
                    ShoppingListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ListName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingLists", x => x.ShoppingListID);
                    table.ForeignKey(
                        name: "FK__ShoppingL__UserI__0C50D423",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Tips",
                columns: table => new
                {
                    TipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    TipText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tips", x => x.TipID);
                    table.ForeignKey(
                        name: "FK__Tips__UserID__12FDD1B2",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "UserPreferences",
                columns: table => new
                {
                    UserPreferenceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    PreferenceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PreferenceValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferences", x => x.UserPreferenceID);
                    table.ForeignKey(
                        name: "FK__UserPrefe__UserI__15DA3E5D",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    RecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    ActivityID = table.Column<int>(type: "int", nullable: true),
                    RecordDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordID);
                    table.ForeignKey(
                        name: "FK__Records__Activit__793DFFAF",
                        column: x => x.ActivityID,
                        principalTable: "Activities",
                        principalColumn: "ActivityID");
                    table.ForeignKey(
                        name: "FK__Records__UserID__7849DB76",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    MealID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealPlanID = table.Column<int>(type: "int", nullable: true),
                    MealType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MealDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.MealID);
                    table.ForeignKey(
                        name: "FK__Meals__MealPlanI__69FBBC1F",
                        column: x => x.MealPlanID,
                        principalTable: "MealPlans",
                        principalColumn: "MealPlanID");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListItems",
                columns: table => new
                {
                    ShoppingListItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingListID = table.Column<int>(type: "int", nullable: true),
                    FoodItemID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListItems", x => x.ShoppingListItemID);
                    table.ForeignKey(
                        name: "FK__ShoppingL__FoodI__10216507",
                        column: x => x.FoodItemID,
                        principalTable: "FoodItems",
                        principalColumn: "FoodItemID");
                    table.ForeignKey(
                        name: "FK__ShoppingL__Shopp__0F2D40CE",
                        column: x => x.ShoppingListID,
                        principalTable: "ShoppingLists",
                        principalColumn: "ShoppingListID");
                });

            migrationBuilder.CreateTable(
                name: "MealFoodItems",
                columns: table => new
                {
                    MealFoodItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealID = table.Column<int>(type: "int", nullable: true),
                    FoodItemID = table.Column<int>(type: "int", nullable: true),
                    ServingSize = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealFoodItems", x => x.MealFoodItemID);
                    table.ForeignKey(
                        name: "FK__MealFoodI__FoodI__6FB49575",
                        column: x => x.FoodItemID,
                        principalTable: "FoodItems",
                        principalColumn: "FoodItemID");
                    table.ForeignKey(
                        name: "FK__MealFoodI__MealI__6EC0713C",
                        column: x => x.MealID,
                        principalTable: "Meals",
                        principalColumn: "MealID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserID",
                table: "Activities",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteRecipes_RecipeID",
                table: "FavoriteRecipes",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteRecipes_UserID",
                table: "FavoriteRecipes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodAllergens_AllergenID",
                table: "FoodAllergens",
                column: "AllergenID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodAllergens_FoodItemID",
                table: "FoodAllergens",
                column: "FoodItemID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItemCategories_FoodCategoryID",
                table: "FoodItemCategories",
                column: "FoodCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItemCategories_FoodItemID",
                table: "FoodItemCategories",
                column: "FoodItemID");

            migrationBuilder.CreateIndex(
                name: "IX_MealFoodItems_FoodItemID",
                table: "MealFoodItems",
                column: "FoodItemID");

            migrationBuilder.CreateIndex(
                name: "IX_MealFoodItems_MealID",
                table: "MealFoodItems",
                column: "MealID");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlans_UserID",
                table: "MealPlans",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealPlanID",
                table: "Meals",
                column: "MealPlanID");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalGoals_UserID",
                table: "NutritionalGoals",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserID",
                table: "Profiles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_FoodItemID",
                table: "RecipeIngredients",
                column: "FoodItemID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeID",
                table: "RecipeIngredients",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Records_ActivityID",
                table: "Records",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_Records_UserID",
                table: "Records",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItems_FoodItemID",
                table: "ShoppingListItems",
                column: "FoodItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItems_ShoppingListID",
                table: "ShoppingListItems",
                column: "ShoppingListID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_UserID",
                table: "ShoppingLists",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tips_UserID",
                table: "Tips",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_UserID",
                table: "UserPreferences",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteRecipes");

            migrationBuilder.DropTable(
                name: "FoodAllergens");

            migrationBuilder.DropTable(
                name: "FoodItemCategories");

            migrationBuilder.DropTable(
                name: "MealFoodItems");

            migrationBuilder.DropTable(
                name: "NutritionalGoals");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "ShoppingListItems");

            migrationBuilder.DropTable(
                name: "Tips");

            migrationBuilder.DropTable(
                name: "UserPreferences");

            migrationBuilder.DropTable(
                name: "Allergens");

            migrationBuilder.DropTable(
                name: "FoodCategories");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "ShoppingLists");

            migrationBuilder.DropTable(
                name: "MealPlans");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
