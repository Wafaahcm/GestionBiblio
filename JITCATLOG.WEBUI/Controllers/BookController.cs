using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JITCATALOG.APPLICATION.Features.Book.Query.GetBookList;
using JITCATALOG.APPLICATION.Features.Book.Query.GetBookDetails;
using JITCATALOG.APPLICATION.Contracts.Book.Commands.Create;
using JITCATALOG.APPLICATION.Features.Book.Commands.Update;
using JITCATALOG.APPLICATION.Module.Book.Commands.Delete;

namespace JITCATALOG.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetBookListViewModel>>> GetBookList()
        {
            try
            {
                var query = new GetBookListQuery();
                var result = await _mediator.Send(query);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetBookDetailsViewModel>> GetBookDetails(int id)
        {
            try
            {
                var query = new GetBookDetailsQuery { Id = id };
                var result = await _mediator.Send(query);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateBook([FromBody] CreateBookCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetBookDetails), new { id = result }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> UpdateBook(int id, [FromBody] UpdateBookCommand command)
        {
            try
            {
                command.Id = id;
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteBook(int id)
        {
            try
            {
                var command = new DeleteBookCommand { Id = id };
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
