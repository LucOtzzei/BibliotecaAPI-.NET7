using Microsoft.EntityFrameworkCore;
using Otzzei.Biblioteca.Domain.Entities;
using Otzzei.Biblioteca.Domain.Interfaces.IRepository;
using Otzzei.Biblioteca.Domain.Requests;
using Otzzei.Biblioteca.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.Biblioteca.Infrastructure.Repository
{
    public class PublishingCompanyRepository : IPublishingCompanyRepository
    {
        private readonly BibliotecaContext _context;
        public PublishingCompanyRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<PublishingCompany> CreatePublishingCompany(PublishingCompany publishingCompany)
        {
            await _context.PublishingCompanys.AddAsync(publishingCompany);
            await _context.SaveChangesAsync();
            return publishingCompany;
        }

        public async Task<PublishingCompany> GetByIdPublishingCompany(Guid id)
        {
            return await _context.PublishingCompanys.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PublishingCompany>> GetPublishingCompany()
        {
            return await _context.PublishingCompanys.ToListAsync();
        }

        public async Task<PublishingCompany> UpdatePublishingCompany(PublishingCompany publishingCompany)
        {
            _context.PublishingCompanys.Update(publishingCompany);
            await _context.SaveChangesAsync();
            return publishingCompany;
        }
    }
}
