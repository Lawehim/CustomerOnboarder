using AutoFixture;
using CustomerOnboarder.Controllers;
using CustomerOnboarder.Core.DTO.Request;
using CustomerOnboarder.Core.DTO.Response;
using CustomerOnboarder.Core.Services.Interface;
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
    public class AutheticationControllerTest
    {
        private readonly Mock<IAuthenticationServices> _mockServices;
        private readonly AuthenticationController _sut;
        public AutheticationControllerTest()
        {
            _mockServices = new Mock<IAuthenticationServices>();
            _sut = new AuthenticationController(_mockServices.Object);
        }

        [Fact]
        public async Task Should_OnboardCustomer()
        {
            //Arrange
            var userRequest = new UserRequestDto
            {
                Email = "fat12@gm.com",
                LGA = "Shomolu",
                State = "Lagos",
                PhoneNumber = "08141286000",
                Password = "Fatai@01"
            };
            var userResponse = Help.GetResult();
            _mockServices.Setup(x => x.OnboardCustomer(userRequest)).ReturnsAsync(userResponse);

            //Act
            var actual = await _sut.OnboardCustomer(userRequest);

            //Assert
            actual.Should().NotBeNull();
            actual.Should().BeAssignableTo<ActionResult>();
            _mockServices.Verify(x => x.OnboardCustomer(userRequest), Times.Once());
        }
    }
}
