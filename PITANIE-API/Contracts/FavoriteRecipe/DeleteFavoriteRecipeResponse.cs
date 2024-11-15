namespace Питание.Contracts.FavoriteRecipe
{
    public class DeleteFavoriteRecipeRequest
    {
        public int FavoriteRecipeid { get; set; }
        public int Userid { get; set; }
        public int Recipeid { get; set; }
    }
}
