using csharp_ef_workshop.api.Model;

namespace csharp_ef_workshop.api.Repository
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> GetPeople();
        bool AddPerson(Person person);
    }
}
