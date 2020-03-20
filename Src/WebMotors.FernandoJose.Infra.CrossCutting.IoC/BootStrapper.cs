using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using WebMotors.FernandoJose.Application.AppServices;
using WebMotors.FernandoJose.Application.AutoMapper;
using WebMotors.FernandoJose.Application.Interfaces;
using WebMotors.FernandoJose.Data.Dapper.Repositories;
using WebMotors.FernandoJose.Domain.Interfaces.Repositories;
using WebMotors.FernandoJose.Domain.Interfaces.Services;
using WebMotors.FernandoJose.Domain.Services;
using WebMotors.FernandoJose.Domain.Validacoes;

namespace WebMotors.FernandoJose.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Repository - Aqui gosto de usar variavel de ambiente ou keyvault do azure para proteger a conexão com o banco de dados
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDbConnection>(x => new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=teste_webmotors;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddTransient<IAnuncioRepository, AnuncioRepository>();

            // Validação
            services.AddTransient<AnuncioValidacao>();

            // Service
            services.AddTransient<IAnuncioService, AnuncioService>();

            // AppService
            services.AddSingleton<IConfigurationProvider>(AutoMapperConfiguration.RegisterMappings());
            services.AddTransient<IMapper>(x => new Mapper(x.GetRequiredService<IConfigurationProvider>(), x.GetService));
            services.AddTransient<IAnuncioAppService, AnuncioAppService>();
        }
    }
}