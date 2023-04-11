using CoreDomain.Aggregate;

namespace WebApi.Services
{
    public interface IPersonService
    {

        Task<int> Add(PersonDto myPerson);

        Task<PersonDto> GetByIdAsync(int  Id);

        Task<IEnumerable<PersonDto>> GetList();

    }
}
