using AutoMapper;
using BackendTestXP.Controllers;
using BackendTestXP.DTOs;
using BackendTestXP.Repository.Interfaces;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teste.Repository;
using Xunit;

namespace Teste.Controllers
{
    public class ClienteControllerTest
    {
        [Fact]
        public async Task PostCliente_TelefoneValido_ReturnsOkResult()
        {
            // Arrange
            var repository = A.Fake<IClienteRepository>();
            var mapper = A.Fake<IMapper>();
            var clienteController = new ClientesController(repository, mapper);

            var clienteDTO = new ClienteAdicionarDTO
            {
                Nome = "Gabriel",
                Telefone = "5521981955877",
                Idade = 26
            };

            A.CallTo(() => repository.SaveChanges()).Returns(true);

            // Act
            var result = await clienteController.PostCliente(clienteDTO);

            // Assert
            var okResult = result as OkObjectResult;
            okResult?.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task PostCliente_TelefoneInvalido_ReturnsBadRequest()
        {
            // Arrange
            var repository = A.Fake<IClienteRepository>();
            var mapper = A.Fake<IMapper>();
            var clienteController = new ClientesController(repository, mapper);

            var clienteDTO = new ClienteAdicionarDTO
            {
                Nome = "Gabriel",
                Telefone = "123",
                Idade = 26
            };

            // Act
            var result = await clienteController.PostCliente(clienteDTO);

            // Assert
            var badRequestResult = result as BadRequestObjectResult;
            badRequestResult?.Value.Should().Be("Telefone inválido");
            badRequestResult?.StatusCode.Should().Be(400);
        }
    }
}