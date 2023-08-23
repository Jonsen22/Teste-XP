using BackendTestXP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XPTesteAPI.Entities;
using BackendTestXP.Repository;
using FluentAssertions;

namespace Teste.Repository
{
    public class ClienteRepositoryTest
    {
        protected async Task<AppDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new AppDbContext(options);
            databaseContext.Database.EnsureCreated();

            if (await databaseContext.Cliente.CountAsync() < 0)
            {
                for (int i = 0; i < 10; i++)
                {

                    databaseContext.Cliente.Add(
                    new Cliente()
                    {
                        Id = 1,
                        Nome = "Gabriel",
                        Idade = 26,
                        Enderecos = new List<Endereco>
                        {
                        new Endereco
                        {
                            Rua = "Rua A",
                            Numero = "123",
                            Cidade = "São Paulo",
                            Estado = "SP",
                            Cep = "12345-678"
                        },
                        new Endereco
                        {
                            Rua = "Rua B",
                            Numero = "456",
                            Cidade = "Rio de Janeiro",
                            Estado = "RJ",
                            Cep = "98765-432"
                        }
                        },
                        Emails = new List<Email>
                        {
                        new Email
                        {
                            EnderecoEmail = "gabriel@example.com"
                        },
                        new Email
                        {
                            EnderecoEmail = "contato@example.com"
                        }
                        }
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }

        [Fact]
        public async void ClienteRepository_Add_ReturnsBool()
        {
            var cliente = new Cliente()
            {
                Id = 1,
                Nome = "Gabriel",
                Idade = 26,
                Enderecos = new List<Endereco>
                        {
                        new Endereco
                        {
                            Rua = "Rua A",
                            Numero = "123",
                            Cidade = "São Paulo",
                            Estado = "SP",
                            Cep = "12345-678"
                        },
                        new Endereco
                        {
                            Rua = "Rua B",
                            Numero = "456",
                            Cidade = "Rio de Janeiro",
                            Estado = "RJ",
                            Cep = "98765-432"
                        }
                        },
                Emails = new List<Email>
                        {
                        new Email
                        {
                            EnderecoEmail = "gabriel@example.com"
                        },
                        new Email
                        {
                            EnderecoEmail = "contato@example.com"
                        }
                        }
            };

            var dbContext = await GetDbContext();
            var clienteRepository = new ClienteRepository(dbContext);

            var result = clienteRepository.Add(cliente);

            result.Should().BeTrue();
        }
    }
}
