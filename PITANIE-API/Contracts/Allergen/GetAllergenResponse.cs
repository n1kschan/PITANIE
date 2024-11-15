namespace Питание.Contracts.Allergen
{
    public class GetAllergenResponse
    {
        public int Allergenid { get; set; }
        public string AllergenName { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
