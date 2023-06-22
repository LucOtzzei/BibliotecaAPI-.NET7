using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Otzzei.Biblioteca.Domain.Entities;

namespace Otzzei.Biblioteca.Infrastructure.Context
{
    public class BibliotecaContext: IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> opts) : base(opts) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<PublishingCompany> PublishingCompanys { get; set;}
    }
}
