using HQY_Microservice;
using HQY_Microservice.Controllers;
using HQY_Microservice.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace HQY_Microservice_Tests
{
    public class MemberControllerTests
    {
        private readonly MemberController _sut;
        private readonly Mock<IMemberRepository> _memberRepoMock = new Mock<IMemberRepository>();
        private readonly Mock<ILoggingService> _loggerMock = new Mock<ILoggingService>();
        public MemberControllerTests()
        {
            _sut = new MemberController(_loggerMock.Object, _memberRepoMock.Object);
        }

        [Fact]
        public void GetById_ShouldReturnMember_WhenMemberExists()
        {
            //Arrange
            int memberId = 1;
            var memberDTO = new Member
            {
                MemberId = 1,
                FirstName = "Mark",
                LastName = "Wilson",
                PhoneNumber = "916-346-7839",
                Email = "mark.wilson@xyz.com"
            };

            _memberRepoMock.Setup(x => x.GetMemberByID(memberId)).Returns(memberDTO);
            //Act
            var member = _sut.GetById(memberId);
            var okResult = member as OkObjectResult;
            //Assert
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void GetById_ShouldReturnNothing_WhenMemberDoesNotExist()
        {
            //Arrange
            _memberRepoMock.Setup(x => x.GetMemberByID(It.IsAny<int>())).Returns(() => null);
            //Act
            var member = _sut.GetById(5);
            var okResult = member as OkObjectResult;
            //Assert
            Assert.Null(okResult);
        }

    }
}
