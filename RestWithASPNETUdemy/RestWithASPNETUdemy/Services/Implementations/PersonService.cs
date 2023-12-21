using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private volatile int count;
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            List<Person> people = new List<Person>();

            for(int k = 0; k < 10; k++)
            {
                people.Add( MockPerson(k));
            }

            return people;
        }

        public Person GetById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName= "Amarildo",
                LastName = "Ferreira",
                Address = "Camama, Belas, Luanda",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int k)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name " + k,
                LastName = "Person Lastname " + k,
                Address = "Some address " + k,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
