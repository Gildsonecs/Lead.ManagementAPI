using AutoMapper;
using Lead.Management.Api.Controllers;
using Lead.Management.Application.Interfaces;
using Lead.Management.Domain.Entities;
using Lead.Management.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lead.Management.Tests.Api.Controllers
{
    public class InvitedControllerTest
    {
        private Mock<IMapper> _mapperMock;
        private Mock<IInvitedRepository> _invitedRepositoryMock;
        private Mock<IInvitedApplication> _invitedApplicationMock;

        private InvitedController ObterController()
        {
            _mapperMock = new Mock<IMapper>();
            _invitedRepositoryMock = new Mock<IInvitedRepository>();
            _invitedApplicationMock = new Mock<IInvitedApplication>();

            return new InvitedController(_mapperMock.Object, _invitedRepositoryMock.Object, _invitedApplicationMock.Object);
        }

        [Fact]
        public async Task SetGet_QuandoExisteInvited_EntaoRetornaOk() 
        {
            //Arrange
            InvitedController controller = ObterController();

            //Act
            var result = await controller.Get();

            //Assert
            _invitedRepositoryMock.Verify(m => m.GetAllAsync(), Times.Once);
        }

    }
}
