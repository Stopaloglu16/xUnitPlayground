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
            //PersonDto person = new PersonDto();

            //person.Id = 1;
            //person.FirstName = "123";
            //person.LastName = "345";


            //var jsonContent = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");


            //var myResponse = await _client.PostAsync($"/api/Person", jsonContent);



            using (var scope = _factory.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<ApplicationDbContext>();
                if (db != null && db.Persons.Any())
                {
                    db.Persons.RemoveRange(db.Persons);
                    await db.SaveChangesAsync();
                }
            }

            var response = await _httpClient.PostAsJsonAsync("/api/Person", new PersonDto
            {
            
                FirstName = "123    ",
                LastName = "345"
        });



            Assert.Equal("", "");
        }



    }

}
