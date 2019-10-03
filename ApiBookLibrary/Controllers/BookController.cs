using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiBookLibrary.Models;
using ApiBookLibrary.Repository;





namespace ApiBookLibrary.Controllers
{
    [Route("[controller]")]
    public class BookController : Controller
    {

        private IBookRepository _repository { get; set; }


        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }       



        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _repository.GetAsync(id);
            if(result == null)
                return NotFound();
            else
                return Ok(result);
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result =   _repository.Query().ToList();
            if(result == null)
                return NotFound();
            else
                return Ok(result);
        }




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BookModel book)
        {    
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }       
            else
            {
                await _repository.InsertAsync(book);
                return Created($"book;{book.Id}", book);                
            } 
            
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]BookModel book, int id)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            
            var result = await _repository.GetAsync(id);

            if(result == null)
                return NotFound();

            result.Title = book.Title;
            result.SubTitle = book.SubTitle;
            result.Description = book.Description;
            result.Year = book.Year;

            await _repository.UpdateAsync(result);
            return Ok(book);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _repository.GetAsync(id);
            
            if(book == null)
                return NotFound();
            
            await _repository.DeleteAsync(id);
            return Ok();

        }
        
    }
}