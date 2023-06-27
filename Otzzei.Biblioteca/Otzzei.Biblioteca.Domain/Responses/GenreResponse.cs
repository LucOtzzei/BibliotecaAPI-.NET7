using Otzzei.Biblioteca.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Responses
{
    public class GenreResponse
    {
        public GenreResponse(GenreEnum genres)
        {
            Genre = genres.ToString();
        }
        public string Genre { get; set; }
    }
}
