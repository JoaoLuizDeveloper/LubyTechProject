using Moq;
using Xunit;
using LubyTechAPI.Repository.IRepository;
using LubyTechAPI.Repository;
using LubyTechModel.Models;
using AutoFixture;
using LubyTechAPI.Service;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LubyTechTests
{
    public class DevTests
    {
        private Mock<IDeveloperRepository> _devRepo;

        public DevTests()
        {
            _devRepo = new Mock<IDeveloperRepository>();
            //_devRepo.Setup(r => r.Get(1)).Returns(new Developer());
        }

        private DeveloperService Subject()
        {
            return new DeveloperService(_devRepo.Object);
        }

        public async Task GetALLDevs()
        {
            // Arrange
            //var dev = Subject();
            // Act
            //var albums = await _devRepo.Verify(x => x.GetAll);

            // Assert
            //Assert.Single(albums);
        } 

        public async Task VerifyCPF()
        {
            // Arrange
            var dev = Subject();

            // Act
            var cpf = await dev.CPFExists(13753366730);

            // Assert
            Assert.True(cpf);
        }

        [Fact]
        public void TheTokenIsString()
        {
            // Arrange
            var dev = Subject();
            var token = dev.GetToken();
            // Act

            // Assert
            Assert.IsType<string>(token);
        }

        [Fact]
        public void IsCreatingNewDeveloper()
        {
            // Arrange
            var fixture = new Fixture();
            var contaCorrente = fixture.Create<Developer>();
        }
    }
}
