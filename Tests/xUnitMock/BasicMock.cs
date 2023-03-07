using CoreDomain.Entity;
using Infrasture.Repo;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace xUnitMock
{
    public class BasicMock
    {

        [Fact]
        public async Task Should_Mock_Function_With_Return_Value()
        {
            //Arrange
            var id = 12;
            var name = "Fred Flintstone";
            var customer = new Person { Id = id,  FirstName = name };
            var mockRepo = new Mock<IPersonRepository>();

            mockRepo.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(customer);

            var controller = new PersonController(mockRepo.Object);
            //var controller = new TestController(new FakeRepo());
            //Act
            var actual = await controller.GetById(id);

            //Assert
            //Assert.Same(customer, actual);
            Assert.Equal(id, actual.Id);
            Assert.Equal(name, actual.FirstName);
        }
    }
}
