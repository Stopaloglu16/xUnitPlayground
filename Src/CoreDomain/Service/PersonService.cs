using AutoMapper;
using CoreDomain.Aggregate;
using CoreDomain.Entity;
using System.ComponentModel.DataAnnotations;

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


        public PersonDto GetPersonDtoException1(int Id, string name1, string name2)
        {
            Person person = new Person(Id, name1, name2);

            ICollection<ValidationResult> results = null;


            if (!Validate(person, out results))
            {
                foreach (ValidationResult result in results)
                {
                    Console.WriteLine("Error " + result.ErrorMessage);
                }

                throw new ArgumentException();
            }

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

        /// <summary>
        /// Validation of the class models
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="results"></param>
        /// <returns></returns>
        static bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}
