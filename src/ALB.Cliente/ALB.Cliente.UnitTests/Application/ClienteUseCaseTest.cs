using ALB.Cliente.Application.UseCases;
using ALB.Cliente.Domain.Entities;
using ALB.Cliente.Domain.Interfaces;
using ALB.Cliente.UnitTests.Util;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ALB.Cliente.UnitTests.Application
{
    public class ClienteUseCaseTest
    {
        [TestCase(Description = "GetAllAsync_Success : Deve retornar todas as entidades")]
        public void GetAllAsync_Success() {
            var mockEntity = new BuilderCliente().GetBuildEntityAsync(3, null);
            var mockRepository = new Mock<IClienteRepository>();
            var mockLogger = new Mock<ILogger<ClienteGetUseCase>>();

            //mocka o retorno do repository
            mockRepository.Setup(s => s.GetAll()).Returns(mockEntity);
            var useCase = new ClienteGetUseCase(mockRepository.Object, mockLogger.Object);
            var result = useCase.Execute(null).Result;

            //O Resultado da consulta deverá ser todos os registros inseridos no mock de entidades
            result.Count().Should().Be(mockEntity.Result.Count());
        }
        [TestCase(Description = "GetAsync_by_id_Success : Deve retornar a entidade de acordo com o id")]
        public void GetAsync_by_id_Success()
        {
            Guid id = Guid.NewGuid();

            var mockEntity = new BuilderCliente().GetBuildEntity(id);            

            var mockRepository = new Mock<IClienteRepository>();
            var mockLogger = new Mock<ILogger<ClienteGetbyCodeUseCase>>();

            //mocka o retorno do repository
            mockRepository.Setup(s => s.Get(id)).Returns(mockEntity);
            var useCase = new ClienteGetbyCodeUseCase(mockRepository.Object, mockLogger.Object);

            ClienteEntity result = useCase.Execute(id.ToString()).Result;

            //O Resultado da consulta deverá ser a entidade que corresponda ao id informado
            result.Id.Should().Be(id);
        }
        [TestCase(Description = "GetAsync_by_Filter_Success : Deve retornar as entidades que correspondam ao filtro")]
        public void GetAsync_by_Filter_Success()
        {
            var mockEntity = new BuilderCliente().GetBuildEntityAsync(3, null);
            var mockRepository = new Mock<IClienteRepository>();
            var mockLogger = new Mock<ILogger<ClienteGetUseCase>>();

            //mocka o retorno do repository
            mockRepository.Setup(s => s.GetWhere(It.IsAny<Func<ClienteEntity, bool>>())).Returns(mockEntity);
            var useCase = new ClienteGetUseCase(mockRepository.Object, mockLogger.Object);
            var result = useCase.Execute(new ClienteEntity { Nome = "teste" }).Result;

            //O Resultado da consulta deverá ser todos os registros inseridos no mock de entidades
            result.Count().Should().Be(mockEntity.Result.Count());
        }

        [TestCase(Description = "InsertAsync_Success : Deve ser válido a incusão")]
        public async Task InsertAsync_Success()
        {
            Guid id = Guid.NewGuid();
            var mockEntity = new BuilderCliente().GetBuildEntity(id);
            var mockRepository = new Mock<IClienteRepository>();
            var mockLogger = new Mock<ILogger<ClientePostDataUseCase>>();

            //mocka o retorno do repository
            mockRepository.Setup(s => s.Insert(It.IsAny<ClienteEntity>()));
            var useCase = new ClientePostDataUseCase(mockRepository.Object, mockLogger.Object);

            await useCase.Insert(mockEntity.Result);

            Assert.IsTrue(mockEntity.Result.Valid);
        }

        [TestCase(Description = "UpdateAsync_Success : Deve realizar o update quando requisição válida")]
        public async Task UpdateAsync_Success()
        {
            Guid id = Guid.NewGuid();
            var mockEntity = new BuilderCliente().GetBuildEntity(id);
            var mockRepository = new Mock<IClienteRepository>();
            var mockLogger = new Mock<ILogger<ClientePostDataUseCase>>();

            //mocka o retorno do repository
            mockRepository.Setup(s => s.Update(It.IsAny<ClienteEntity>()));
            var useCase = new ClientePostDataUseCase(mockRepository.Object, mockLogger.Object);

            await useCase.Update(mockEntity.Result);

            Assert.IsTrue(mockEntity.Result.Valid);
        }

        [TestCase(Description = "DeleteAsync_Success : Deve realizar o delete quando requisição válida")]
        public async Task DeleteAsync_Success()
        {
            Guid id = Guid.NewGuid();
            var mockEntity = new BuilderCliente().GetBuildEntity(id);
            var mockRepository = new Mock<IClienteRepository>();
            var mockLogger = new Mock<ILogger<ClientePostDataUseCase>>();

            //mocka o retorno do repository
            mockRepository.Setup(s => s.Delete(It.IsAny<Func<ClienteEntity, bool>>()));
            var useCase = new ClientePostDataUseCase(mockRepository.Object, mockLogger.Object);

            await useCase.Delete(id);

            Assert.IsTrue(mockEntity.Result.Valid);
        }
    }
}
