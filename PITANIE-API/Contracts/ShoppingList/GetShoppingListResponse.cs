namespace Питание.Contracts.ShoppingList
{
    public class GetShoppingListResponse
    {
        public int Shoppinglistid { get; set; }
        public int Userid { get; set; }
        public string Listname { get; set; } = null!;
        public DateTime Createdat { get; set; }
    }
}
