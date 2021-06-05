using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorApi.DataAcces;
using AuthorApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private AuthorDBContext AuthorDbContext;

        [HttpGet]
        [Route("/author")]
        public async Task<ActionResult<IList<Author>>> GetAuthors()
        {
            try
            {
                IList<Author> authors = await AuthorDbContext.Authors.ToListAsync();
                return Ok(authors);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("/author")]
        public async Task<ActionResult<Author>> AddTodo([FromBody] Author author)
        {
            Console.WriteLine("Got a new author to create " + author.FirstName );
            
            try
            {
                await AuthorDbContext.Authors.AddAsync(author);
                AuthorDbContext.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}