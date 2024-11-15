namespace Питание.Contracts.ShoppingListItem
{
    public class UpdateShoppingListItemRequest
    {
        public int Shoppinglistid { get; set; }
        public int FoodItemid { get; set; }
        public double Quantity { get; set; }
    }
}
