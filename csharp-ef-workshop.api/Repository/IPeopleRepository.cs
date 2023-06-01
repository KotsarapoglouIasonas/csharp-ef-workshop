using csharp_ef_workshop.api.Model;

namespace csharp_ef_workshop.api.Repository
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> GetPeople();
        Person GetAPerson(int id);
        bool AddPerson(Person person);
        bool DeletePerson(int id);
    }
}
