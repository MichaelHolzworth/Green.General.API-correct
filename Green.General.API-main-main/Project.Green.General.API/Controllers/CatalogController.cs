using Microsoft.AspNetCore.Mvc;
using Project.Green.General.Domain.Catalog;
using Project.Green.General.Data;

namespace Project.Green.General.Api.Controllers {
    [ApiController]
    [Route("/catalog")]

    public class CatalogController: ControllerBase {

        private readonly StoreContext _db;

        public CatalogController(StoreContext db)
        {
            _db = db;
        }
        
        /*
        [HttpGet]

        public IActionResult GetItems(){

            var items = new List<Item>(){
                new Item("Shirt", "Ohio State Shirt", "Nike", 29.99m),
                new Item("Shorts", "Ohio State Shorts", "Nike", 44.99m)
            };
            return Ok(items);
        }
        */

        [HttpGet("{id:int}")]

        public IActionResult GetItem(int id) {
            var item = Ok(_db.Items.Find(id));
            if(item == null){
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost("{id}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating){

            var item = _db.Items.Find(id);
            if(item == null){
                return NotFound();
            }
            item.AddRating(rating);
            _db.SaveChanges();

            return Ok(item);
        }


        [HttpPut("{id:int}")]
        public IActionResult PutItem(int id, [FromBody] Item item){
            //_db.Set<Item>().AsNoTracking();
            if(id != item.Id){
                return BadRequest();
            }
            if(_db.Items.Find(id) == null){
                return NotFound();
            }
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();

            return NoContent();
        }

        /*
        Testing put using the following data in the body of the message:
                {
                    "id": 1,
                    "name": "Shirt",
                    "description": "Ohio State Shirt",
                    "brand": "Nike",
                    "price": 29.99,
                    "ratings": [
                        {
                            "stars": 5,
                            "userName": "John Smith",
                            "review": "Great!"
                        }
                    ]
                }
        */
        
        [HttpPost]
        public IActionResult Post (Item item){
            _db.Items.Add(item);
            _db.SaveChanges();
            return Created($"/catalog/{item.Id}", item);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete (int id){
            var item = _db.Items.Find(id);
            if (item == null){
                return NotFound();
            }

            _db.Items.Remove(item);
            _db.SaveChanges();

            return Ok();
        }

    }
}