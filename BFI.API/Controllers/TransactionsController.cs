using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BFI.Application.Transactions;
using BFI.Application.Transactions.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BFI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        IMediator _mediator;
        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            //return await _mediator.Send(new GetTransactions());
            return Ok(
                new List<Transaction>
                {
                    new Transaction { Account = "Account", Date = DateTime.Today, Description = "Test", Amount = 10M }
                });
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransactions()
        {
            if (Request.Form.Files.Any())
            {
                var file = Request.Form.Files[0];
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    await _mediator.Send(new ImportTransactions(stream));
                }
                return Ok();
            }
            return BadRequest();
        }
    }
}
