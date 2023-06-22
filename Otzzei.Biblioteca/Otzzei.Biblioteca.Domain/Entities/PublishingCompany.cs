using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Entities
{
    public class PublishingCompany
    {
        public PublishingCompany() { }
        public PublishingCompany(PublishingCompanyRequest request)
        {
            Id = Guid.NewGuid();
            Name = request.Name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
