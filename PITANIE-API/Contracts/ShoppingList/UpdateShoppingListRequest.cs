namespace Питание.Contracts.ShoppingList
{
    public class UpdateShoppingListRequest
    {
        public int Userid { get; set; }
        public string Listname { get; set; } = null!;
        public DateTime Createdat { get; set; }
    }
}
