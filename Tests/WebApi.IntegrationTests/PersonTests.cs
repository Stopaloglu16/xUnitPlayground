using CoreDomain.Aggregate;
using CoreDomain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace WebApi.IntegrationTests;

public class PersonTests : BaseIntegrationTest
{

    public PersonTests(IntegrationTestWebAppFactory factory) : base(factory)
    {

    }

    [Fact]
    public async Task Create_ShouldCreatePerson()
    {
        // Arrange
        Person person = new Person()
        {
            FirstName = "Bruce",
            LastName = "Wayne"
        };

        // Act
        await DbContext.Persons.AddAsync(person);
        await DbContext.SaveChangesAsync();

        var mypp = await DbContext.Persons.ToListAsync();

        // Assert
        var product = await DbContext.Persons.FirstOrDefaultAsync(p => p.Id == person.Id);

        Assert.NotNull(product);
    }

    [Fact]
    public async Task Save_ValidPerson_Pass()
    {
        // Arrange
        var myTempPerson = new PersonDto
        {
            FirstName = "Bruce",
            LastName = "Wayne"
        };

        var response = await _httpClient.PostAsJsonAsync("/api/Person", myTempPerson);

        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        var personId = await response.Content.ReadAsStringAsync();

        // Act
        var myList = await _httpClient.GetFromJsonAsync<List<Person>>("api/Person?IsActive=true");
        Assert.NotNull(myList);


        var myPerson = await _httpClient.GetFromJsonAsync<PersonDto>(String.Format("api/Person/{0}", personId));

        // Assert
        Assert.NotNull(myPerson);
        Assert.Equal(myTempPerson.FirstName, myPerson.FirstName);
    }

}


