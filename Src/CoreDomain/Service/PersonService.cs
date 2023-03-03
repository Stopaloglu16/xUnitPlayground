using AutoMapper;
using CoreDomain.Aggregate;
using CoreDomain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain.Service
{
    public class PersonService
    {

        public PersonDto GetPersonDto()
        {
            Person person = new Person(1, "Test", "Test");


            var config = new MapperConfiguration(cfg => cfg.CreateMap<Person, PersonDto>());

            var mapper = new Mapper(config);
            return mapper.Map<PersonDto>(person);

        }


        public PersonDto GetPersonDtoException1()
        {
            Person person = new Person(1, null!, "Test");

            ICollection<ValidationResult> results = null;


            Validate(person, out results);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Person, PersonDto>());

            var mapper = new Mapper(config);
            return mapper.Map<PersonDto>(person);

        }


        public PersonDto GetPersonDtoException2()
        {
            try
            {
                Person person = new Person(1, null!, "Test");
                

                var config = new MapperConfiguration(cfg => cfg.CreateMap<Person, PersonDto>());

                var mapper = new Mapper(config);
                return mapper.Map<PersonDto>(person);
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        static bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}
