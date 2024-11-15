namespace Питание.Contracts.FoodCategory
{
    public class DeleteFoodCategoryRequest
    {
        public int FoodCategoryid { get; set; }
        public string Categoryname { get; set; } = null!;
    }
}
