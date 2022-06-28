using CustomerOnboarder.Controllers;
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
    public class GetbankControllerTest
    {
        private readonly Mock<IGetBankServices> _getBankMock;
        private readonly GetbankController _sut;
        public GetbankControllerTest()
        {
            _getBankMock = new Mock<IGetBankServices>();
            _sut = new GetbankController(_getBankMock.Object);
        }

        [Fact]
        public async Task should_return_Getbanks()
        {
            //Arrange
            var userResponse = Help.GetList();
            _getBankMock.Setup(b => b.GetbankRequest()).ReturnsAsync(userResponse);
            //Act
            var actual = await _sut.GetBanks();

            //Assert
            actual.Should().NotBeNull();
            actual.Should().BeAssignableTo<IActionResult>();
            _getBankMock.Verify(x => x.GetbankRequest(), Times.Once());
        }
    }
}
