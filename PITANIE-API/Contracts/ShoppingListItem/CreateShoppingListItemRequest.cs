namespace Питание.Contracts.ShoppingListItem
{
    public class CreateShoppingListItemRequest
    {
        public int Shoppinglistid { get; set; }
        public int FoodItemid { get; set; }
        public decimal Quantity { get; set; }
    }
}
