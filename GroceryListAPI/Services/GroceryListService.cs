using GroceryListAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace GroceryListAPI.Services
{
    public class GroceryListService
    {
        public static List<Item> groceryList = new List<Item>();

        public List<Item> GetAllItems()
        {

        return groceryList;
        }

        public int GetNewId()
        {
            int max = 0;

            for (int i = 0; i < groceryList.Count(); i++)
            {
                if (groceryList[i].Id > max)
                {
                    max = groceryList[i].Id;
                }
            }
            return max + 1; 
        }

        public Item AddItem(Item item)
        {
            if (string.IsNullOrWhiteSpace(item.Name))
            {
                throw new Exception("Name cannot be empty");
            }

            if (item.Quantity <= 0)
            {
                throw new Exception("Quantity must be higher than 0");
            }

            item.IsChecked = false;

            if (item.Id < 1)
            {
                item.Id = GetNewId();
            }

            groceryList.Add(item);
            return item;
        }

        public Item GetItemById(int id)
        {
            for (int i = 0;i < groceryList.Count();i++)
            {
                if (groceryList[i].Id == id)
                {
                    return groceryList[i];
                }
            }
            throw new Exception("Item not found");
        }

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

        public Item UpdateItem(int id, Item updatedItem)
        {
            Item currentItem;
            
            currentItem = GetItemById(id);

            currentItem.Name = updatedItem.Name;
            currentItem.Quantity = updatedItem.Quantity;


            return currentItem;


        }
    }
}
