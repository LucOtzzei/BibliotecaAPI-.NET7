using FluentResults;
using Otzzei.Biblioteca.Domain.Entities;
using Otzzei.Biblioteca.Domain.Interfaces.IRepository;
using Otzzei.Biblioteca.Domain.Interfaces.IServices;
using Otzzei.Biblioteca.Domain.Requests;
using Otzzei.Biblioteca.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Domain.Services
{
    public class PublishingCompanyService : IPublishingCompanyService
    {
        private readonly IPublishingCompanyRepository _publishingCompanyRepository;
        public PublishingCompanyService(IPublishingCompanyRepository publishingCompanyRepository)
        {
            _publishingCompanyRepository = publishingCompanyRepository;
        }

        public async Task<Result<PublishingCompanyResponse>> CreatePublishingCompanyAsync(PublishingCompanyRequest request)
        {
            try
            {
                var publishingCompany = new PublishingCompany(request);
                var create = await _publishingCompanyRepository.CreatePublishingCompanyAsync(publishingCompany);

                var response = new PublishingCompanyResponse(create);
                return Result.Ok(response);
            }
            catch (Exception ex)
            {
                return Result.Fail($"Erro: {ex}");
            }
        }

        public async Task<Result<PublishingCompanyResponse>> GetByIdPublishingCompanyAsync(Guid id)
        {
            try
            {
                var publishingCompany = await _publishingCompanyRepository.GetByIdPublishingCompanyAsync(id);

                var response = new PublishingCompanyResponse(publishingCompany);
                return Result.Ok(response);
            }
            catch (Exception ex)
            {
                return Result.Fail($"Erro: {ex}");
            }
        }

        public async Task<Result<List<PublishingCompanyResponse>>> GetPublishingCompanyAsync()
        {
            try
            {
                var publishers = await _publishingCompanyRepository.GetPublishersAsync();

                return Result.Ok(publishers.Select(x => new PublishingCompanyResponse(x)).ToList());
            }
            catch (Exception ex)
            {
                return Result.Fail($"Erro: {ex}");
            }
        }

        public async Task<Result<PublishingCompanyResponse>> UpdatePublishingCompanyAsync(PublishingCompanyRequest request)
        {
            try
            {   var publishingCompany = new PublishingCompany(request);
                var update = await _publishingCompanyRepository.UpdatePublishingCompanyAsync(publishingCompany);

                var response = new PublishingCompanyResponse(update);
                return Result.Ok(response);
            }
            catch (Exception ex)
            {
                return Result.Fail($"Erro: {ex}");
            }
        }
    }
}
