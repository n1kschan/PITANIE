namespace Питание.Contracts.Allergen
{
    public class DeleteAllergenRequest
    {
        public int Allergenid { get; set; }
        public string AllergenName { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
