namespace GroceryListAPI.Models
{
    /// <summary>
    /// A single item on a user's grocery list
    /// </summary>
    public class Item
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool IsChecked { get; set; }

        public Item() 
        {
        
        }

        /// <summary>
        /// Initializes a new item witha default ID of -1
        /// </summary>
        /// <param name="name">The name of the item</param>
        /// <param name="quantity">The quantity of the item</param>
        public Item(string name, int quantity)
        {
            Id = -1;
            Name = name;
            Quantity = quantity;
            IsChecked = false;
        }
    }
}
