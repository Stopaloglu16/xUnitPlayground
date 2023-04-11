using CoreDomain.Aggregate;
using CoreDomain.Entity;
using Infrasture.Repo;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebApi;

namespace xUnitApiTests.IntegrationTests
{

    [Collection("Sequential")]
    public class PersonControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        //private readonly HttpClient _client;

        //public PersonControllerTest(CustomWebApplicationFactory<WebMarker> factory)
        //{
        //    _client = factory.CreateClient();
        //}
        
        private readonly CustomWebApplicationFactory<Program> _factory;
        private readonly HttpClient _httpClient;

        public PersonControllerTest(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = factory.CreateClient();
        }


        [Fact]
        public async Task Save_ValidPerson_Pass()
        {

            var myTempPerson = new PersonDto
            {
                FirstName = "Bruce",
                LastName = "Wayne"
            };

            using (var scope = _factory.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<ApplicationDbContext>();
                if (db != null && db.Persons.Any())
                {
                    db.Persons.RemoveRange(db.Persons);
                    await db.SaveChangesAsync();
                }
            }

            var response = await _httpClient.PostAsJsonAsync("/api/Person", myTempPerson);

            

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            var personId = await response.Content.ReadAsStringAsync();

            var myList =  await _httpClient.GetFromJsonAsync<List<Person>>("api/Person?IsActive=true");

            Assert.NotNull(myList);
            Assert.Single(myList);


            var myPerson = await _httpClient.GetFromJsonAsync<PersonDto>(String.Format("api/Person/{0}", personId));


            Assert.NotNull(myPerson);
            Assert.Equal(myTempPerson.FirstName, myPerson.FirstName);

        }
    }
}
