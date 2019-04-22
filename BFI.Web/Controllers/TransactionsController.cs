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
        static List<Transaction> _transactions= new List<Transaction>();
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_transactions.Select(t => new Transaction
            {
                Account = t.Account,
                Date = t.Date,
                Description = t.Description.Split(" - ")[0],
                Amount = t.Amount
            }));
        }

        // POST api/<controller>/upload
        [HttpPost("upload")]
        public ActionResult Post(UploadFileModel model)
        {
            using (var stream = model.File.OpenReadStream())
            {
                _transactions = stream.ToTransactions(model.Name).ToList();
            }

            return Ok();
        }

        public class UploadFileModel
        {
            public string Name { get; set; }
            public IFormFile File { get; set; }
        }
    }
}
