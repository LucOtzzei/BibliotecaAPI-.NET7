using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Entities
{
    public class Book
    {
        public Book() { }
        public Book(BookRequest request)
        {
            Id = Guid.NewGuid();
            Name = request.Name;
            Genre = request.Genre;
            AuthorId = request.AuthorId;
            PublishingCompany = request.PublishedCompanyId;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public GenreEnum Genre { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public Guid PublishingCompanyId {  get; set; }
        public PublishingCompany PublishingCompany { get; set; }
    }
}
