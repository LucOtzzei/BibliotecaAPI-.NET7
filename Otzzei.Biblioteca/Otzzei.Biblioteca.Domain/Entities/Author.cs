using Otzzei.Biblioteca.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Entities
{
    public class Author
    {
        public Author() { }
        public Author(AuthorRequest request)
        {
            Id = Guid.NewGuid();
            Name = request.Name;
            Nationality = request.Nationality;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }

        public void Update(AuthorRequest request)
        {
            Name = request.Name;
            Nationality = request.Nationality;
        }
    }
}
