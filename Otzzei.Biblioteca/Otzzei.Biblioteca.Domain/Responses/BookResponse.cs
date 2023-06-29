using Otzzei.Biblioteca.Domain.Entities;
using Otzzei.Biblioteca.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Responses
{
    public class BookResponse
    {
        public BookResponse(Book book, List<Genre> genres)
        {
            Name = book.Name;
            Genres = genres.Select(x => new GenreResponse(x)).ToList();
            Author = book.AuthorId;
            PublishingCompany = book.PublishingCompanyId;
        }
        public BookResponse(string name, List<Genre> genres, AuthorResponse author, PublishingCompanyResponse publisher)
        {
            Name = name;
            Genres = genres.Select(x => new GenreResponse(x)).ToList();
            Author = author;
            PublishingCompany = publisher;
        }
        public string Name { get; set; }
        public List<GenreResponse> Genres { get; set; }
        public AuthorResponse Author { get; set; }
        public PublishingCompanyResponse PublishingCompany { get; set; }
    }
}
