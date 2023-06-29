using Otzzei.Biblioteca.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Entities
{
    public class Genre
    {
        public Genre() { }
        public Genre(GenreEnum genre, Guid bookId) 
        { 
            Id = Guid.NewGuid();
            GenreBook = genre;
            BookId = bookId;
        }
        public Guid Id { get; set; }
        public GenreEnum GenreBook {  get; set; }
        public Guid BookId { get; set; }
    }
}
