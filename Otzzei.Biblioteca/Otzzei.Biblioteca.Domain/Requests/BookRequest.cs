using Otzzei.Biblioteca.Domain.Enums;
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
        public List<GenreEnum> GenreEnums { get; set; }
        public Guid AuthorId { get; set; }
        public Guid PublishingCompanyId { get; set; }
    }
}
