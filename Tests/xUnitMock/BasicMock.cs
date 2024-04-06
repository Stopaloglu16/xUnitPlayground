using CoreDomain.Aggregate;
using CoreDomain.Entity;
using Infrasture.Repo;
using Moq;
using WebApi.Controllers;
using WebApi.Services;

namespace xUnitMock
{
    public class BasicMock
    {

        [Fact]
        public async void Should_Mock_Function_With_Return_Value()
        {
            //Arrange
            var id = 12;
            var name = "Fred Flintstone";
            var customer = new Person { Id = id, FirstName = name };
            var personClone = new PersonDto() { Id = 12, FirstName = "test1", LastName = "surn1" };
            var mockRepo = new Mock<IPersonRepository>();

            mockRepo.Setup(x => x.CreatePerson(customer));


            var controller = new PersonRepoController(mockRepo.Object);
            //var controller = new TestController(new FakeRepo());
            //Act

            Task.Run(async () =>
            {
               await controller.Create(customer);
            }).GetAwaiter().GetResult();

           var actual = Task.Run(async  () => { await controller.GetById(12); });



            //Assert
            //actual.GetType().Should().Be(typeof(OkObjectResult));


            //Assert.Same(customer, actual);
            Assert.Equal(1, actual.Id);
            //Assert.Equal(name, actual.);
            //Assert.Equal(name, personClone.FirstName);
        }
    }
}
