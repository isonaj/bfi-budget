using System.Collections.Generic;
using System.Linq;
using BFI.Domain;
using BFI.Domain.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BFI.Web.Controllers
{
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        static List<Transaction> _transactions;
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_transactions);
        }

        // POST api/<controller>/upload
        [HttpPost("upload")]
        public ActionResult Post(/*[FromBody]*/IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                _transactions = stream.ToTransactions().ToList();
            }

            return Ok();
        }
    }
}
