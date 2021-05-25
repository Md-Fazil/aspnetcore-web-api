using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _publishersService;

        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers(string sortBy, string searchString)
        {
            try
            {
                var _result = _publishersService.GetAllPublishers(sortBy, searchString);
                return Ok(_result);
            }
            catch (Exception)
            {
                return BadRequest("Sorry, we could not load the publishers");
            }
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody]PublisherVM publisher)
        {
            _publishersService.AddPublisher(publisher);
            return Ok();
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public ActionResult<Publisher> GetPublisherById(int id)
        {
            var response = _publishersService.GetPublisherById(id);

            if (response != null)
            {
                return response;
            }

            return NotFound();
        }


        [HttpGet("get-publishers-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publishersService.getPublisherData(id);
            return Ok(_response);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            _publishersService.DeletePublisherById(id);
            return Ok();
        }
    }
}
