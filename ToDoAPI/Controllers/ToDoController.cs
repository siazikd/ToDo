using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;
using ToDoAPI.Repository;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _repository;

        public ToDoController(IToDoRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetToDoItems()
        {
            try
            {
                return Ok(await _repository.GetToDoItemsAsync());
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItemById(int id)
        {
            try
            {
                var result = await _repository.GetToDoItemByIdAsync(id);
                return result == null ? NotFound() : result;
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }
        [HttpPost]
        public async Task<ActionResult<ToDoItem>> CreateToDoItem(ToDoItem item)
        {
            try
            {
                if (item == null)
                    return BadRequest();
                var result = await _repository.AddToDoItemAsync(item);
                return CreatedAtAction(nameof(GetToDoItemById), new { id = result.Id }, result);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ToDoItem>> UpdateToDoItem(int id, ToDoItem item)
        {
            try
            {
                if (item == null || id != item.Id)
                    return BadRequest();

                if (ModelState.IsValid)
                {
                    var result = await _repository.GetToDoItemByIdAsync(item.Id);

                    return result == null ? NotFound() : await _repository.UpdateToDoItemAsync(item);
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "Error");

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ToDoItem>> DeleteToDoItem(int id)
        {
            try
            {
                var result = await _repository.GetToDoItemByIdAsync(id);

                if (result == null)
                    return NotFound();

                await _repository.DeleteToDoItemAsync(result.Id);

                return Ok();


            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

    }
}
