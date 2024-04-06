using Microsoft.AspNetCore.Mvc;
using Project.Green.General.Domain.Catalog;

namespace Project.Green.General.Api.Controllers {
    [ApiController]
    [Route("[controller]")]

    public class CatalogController: ControllerBase {
        [HttpGet]

        public IActionResult GetItems(){

            var items = new List<Item>(){
                new Item("Shirt", "Ohio State Shirt", "Nike", 29.99m),
                new Item("Shorts", "Ohio State Shorts", "Nike", 44.99m)
            };
            return Ok(items);
        }

        [HttpGet("{id:int}")]

        public IActionResult GetItem(int id) {
            var item = new Item("Shirt", "Ohio State Shirt", "Nike", 29.99m);
            item.Id = id;
            return Ok(item);
        }
    }
}