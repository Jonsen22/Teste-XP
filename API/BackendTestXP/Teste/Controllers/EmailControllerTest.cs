using AutoMapper;
using BackendTestXP.Controllers;
using BackendTestXP.DTOs;
using BackendTestXP.Repository.Interfaces;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPTesteAPI.Entities;

namespace Teste.Controllers
{
    public class EmailControllerTest
    {
        [Fact]
        public async Task PostEmail_EmailValido_ReturnsOkResult()
        {
            // Arrange
            var repository = A.Fake<IEmailRepository>();
            var mapper = A.Fake<IMapper>();
            var emailsController = new EmailsController(repository, mapper);

            var emailDto = new EmailAdicionarDTO
            {
                EnderecoEmail = "gabriel@gmail.com",
                 Principal = true,
            };

            A.CallTo(() => repository.SaveChanges()).Returns(true);

            // Act
            var result = await emailsController.PostEmail(emailDto);

            // Assert
            var okResult = result as OkObjectResult;
            okResult?.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task PostEmail_EmailInvalido_ReturnsBadRequest()
        {
            // Arrange
            var repository = A.Fake<IEmailRepository>();
            var mapper = A.Fake<IMapper>();
            var emailsController = new EmailsController(repository, mapper);

            var emailDto = new EmailAdicionarDTO
            {
                EnderecoEmail = "dwladklawk",
                Principal = true,

            };

            // Act
            var result = await emailsController.PostEmail(emailDto);

            // Assert
            var badRequestResult = result as BadRequestObjectResult;
            badRequestResult?.Value.Should().Be("Email inválido");
            badRequestResult?.StatusCode.Should().Be(400);
        }
    }
}
