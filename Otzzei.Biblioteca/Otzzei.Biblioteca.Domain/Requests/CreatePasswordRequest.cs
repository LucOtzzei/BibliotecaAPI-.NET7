using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Requests
{
    public class CreatePasswordRequest
    {
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
