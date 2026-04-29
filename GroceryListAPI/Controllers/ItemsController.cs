using GroceryListAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GroceryListAPI.Models;

namespace GroceryListAPI.Controllers
{
    [Route("items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private GroceryListService _groceryListService;
        
        public ItemsController(GroceryListService groceryListService) 
        {
            _groceryListService = groceryListService;
        }

        [HttpGet]
        public ActionResult<List<Item>> GetAllItems()
        {
            return _groceryListService.GetAllItems();
        }

        [HttpPost]
        public ActionResult<Item> AddItem([FromBody] Item item)
        {
            try
            {
                Item createdItem = _groceryListService.AddItem(item);
                return Ok(item);
            }
            catch
            {
                return BadRequest();
            }
        }

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

        [HttpPut]
        public ActionResult<Item> UpdateItem(int id, [FromBody] Item item)
        {
            try
            {
               _groceryListService.UpdateItem(id, item);
                return Ok(item);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
