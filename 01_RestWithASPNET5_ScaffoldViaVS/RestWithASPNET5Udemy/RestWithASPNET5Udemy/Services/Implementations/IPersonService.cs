using RestWithASPNET5Udemy.Model;
using System.Collections.Generic;

namespace RestWithASPNET5Udemy.Services.Implementations
{
    public interface IPersonService
    {
        Person Create(Person person);

        Person FindByID(long id);

        List<Person> FindAll();

        Person Update(Person person);

        void Delete(long id);
    }
}
