using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class ShoppingList
    {
        public ShoppingList()
        {
            ShoppingListItems = new HashSet<ShoppingListItem>();
        }

        public int ShoppingListId { get; set; }
        public int? UserId { get; set; }
        public string? ListName { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<ShoppingListItem> ShoppingListItems { get; set; }
    }
}
