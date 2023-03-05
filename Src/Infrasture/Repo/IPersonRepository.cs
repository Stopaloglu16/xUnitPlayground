using CoreDomain.Aggregate;
using CoreDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrasture.Repo
{
    public interface IPersonRepository: IRepository<Person>
    {
        Task<IEnumerable<PersonDto>> GetList();
      
        Task<PersonDto> CreatePerson(PersonDto createRequest);
      

    }
}
