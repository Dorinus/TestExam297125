using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorApi.Models;

namespace AuthorBlazor.Data
{
    public interface IAuthorManager
    {
        Task<Author> createAuthor(Author author);
        Task<IList<Author>> getAuthots();

    }
}