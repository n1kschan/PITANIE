using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class ShoppingListItem
    {
        public int ShoppingListItemId { get; set; }
        public int? ShoppingListId { get; set; }
        public int? FoodItemId { get; set; }
        public decimal? Quantity { get; set; }

        public virtual FoodItem? FoodItem { get; set; }
        public virtual ShoppingList? ShoppingList { get; set; }
    }
}
