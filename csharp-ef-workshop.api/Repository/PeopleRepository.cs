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

        public bool DeletePerson(int id)
        {
            using(var db = new PeopleContext())
            {
                var p = db.People.Find(id);
                if(p != null)
                {
                    db.People.Remove(p);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public Person GetAPerson(int id)
        {
            Person person;
            using (var db = new PeopleContext())
            {
                person = db.People.Find(id);
                
            }
            return person;
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
