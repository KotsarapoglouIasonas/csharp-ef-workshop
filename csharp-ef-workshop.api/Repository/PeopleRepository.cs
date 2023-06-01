using csharp_ef_workshop.api.Data;
using csharp_ef_workshop.api.Model;

namespace csharp_ef_workshop.api.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        public bool AddPerson(Person person)
        {
            using (var db = new PeopleContext())
            {
                db.People.Add(person);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Person> GetPeople()
        {
            using(var db = new PeopleContext())
            {
                return db.People.ToList();
            }
        }
        
    }
}
