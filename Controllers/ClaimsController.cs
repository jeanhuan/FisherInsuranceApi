using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/customer/claims")]

    public class ClaimsController : Controller {

        private IMemoryStore db;

        public ClaimsController(IMemoryStore repo) {

            db = repo;
        }

        // POST api/customer/claims

        [HttpPost]

        public IActionResult Post([FromBody]Claim claim) {

            return Ok(db.CreateClaim(claim));

        }

        // GET all claims

        [HttpGet]

        public IActionResult GetClaims() {

            return Ok(db.RetrieveAllClaims);
        }

        // GET api/customer/claims/5

        [HttpGet("{id}")]

        public IActionResult Get(int id) {

            return Ok(db.RetrieveQuote(id));
        }

        // PUT api/customer/claims/id

        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody]Claim claim) {

            return Ok(db.UpdateClaim(claim));
        }

        // DELETE api/customer/claims/id

        [HttpDelete("{id}")]

        public IActionResult DeleteClaim(int id, [FromBody]Claim claim) {

            db.DeleteClaim(id);

            return Ok();

        }
        
    }