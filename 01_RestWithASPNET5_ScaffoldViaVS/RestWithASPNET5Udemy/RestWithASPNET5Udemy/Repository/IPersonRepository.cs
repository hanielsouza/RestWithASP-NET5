using RestWithASPNET5Udemy.Model;

namespace RestWithASPNET5Udemy.Repository
{
    public interface IPersonRepository:IRepository<Person>
    {
        Person Disable(long id);

    }
}
