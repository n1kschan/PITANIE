using System.Reflection;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Wrapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BusinessLogic.Services.BusinessLogic.Services;
using DateAccess;
using DateAccess.Wrapper;

namespace �������
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<������������_������Context>(
                optionsAction: options => options.UseSqlServer(
                    connectionString: "Server=DESKTOP-7IAQVED;Database=������������_������;User Id=������;Password=7315;"));

            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IAllergenService, AllergenService>();
            builder.Services.AddScoped<IFavoriteRecipeService, FavoriteRecipeService>();
            builder.Services.AddScoped<IFoodAllergenService, FoodAllergenService>();
            builder.Services.AddScoped<IActivityService, ActivityService>();
            builder.Services.AddScoped<IFoodCategoryService, FoodCategoryService>();
            builder.Services.AddScoped<IFoodItemService, FoodItemService>();
            builder.Services.AddScoped<IFoodItemCategoryService, FoodItemCategoryService>();
            builder.Services.AddScoped<IMealService, MealService>();
            builder.Services.AddScoped<IMealFoodItemService, MealFoodItemService>();
            builder.Services.AddScoped<IMealPlanService, MealPlanService>();
            builder.Services.AddScoped<INutritionalGoalService, NutritionalGoalService>();
            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<IRecipeService, RecipeService>();
            builder.Services.AddScoped<IRecipeIngredientService, RecipeIngredientService>();
            builder.Services.AddScoped<IRecordService, RecordService>();
            builder.Services.AddScoped<IShoppingListService, ShoppingListService>();
            builder.Services.AddScoped<IShoppingListItemService, ShoppingListItemService>();
            builder.Services.AddScoped<ITipService, TipService>();
            builder.Services.AddScoped<IUserPreferenceService, UserPreferenceService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
                
            }));



            builder.Services.AddDbContext<������������_������Context>(
                options => options.UseSqlServer(builder.Configuration["ConnectionString"]));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "������� API",
                    Description = "API ������� ������� ���� ���� � ������� �������, ���������� � ����� ���� ���",
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.MapControllers();

            app.Run();


        }
    }
}