using AutoMapper;
using Bogus;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebMotors.FernandoJose.Application.AppServices;
using WebMotors.FernandoJose.Application.AutoMapper;
using WebMotors.FernandoJose.Application.Interfaces;
using WebMotors.FernandoJose.Application.ViewModels;
using WebMotors.FernandoJose.Data.Dapper.Repositories;
using WebMotors.FernandoJose.Domain.Interfaces.Repositories;
using WebMotors.FernandoJose.Domain.Interfaces.Services;
using WebMotors.FernandoJose.Domain.Models;
using WebMotors.FernandoJose.Domain.Services;
using WebMotors.FernandoJose.Domain.Validacoes;
using Xunit;

namespace WebMotors.FernandoJose.UnitTest
{
    public class AnuncioUnitTest
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly ServiceProvider _services;
        private IAnuncioAppService _anuncioAppService;
        private readonly Mock<IAnuncioRepository> _anuncioRepositoryMock;
        private readonly Faker _faker;

        public AnuncioUnitTest()
        {
            // Faker
            _faker = new Faker();

            // Mock
            _anuncioRepositoryMock = new Mock<IAnuncioRepository>();

            // IoC
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddSingleton(_anuncioRepositoryMock.Object);
            _serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
            _serviceCollection.AddTransient<IDbConnection>(x => new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=teste_webmotors;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            _serviceCollection.AddTransient<AnuncioValidacao>();
            _serviceCollection.AddTransient<IAnuncioService, AnuncioService>();
            _serviceCollection.AddSingleton<IConfigurationProvider>(AutoMapperConfiguration.RegisterMappings());
            _serviceCollection.AddTransient<IMapper>(x => new Mapper(x.GetRequiredService<IConfigurationProvider>(), x.GetService));
            _serviceCollection.AddTransient<IAnuncioAppService, AnuncioAppService>();
            _services = _serviceCollection.BuildServiceProvider();
        }

        [Fact]
        public void Deve_Retornar_Uma_Mensagem_Marca_Obrigatoria_Quando_Nao_Passar_A_Marca_No_Adicionar()
        {
            _anuncioAppService = _services.GetService<IAnuncioAppService>();
            AnuncioAdicionarRequest request = new AnuncioAdicionarRequest
            {
                Marca = "",
                Modelo = _faker.Vehicle.Model(),
                Versao = _faker.Vehicle.Vin(),
                Ano = _faker.Random.Number(4, 4),
                Quilometragem = _faker.Random.Number(1, 3),
            };

            AnuncioAdicionarResponse response = _anuncioAppService.Adicionar(request);

            Assert.Contains(response.Erros, x => x.Descricao == "Marca é obrigatório" && x.Codigo == 400);
        }

        [Fact]
        public void Deve_Adicionar_Quando_Todos_Os_Campos_Estao_Preenchidos()
        {
            _anuncioAppService = _services.GetService<IAnuncioAppService>();
            AnuncioAdicionarRequest request = new AnuncioAdicionarRequest
            {
                Marca = _faker.Vehicle.Type(),
                Modelo = _faker.Vehicle.Model(),
                Versao = _faker.Vehicle.Vin(),
                Ano = _faker.Random.Number(2000, 2020),
                Quilometragem = _faker.Random.Number(100000),
            };

            _anuncioRepositoryMock.Setup(r => r.Adicionar(It.IsAny<Anuncio>())).Returns(_faker.Random.Number(1, 100));
            AnuncioAdicionarResponse response = _anuncioAppService.Adicionar(request);

            Assert.True(response.Id > 0);
            Assert.True(!response.Erros.Any());
        }

        // Fiz este exemplo com Theory para simular uma passagem de parametro 
        [Theory]
        [InlineData("Honda")]
        [InlineData("GM")]
        [InlineData("Toyota")]
        public void Deve_Retornar_Uma_Lista_De_Erros_Quando_So_Passar_A_Marca(string marca)
        {
            _anuncioAppService = _services.GetService<IAnuncioAppService>();
            AnuncioAdicionarRequest request = new AnuncioAdicionarRequest
            {
                Marca = marca,
            };

            _anuncioRepositoryMock.Setup(r => r.Adicionar(It.IsAny<Anuncio>())).Returns(_faker.Random.Number(1, 100));
            AnuncioAdicionarResponse response = _anuncioAppService.Adicionar(request);

            Assert.True(response.Id == 0);
            Assert.True(response.Erros.Any());
        }

        // TODO:: Incluir outros testes
    }
}