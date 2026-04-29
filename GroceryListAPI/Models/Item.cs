namespace GroceryListAPI.Models
{
    public class Item
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool IsChecked { get; set; }

        public Item() 
        {
        
        }

        Item(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
            IsChecked = false;
        }
    }
}
