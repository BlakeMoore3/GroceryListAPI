using GroceryListAPI.Services;
using GroceryListAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GroceryListAPI.Models;

namespace GroceryListAPI.Controllers
{
    [Route("items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private GroceryDbContext _context;
        
        public ItemsController(GroceryDbContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Displays all the items on the grocery list
        /// </summary>
        /// <returns>The entire list of items</returns>
        [HttpGet]
        public ActionResult<List<Item>> GetAllItems()
        {
            return _context.Items.ToList();
        }

        /// <summary>
        /// Adds a new item to the grocery list
        /// </summary>
        /// <param name="name">The name for the item</param>
        /// <param name="quantity">The quantity of the named item</param>
        /// <returns>The newly added item including IsChecked set false and unique Id</returns>
        [HttpPost]
        public ActionResult<Item> AddItem([FromBody] Item item)
        {
            try
            {
                item.Id = 0;
                item.IsChecked = false;
                _context.Items.Add(item);
                _context.SaveChanges();
                return Ok(item);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Will return a specific item based on item Id
        /// </summary>
        /// <param name="id">Id of item to search for</param>
        /// <returns>The searched for item; If not found returns 404 error</returns>
        [HttpGet("{id}")]
        public ActionResult<Item> GetItemById(int id)
        {
            try
            {
                return _groceryListService.GetItemById(id);
            }
            catch
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Deletes an item from the list selected by item Id
        /// </summary>
        /// <param name="id">Id of the Item user wants to delete</param>
        /// <returns>Returns 204 no content success; If item not found on list retruns 404 not found</returns>
        [HttpDelete]
        public ActionResult DeleteItem(int id)
        {
            try
            {
                _groceryListService.DeleteItemById(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Will update an items Name and Quantity based on item Id
        /// </summary>
        /// <param name="id">Id of item to update</param>
        /// <param name="name">New name for the item</param>
        /// <param name="quantity">New Quantity for the item</param>
        /// <returns>The item with an updated name and quantity</returns>
        [HttpPut]
        public ActionResult<Item> UpdateItem(int id, [FromBody] string? name, int quantity)
        {
            try
            {
               Item updatedItem = _groceryListService.UpdateItem(id, name, quantity);
                return Ok(updatedItem);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Toggles IsChecked yes/no on the searched for item
        /// </summary>
        /// <param name="id">Id of item to toggle</param>
        /// <returns>Full item with toggled IsChecked</returns>
        [HttpPatch("{id}/toggle")]
        public ActionResult<Item> ToggleIsChecked(int id)
        {
            try
            {
                Item updatedItem = _groceryListService.SelectItem(id);
                return Ok(updatedItem);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
