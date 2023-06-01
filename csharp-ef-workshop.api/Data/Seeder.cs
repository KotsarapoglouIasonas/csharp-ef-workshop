using csharp_ef_workshop.api.Model;

namespace csharp_ef_workshop.api.Data
{
    public static class Seeder
    {
        private static List<string> Firstnames = new List<string>
        {
            "Nigel",
            "Max",
            "Stavros",
            "Iasonas",
            "Thanasis",
            "Joeri",
            "Valentina",
            "Nikita",
            "Brad",
            "Angelina"

        };
        private static List<string> Surnames = new List<string>
        {
            "Red",
            "Orange",
            "Pitt",
            "Jolie",
            "Trump",
            "Yellow",
            "Green",
            "Purple",
            "Blue",
            "Grey",
            "Pink"

        };



        public static void Seed(this WebApplication app)
        {
            Random r = new Random();
            
            List<Person> people = new List<Person>();

            using(var db = new PeopleContext())
            {
                if(!db.People.Any())
                {
                    for(int x = 1; x < 200; x++)
                    {
                        Person person = new Person();
                        person.Id = x;
                        person.Name = $"{Firstnames[r.Next(Firstnames.Count)]} {Surnames[r.Next(Surnames.Count)]}";
                        person.Age = r.Next(50);
                        people.Add(person);
                    }
                    db.People.AddRange(people);
                    db.SaveChanges();
                }
            }
        }
    }
}
