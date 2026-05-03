using GroceryListAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GroceryListAPI.Services
{
    /// <summary>
    /// List to contain all user's items
    /// </summary>
    public class GroceryListService
    {
        public static List<Item> groceryList = new List<Item>();

        private int _idCounter = 1;

        // Returns all items in list
        public List<Item> GetAllItems()
        {

        return groceryList;

        }

        /// <summary>
        /// Creates a new item and adds to list
        /// </summary>
        /// <param name="name">Name of item</param>
        /// <param name="quantity">Quantity of item</param>
        /// <returns>The item created</returns>
        /// <exception cref="Exception">Name cannot be empty; Quantity must be higher than 0</exception>
        public Item AddItem(String name, int quantity)
        {
            Item item = new Item(name, quantity);

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                throw new Exception("Name cannot be empty");
            }

            if (item.Quantity <= 0)
            {
                throw new Exception("Quantity must be higher than 0");
            }

            item.IsChecked = false;

            // Sets item Id and increments to keep unique
            item.Id = _idCounter++;

            groceryList.Add(item);
            return item;
        }

        /// <summary>
        /// Finds a specific item in the grocery list
        /// </summary>
        /// <param name="id">Id of the item being found</param>
        /// <returns>The searched for Item</returns>
        /// <exception cref="Exception">Item not found if Id is not in list</exception>
        public Item GetItemById(int id)
        {
            // searches grocery list and returns first instance of id or null
            Item? searchItem = groceryList.FirstOrDefault(x => x.Id == id);
            
            if (searchItem == null)
            {
                throw new Exception("Item not found");
            }

            return searchItem;
        }

        /// <summary>
        /// Deletes an item from grocery list by id
        /// </summary>
        /// <param name="id">id of item to delete</param>
        /// <exception cref="Exception">Item not found If Id is not found in list</exception>
        public void DeleteItemById(int id)
        {
            for (int i = 0; i < groceryList.Count(); i++)
            {
                if (groceryList[i].Id == id)
                {
                    groceryList.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Item not found");
        }

        /// <summary>
        /// Updates an item in the grocery list
        /// </summary>
        /// <param name="id">Id of item to update</param>
        /// <param name="updateName">Name to update item name to</param>
        /// <param name="updateQuantity">Quantity to update item quantity to</param>
        /// <returns></returns>
        public Item UpdateItem(int id, string updateName, int updateQuantity)
        {
            Item currentItem;
            
            currentItem = GetItemById(id);

            // If no new name is passed in, keep current name
            if (updateName != null)
            {
                currentItem.Name = updateName;
            }
            //  If user changes to negative quantity set quantity to 0
            if (updateQuantity < 0)
            {
                currentItem.Quantity = 0;
            }
            else
            {
                currentItem.Quantity = updateQuantity;
            }

            return currentItem;


        }

        /// <summary>
        /// Toggles IsChecked to true/false
        /// </summary>
        /// <param name="id">Id of item to toggle</param>
        /// <returns>Item with new IsChecked</returns>
        public Item SelectItem(int id)
        {
            Item currentItem = GetItemById(id);
            if (currentItem.IsChecked == true)
            {
                currentItem.IsChecked = false;
                return currentItem;
            }
            currentItem.IsChecked = true;
            return currentItem;
        }
    }
}
