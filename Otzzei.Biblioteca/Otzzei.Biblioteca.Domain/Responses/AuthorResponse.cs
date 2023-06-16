using Otzzei.Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Responses
{
    public class AuthorResponse
    {
        public AuthorResponse(Author author)
        {
            Name = author.Name;
            Nationality = author.Nationality;
        }
        public string Name { get; set; }
        public string Nationality { get; set; }
    }
}
