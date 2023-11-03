using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrightMinds.Models;

namespace FreeMovies.API.Models.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthors();
        Task<Author> GetAuthor(int id);
        Task<Author> AddAuthor(Author author);
        Task<Author> UpdateAuthor(Author author);
        void DeleteAuthor(int id);
    }
}