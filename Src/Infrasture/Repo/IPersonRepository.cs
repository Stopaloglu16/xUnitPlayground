using CoreDomain.Aggregate;
using CoreDomain.Entity;

namespace Infrasture.Repo
{
    public interface IPersonRepository : IRepository<Person>
    {


        Task<IEnumerable<PersonDto>> GetList();

        Task<Person> CreatePerson(Person createRequest);

    }
}
