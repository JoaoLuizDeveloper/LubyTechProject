using AutoMapper;
using LubyTechAPI.Controllers;
using LubyTechAPI.Controllers.Version2;
using LubyTechAPI.Repository;
using LubyTechAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using X.PagedList;
using Xunit;

namespace LubyTechTests
{
    public class DeveloperTests
    {
        //private readonly DevelopersController _controller;
        //private readonly DevelopersV2Controller _controllerV2;
        //private readonly IMapper _mapper;
        //private readonly Mock<IDeveloperRepository> devRepo = new Mock<IDeveloperRepository>();

        //public DeveloperTests(){
        //    _controller = new DevelopersController(devRepo.Object, _mapper);
        //    _controllerV2 = new DevelopersV2Controller(devRepo.Object, _mapper);
        //}

        [Fact]
        public void Soma_DeveRetornarOValorCorreto()
        {
            var c = new Mock<Calc>();
            var resultado = c.Object.Soma(10, 20);
            //Verifica se o resultado é igual a 30        
            Assert.Equal(30, resultado);
        }

        //[Fact]
        //public void Trying_To_Get_Ranking_Of_All_Developers()
        //{
        //    // Arrange
        //    devRepo.Setup(x => x.GetRankinfOfDevelopers()).Returns(GetHourByDevsExample());            

        //    // Act
        //    var result = _controllerV2.GetRankingOfDevelopers().OrderBy(x=>x.AllTime).Take(5);

        //    // Assert
        //    var view = Assert.IsType<List<HourByDeveloper>>(result);
                                    
        //    Assert.Equal(5, view.Count);
        //}
        
        //[Fact]
        //public void Trying_To_Get_Token()
        //{
        //    // Arrange

        //    // Act
        //    string token = devRepo.Object.GetToken();

        //    // Assert
        //    Assert.IsType<string>(token);
        //}

        //[Theory]
        //[InlineData(3)]
        //[InlineData(5)]
        //[InlineData(6)]
        //public async Task GetDeveloper_IfExist(int devId)
        //{
        //    // Arrange
        //    var DevDto = new Developer()
        //    {
        //        Id = 5,
        //        Name = "Matue",
        //        CPF = "193.368.840-85",
        //        Created = DateTime.Now,
        //    };

        //    devRepo.Setup(x => x.GetDeveloper(devId)).ReturnsAsync(DevDto);

        //    // Act
        //    var dev = await _controller.GetDeveloper(devId);


        //    // Assert
        //    Assert.Equal(devId, dev.Id);
        //}

        //[Fact]
        //public async Task GetDeveloper_IfNonExist()
        //{
        //    // Arrange
        //    var DevDto = new Developer()
        //    {
        //        Id = 5,
        //        Name = "Joao",
        //        CPF = "193.368.840-85",
        //        Created = DateTime.Now,
        //    };

        //    devRepo.Setup(x => x.GetDeveloper(4)).ReturnsAsync(()=>null);

        //    // Act
        //    var dev = await _controller.GetDeveloper(4);

        //    // Assert
        //    Assert.Null(dev);
        //}

        //[Theory]
        //[InlineData(13753366730)]
        //[InlineData(75513478013)]
        //[InlineData(46796839021)]
        //public async Task Check_IfCpf_ReturnNullif_NonExist(long cpf)
        //{
        //    // Arrange            
        //    devRepo.Setup(x => x.DeveloperCPFExists(cpf)).ReturnsAsync(()=>null);

        //    // Act
        //    var dev = await _controller.SearchCpf(cpf);

        //    // Assert
        //    Assert.Null(dev);
        //}
        
                
        //private List<HourByDeveloper> GetHourByDevsExample()
        //{
        //    var devs = new List<HourByDeveloper>();
        //    devs.Add(new HourByDeveloper()
        //    {
        //        IdDev = 2,
        //        NameDev = "Matue",
        //        AllTime = 2
        //    });

        //    devs.Add(new HourByDeveloper()
        //    {
        //        IdDev = 3,
        //        NameDev = "Thais",
        //        AllTime = 5
        //    });

        //    devs.Add(new HourByDeveloper()
        //    {
        //        IdDev = 5,
        //        NameDev = "Tamiris",
        //        AllTime = 16
        //    });

        //    devs.Add(new HourByDeveloper()
        //    {
        //        IdDev = 6,
        //        NameDev = "JuninhoDev",
        //        AllTime = 4.5
        //    });
            
        //    devs.Add(new HourByDeveloper()
        //    {
        //        IdDev = 7,
        //        NameDev = "Carlucho",
        //        AllTime = 2.5
        //    });
            
        //    devs.Add(new HourByDeveloper()
        //    {
        //        IdDev = 8,
        //        NameDev = "Vinicius",
        //        AllTime = 6
        //    });

        //    return devs;
        //}
    }
}
