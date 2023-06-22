using FluentResults;
using Otzzei.Biblioteca.Domain.Requests;
using Otzzei.Biblioteca.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Interfaces.IServices
{
    public interface IPublishingCompanyService
    {
        Task<Result<PublishingCompanyResponse>> CreatePublishingCompanyAsync(PublishingCompanyRequest request);
        Task<Result<PublishingCompanyResponse>> UpdatePublishingCompanyAsync(PublishingCompanyRequest request);
        Task<Result<PublishingCompanyResponse>> GetByIdPublishingCompanyAsync(Guid id);
        Task<Result<List<PublishingCompanyResponse>>> GetPublishingCompanyAsync();
    }
}
