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
    public class BookController
    {
        private AuthorDBContext AuthorDbContext;

        [HttpGet]
        [Route("/book")]
        public async Task<IList<Book>> GetBooks()
        {
            try
            {
                IList<Book> books = await AuthorDbContext.Books.ToListAsync();
                return books;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("/book/{id:int}")]
        public async Task<bool> AddTodo([FromBody] Book book, [FromRoute] int id)
        {
            try
            {
                var author = await 
                    AuthorDbContext.Authors.Include(b => b.Books).
                        FirstAsync(a => a.Id == id);
                
                author.Books.Add(book);
                
                AuthorDbContext.Update(author);
                await AuthorDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        
    }
}