namespace Питание.Contracts.ShoppingListItem
{
    public class DeleteShoppingListItemRequest
    {
        public int Shoppinglistitemid { get; set; }
        public int Shoppinglistid { get; set; }
        public int FoodItemid { get; set; }
        public double Quantity { get; set; }
    }
}
