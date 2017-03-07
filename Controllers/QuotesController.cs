using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/quotes")]

    public class QuotesController : Controller {
        
       private readonly FisherContext db;

        public QuotesController(FisherContext context) {

            db = context;

        }

        // Get quotes
        [HttpGet]

        public IActionResult GetQuotes() {

            return Ok(db.Quotes);

        }

        // Get specific quote
        [HttpGet("{id}", Name = "GetQuote")]

        public IActionResult Get(int id) {

            return Ok(db.Quotes.Find(id));

        }

        // Create new quote
        [HttpPost]

        public IActionResult Post([FromBody] Quote quote) {

            var newQuote = db.Quotes.Add(quote);

            db.SaveChanges();

            return CreatedAtRoute("GetQuote", new {id = quote.Id}, quote);

        }

        // Update existing quote
        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody] Quote quote) {

            var newQuote = db.Quotes.Find(id);

            if(newQuote == null) {

                return NotFound();
            }

            newQuote = quote;

            db.SaveChanges();

            return Ok(newQuote);

        }

        // Delete existiing quote
        [HttpDelete("{id}")] 

        public IActionResult Delete(int id) {

            var quoteToDelete = db.Quotes.Find(id);

            if(quoteToDelete == null) {

                return NotFound();
            }

            db.Quotes.Remove(quoteToDelete);

            db.SaveChangesAsync();

            return NoContent();
        }
    }