using Microsoft.EntityFrameworkCore;
using SistemaWeb.Api.Context;
using SistemaWeb.Api.Repositories;
using SistemaWeb.Api.Services;
using SistemaWeb.Shared.Repositories;
using SistemaWeb.Shared.Services;

namespace SistemaWeb.Api.Common
{
    public static class BuildExtension
    {
        public static void AddDataContext(this WebApplicationBuilder builder)
        {
            builder.Services
                    .AddDbContext<AppWebDbContext>(
                            options => options.UseSqlServer(builder.Configuration[Configuration.ConnectionString]));
        }
        public static void AddSwaggerDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddControllers();
            builder.Services.AddScoped<IFornecedorService, FornecedorService>();
            builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            builder.Services.AddScoped<IProdutoService, ProdutoService>();
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}
