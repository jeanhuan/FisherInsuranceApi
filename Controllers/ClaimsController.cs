using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/customer/claims")]

    public class ClaimsController : Controller {

        private readonly FisherContext db;

        public ClaimsController(FisherContext context) {

            db = context;

        }

        // Get claims
        [HttpGet]

        public IActionResult GetClaims() {

            return Ok(db.Claims);

        }

        // Get specific claim
        [HttpGet("{id}", Name = "GetClaim")]

        public IActionResult Get(int id) {

            return Ok(db.Claims.Find(id));

        }

        // Create new claim
        [HttpPost]

        public IActionResult Post([FromBody] Claim claim) {

            var newClaim = db.Claims.Add(claim);

            db.SaveChanges();

            return CreatedAtRoute("GetClaim", new {id = claim.Id}, claim);

        }

        // Update existing claim
        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody] Claim claim) {

            var newClaim = db.Claims.Find(id);

            if(newClaim == null) {

                return NotFound();
            }

            newClaim = claim;

            db.SaveChanges();

            return Ok(newClaim);

        }

        // Delete existiing claim
        [HttpDelete("{id}")] 

        public IActionResult Delete(int id) {

            var claimToDelete = db.Claims.Find(id);

            if(claimToDelete == null) {

                return NotFound();
            }

            db.Claims.Remove(claimToDelete);

            db.SaveChangesAsync();

            return NoContent();
        }
    }