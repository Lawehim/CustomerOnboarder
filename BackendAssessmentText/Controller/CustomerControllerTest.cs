using AutoFixture;
using CustomerOnboarder.Controllers;
using CustomerOnboarder.Core.DTO.Response;
using CustomerOnboarder.Core.Services.Interface;
using CustomerOnboarder.Core.Utility;
using BackendAssessmentText.Helper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BackendAssessmentText.Controller
{
    public class CustomerControllerTest
    {
        private readonly Mock<IUserService> _mockServices;
        private readonly CustomerController _sut;
        private readonly IFixture _fixture;
        public CustomerControllerTest()
        {
            _fixture = new Fixture();
            _mockServices =new Mock<IUserService>();
            _sut = new CustomerController(_mockServices.Object);
        }

        [Theory]
        [InlineData(1,1)]
        public async Task Should_return_GetOnboardedcustomers(int pageSize,int pageNumber)
        {
            //Arrange
            var customerMock = Help.GetResultResponse();
            _mockServices.Setup(x=>x.GetAllOnboarded(pageSize,pageNumber)).ReturnsAsync(customerMock);

            //Act
            var actual = await _sut.GetAllOnBoardedCustomersAsync(pageSize, pageNumber);
  
            //Assert
            actual.Should().NotBeNull();
            actual.Should().BeAssignableTo<IActionResult>();
            actual.Should().BeAssignableTo<OkObjectResult>();
            _mockServices.Verify(x => x.GetAllOnboarded(pageSize,pageNumber), Times.Once());
        }
    }
}
