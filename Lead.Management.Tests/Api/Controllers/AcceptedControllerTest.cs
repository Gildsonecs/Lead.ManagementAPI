using AutoMapper;
using Lead.Management.Api.Controllers;
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
    public class AcceptedControllerTest
    {

        private Mock<IMapper> _mapperMock;
        private Mock<IInvitedRepository> _invitedRepositoryMock;

        private AcceptedController ObterController()
        {
            _mapperMock = new Mock<IMapper>();
            _invitedRepositoryMock = new Mock<IInvitedRepository>();

            return new AcceptedController(_mapperMock.Object, _invitedRepositoryMock.Object);
        }

        [Fact]
        public async Task SetGet_QuandoExisteAccepted_EntaoRetornaOk() 
        {
            //Arrange
            AcceptedController controller = ObterController();

            //Act
            var result = await controller.Get();

            //Assert
            _invitedRepositoryMock.Verify(m => m.GetAllAcceptAsync(), Times.Once);
        }
    }
}
