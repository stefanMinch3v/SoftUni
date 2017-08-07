using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> persons = new List<Person>();

    public void AddMember(Person person)
    {
        persons.Add(person);
    }
    public List<Person> GetOldestMember()
    {
        Person person = null;
        List<Person> allPersons = new List<Person>();
        int maxAge = persons.Max(p => p.GetAge);
        foreach (var p in persons)
        {
            if (p.GetAge == maxAge)
            {
                person = p;
                allPersons.Add(person);
            }
        }
        return allPersons;
    }
}
