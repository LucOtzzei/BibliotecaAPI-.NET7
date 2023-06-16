using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Otzzei.Biblioteca.Domain.Interfaces.IRepository;
using Otzzei.Biblioteca.Domain.Interfaces.IServices;
using Otzzei.Biblioteca.Domain.Services;
using Otzzei.Biblioteca.Infrastructure.Context;
using Otzzei.Biblioteca.Infrastructure.Repository;

namespace Otzzei.Biblioteca.Application
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.

            services.AddControllers();

            var connectionString = Configuration.GetConnectionString("BibliotecaDB");
            services.AddDbContext<BibliotecaContext>(opt => opt.UseSqlServer(connectionString));

            services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(
                opt => opt.SignIn.RequireConfirmedEmail = true)
                .AddEntityFrameworkStores<BibliotecaContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();

            services.AddMvc(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

        }
    }

    public interface IStartup
    {
        IConfiguration Configuration { get; }
        void Configure(IApplicationBuilder app, IWebHostEnvironment environment);
        void ConfigureServices(IServiceCollection services);

    }
}
