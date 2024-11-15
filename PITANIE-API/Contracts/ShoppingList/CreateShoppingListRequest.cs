namespace Питание.Contracts.ShoppingList
{
    public class CreateShoppingListRequest
    {
        public int Userid { get; set; }
        public string Listname { get; set; } = null!;
        public DateTime Createdat { get; set; }
    }
}
