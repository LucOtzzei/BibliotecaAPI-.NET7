using Otzzei.Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Requests
{
    public class BookRequest
    {
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public Guid PublishingCompanyId { get; set; }
    }
}
