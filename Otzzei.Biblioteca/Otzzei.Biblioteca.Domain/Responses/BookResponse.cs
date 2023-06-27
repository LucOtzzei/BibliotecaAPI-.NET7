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
        public BookResponse(string name, List<GenreEnum> genreEnums, AuthorResponse author, PublishingCompanyResponse publisher)
        {
            Name = name;
            Genres = genreEnums.Select(x => new GenreResponse(x)).ToList();
            Author = author;
            PublishingCompany = publisher;
        }
        public string Name { get; set; }
        public List<GenreResponse> Genres { get; set; }
        public AuthorResponse Author { get; set; }
        public PublishingCompanyResponse PublishingCompany { get; set; }
    }
}
