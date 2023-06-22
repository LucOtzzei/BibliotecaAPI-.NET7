using Otzzei.Biblioteca.Domain.Entities;
using Otzzei.Biblioteca.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Interfaces.IRepository
{
    public interface IPublishingCompanyRepository
    {
        Task<PublishingCompany> CreatePublishingCompanyAsync(PublishingCompany request);
        Task<PublishingCompany> UpdatePublishingCompanyAsync(PublishingCompany request);
        Task<PublishingCompany> GetByIdPublishingCompanyAsync(Guid id);
        Task<List<PublishingCompany>> GetPublishersAsync();
    }
}
